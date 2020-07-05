using System.Collections.Generic;

namespace BlazorReduxApp.Data
{
   public class MessageState
   {
      public string Location { get; set; }
      public string MessageType { get; set; }
      public string MessageContent { get; set; }
      public int Classification { get; set; }
      public int Priority { get; set; }
      public string Title { get; set; }
      public string Source { get; set; }
      public int Count { get; set; }
      public IEnumerable<WeatherForecast> Forecasts { get; set; }
   }
}