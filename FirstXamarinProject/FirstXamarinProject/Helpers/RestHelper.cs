using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FirstXamarinProject.Helpers
{
    public class RestHelper
    {
        HttpClient client;


        public RestHelper()
        {
            client = new HttpClient();
        }

        public void SetTimeout(TimeSpan time)
        {
            client.Timeout = time;
        }

        public void AddHeader(string key, string value)
        {
            client.DefaultRequestHeaders.Add(key, value);
        }

        public void AddBearer(string token)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public TResponse Get<TResponse>(string baseUrl, string method, string query = null)
        {
            string uri = baseUrl + method;
            if (query != null)
            {
                uri += query;
            }
            var streamTask = client.GetStringAsync(uri);

            if (typeof(TResponse) == typeof(String))
            {
                return JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(streamTask.Result));
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(streamTask.Result);
                return obj;
            }
        }

        public TResponse Post<TRequest, TResponse>(string baseUrl, string method, TRequest parameters)
        {
            string content = JsonConvert.SerializeObject(parameters, new JsonSerializerSettings{ContractResolver = new DefaultContractResolver{NamingStrategy = new SnakeCaseNamingStrategy()},Formatting = Formatting.Indented});
            Task<TResponse> task = DoPostAsync<TResponse>(baseUrl, method, content);
            task.Wait();
            var result = task.Result;
            return result;
        }

        public TResponse Delete<TResponse>(string baseUrl, string method)
        {
            Task<TResponse> task = DoDeleteAsync<TResponse>(baseUrl, method);
            task.Wait();
            var result = task.Result;
            return result;
        }

        public TResponse Put<TRequest, TResponse>(string baseUrl, string method, TRequest parameters)
        {
            string content = JsonConvert.SerializeObject(parameters, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }, Formatting = Formatting.Indented });
            Task<TResponse> task = DoPutAsync<TResponse>(baseUrl, method, content);
            task.Wait();
            var result = task.Result;
            return result;
        }

        private async Task<TResponse> DoPostAsync<TResponse>(string baseUrl, string method, string parameters)
        {
            var buffer = Encoding.UTF8.GetBytes(parameters);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PostAsync(uri, byteContent).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    logger.Error("HttpError: " + JsonConvert.SerializeObject(response));
            //    logger.Error("HttpError: " + result);
            //}
            if (typeof(TResponse) == typeof(String))
            {
                return JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(result));
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(result);
                return obj;
            }
        }

        private async Task<TResponse> DoPutAsync<TResponse>(string baseUrl, string method, string parameters)
        {
            var buffer = Encoding.UTF8.GetBytes(parameters);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string uri = baseUrl + method;
            var response = await client.PutAsync(uri, byteContent).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    logger.Error("HttpError: " + JsonConvert.SerializeObject(response));
            //    logger.Error("HttpError: " + result);
            //}
            if (typeof(TResponse) == typeof(String))
            {
                return JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(result));
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(result);
                return obj;
            }
        }

        private async Task<TResponse> DoDeleteAsync<TResponse>(string baseUrl, string method)
        {
            string uri = baseUrl + method;
            var response = await client.DeleteAsync(uri).ConfigureAwait(false);
            string result = await response.Content.ReadAsStringAsync();
            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    logger.Error("HttpError: " + JsonConvert.SerializeObject(response));
            //    logger.Error("HttpError: " + result);
            //}
            if (typeof(TResponse) == typeof(String))
            {
                return JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(result));
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<TResponse>(result);
                return obj;
            }
        }
    }
}
