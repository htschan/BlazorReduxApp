using System.Net.Http;
using System.Threading.Tasks;
using BlazorReduxApp.BlazorRedux;
using BlazorReduxApp.Extensions;

namespace BlazorReduxApp.Data
{
   public class ActionCreators
   {
      public static async Task LoadWeather(Dispatcher<IAction> dispatch, IHttpClientFactory httpClientFactory, string baseUri)
      {
         var http = httpClientFactory.CreateClient();

         dispatch(new ClearWeatherAction());

         var forecasts = await http.GetJsonAsync<WeatherForecast[]>(
            $"{baseUri}/sample-data/wheather.json");

         dispatch(new ReceiveWeatherAction
         {
            Forecasts = forecasts
         });
      }
   }
}