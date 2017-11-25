using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RestApi
    {
        private readonly HttpClient _client;
        private readonly string _path;

        public RestApi(string uri, string path)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
            _path = path;
        }
        private HttpContent CreateJsonBody(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        }
        private async Task<Tuple<bool, T>> ParseResponse<T>(HttpResponseMessage response) where T : class
        {
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                return Tuple.Create<bool, T>(false, null);
            }
            else
            {
                return Tuple.Create(true, JsonConvert.DeserializeObject<T>(responseContent));
            }
        }

        public async Task<Tuple<bool, T>> Get<T>(int? id) where T : class
        {
            var newPath = $"{_path}";
            if (id.HasValue)
            {
                newPath += $"?id={ id}";
            }
            var response = await _client.GetAsync(newPath);

            return await ParseResponse<T>(response);
        }
        public async Task<Tuple<bool, T>> Post<T>(object model) where T : class
        {
            var content = CreateJsonBody(model);
            var response = await _client.PostAsync(_path, content);

            return await ParseResponse<T>(response);
        }
        public async Task<Tuple<bool, T>> Put<T>(int? id, object model) where T : class
        {
            var newPath = $"{_path}";
            if (id.HasValue)
            {
                newPath += $"?id={ id}";
            }
            var content = CreateJsonBody(model);
            var response = await _client.PutAsync(newPath, content);

            return await ParseResponse<T>(response);
        }
        public async Task<Tuple<bool, T>> Delete<T>(int? id) where T : class
        {
            var newPath = $"{_path}";
            if (id.HasValue)
            {
                newPath += $"?id={ id}";
            }
            var response = await _client.DeleteAsync(newPath);

            return await ParseResponse<T>(response);
        }
    }
}
