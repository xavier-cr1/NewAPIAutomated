using APILayer.Client.Base;
using APILayer.Client.Contracts;
using APILayer.Entities.PostsService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace APILayer.Client
{
    public class PostsServiceRestApi : ServiceRestApiClientBase, IPostsServiceRestApi
    {
        private string postsService => this.ConfigurationRoot.GetSection("AppConfiguration")["PostsAPIService"];

        public PostsServiceRestApi(IConfigurationRoot configurationRoot) 
            : base (configurationRoot)
        {
        }

        public async Task<PostsRootResponse> PostsServiceGetAsyncGeneric(PostsRequest postsRequest)
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

        //Doesn't work -> Http response automatic decompression?
        public async Task<string> PostsServiceGetAsync(PostsRequest postsRequest)
        {
            string postsRootResponse = "";
            var url = GetBaseUrlRequest(this.postsService, postsRequest);

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var gzipFileName = "C:\\Users\\x.casafont\\Desktop\\SafenedTest\\tesst.gz";
                    var arrayByte = await response.Content.ReadAsByteArrayAsync();
                    using (FileStream destinationFile = File.Create(gzipFileName))
                    using (var zipStream = new GZipStream(destinationFile, CompressionMode.Compress))
                    {
                        zipStream.Write(arrayByte, 0, arrayByte.Length);
                        zipStream.Close();
                    }
                }
                return postsRootResponse;
            }
        }

        //webresponse object -> Api Content, revelated a gzip encryption
        public PostsRootResponse PostsServiceGetAsyncFromGzip(PostsRequest postsRequest)
        {
            string postsRootResponse = "";
            var url = GetBaseUrlRequest(this.postsService, postsRequest);

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                //KEY to decompress /!\
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        postsRootResponse = reader.ReadToEnd();
                    }

                    var jsonPostsRoot = JsonConvert.DeserializeObject<PostsRootResponse>(postsRootResponse);
                    jsonPostsRoot.StatusCode = response.StatusCode.ToString();
                    return jsonPostsRoot;
                }

            }
            catch(WebException webEx)
            {
                var responseErr = (HttpWebResponse)webEx.Response;
                return new PostsRootResponse { StatusCode = responseErr.StatusDescription };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
