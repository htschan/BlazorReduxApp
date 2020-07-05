using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorReduxApp.Extensions
{
   public static class HttpClientExtension
   {
      static JsonReaderOptions options = new JsonReaderOptions
      {
         AllowTrailingCommas = true
      };

      static JsonSerializerOptions opt = new JsonSerializerOptions
      {
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
         PropertyNameCaseInsensitive = true

      };

      public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string requestUri)
      {
         var httpContent = await httpClient.GetAsync(requestUri);
         string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
         var obj = JsonSerializer.Deserialize<T>(jsonContent);
         httpContent.Dispose();
         httpClient.Dispose();
         return obj;
      }

      public static async Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient httpClient, string requestUri, T content)
      {
         string myContent = JsonSerializer.Serialize(content);
         var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
         var response = await httpClient.PostAsync(requestUri, stringContent);
         httpClient.Dispose();
         return response;
      }

      public static async Task<HttpResponseMessage> PutJsonAsync<T>(this HttpClient httpClient, string requestUri, T content)
      {
         string myContent = JsonSerializer.Serialize(content);
         var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
         var response = await httpClient.PutAsync(requestUri, stringContent);
         httpClient.Dispose();
         return response;
      }
   }
}
