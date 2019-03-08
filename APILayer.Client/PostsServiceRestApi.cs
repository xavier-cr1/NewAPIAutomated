using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace APILayer.Client
{
    public class PostsServiceRestApi : ServiceRestApiClientBase, IPostsServiceRestApi
    {
        private string postsService => this.configurationRoot.GetSection("AppConfiguration")["PostsAPIService"];

        public PostsServiceRestApi(IConfigurationRoot configurationRoot) 
            : base (configurationRoot)
        {
        }

        public async Task<PostsRootResponse> PostsServiceGetAsync(PostsRequest postsRequest)
        {
            try
            {
                // Build url
                var url = GetBaseUrlRequest(this.postsService, postsRequest);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    // Create request
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.JsonMediaType));

                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    // Response
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

                    return await this.CreateGenericResponse<PostsRootResponse>(response);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
