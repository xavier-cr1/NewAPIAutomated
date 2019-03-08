using APILayer.Entities.Commom;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILayer.Client.Base
{
    public class ServiceRestApiClientBase
    {
        //base attr
        protected readonly string fromDateBaseAttr = "todate=";

        protected readonly string toDateBaseAttr = "todate=";

        protected readonly string orderBaseAttr = "order=";

        protected readonly string sort = "sort=";

        protected readonly string activity = "site=stackoverflow";
        
        //medias
        protected readonly string JsonMediaType = "application/json";

        //config
        protected readonly IConfigurationRoot configurationRoot;

        //Inject configuration json file into rest service base
        public ServiceRestApiClientBase(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        protected string GetBaseUrlRequest(string baseEnvironmentUrl, BaseRequest baseRequest)
        {
            return $"{baseEnvironmentUrl}?{this.fromDateBaseAttr}{baseRequest.FromDate}&{this.toDateBaseAttr}{baseRequest.ToDate}&" +
                $"{this.orderBaseAttr}{baseRequest.Order}&{this.sort}{baseRequest.Sort}&{this.activity}";
        }

        protected async Task<T> CreateGenericResponse<T>(HttpResponseMessage response) where T : class
        {
            var headers = this.CreateHeadersDictionary(response);
            var status = ((int)response.StatusCode).ToString();
            var responseData = await this.CreateResponseData(response, status, headers);

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        private async Task<string> CreateResponseData(HttpResponseMessage response, string status, IDictionary<string, IEnumerable<string>> headers)
        {
            var responseData = string.Empty;

            responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            switch (status)
            {
                case "200":
                case "201":
                case "204":
                    return responseData;

                default:
                    throw new HttpRequestException();
            }
        }

        private IDictionary<string, IEnumerable<string>> CreateHeadersDictionary(HttpResponseMessage response)
        {
            var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);

            foreach (var item in response.Content.Headers)
            {
                headers[item.Key] = item.Value;
            }

            return headers;
        }
    }
}
