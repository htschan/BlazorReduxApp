using System;
using System.Text.Json;

namespace BlazorReduxApp.BlazorRedux
{
   public class ReduxOptions<TState>
   {
      public ReduxOptions()
      {
         // Defaults
         StateSerializer = state => JsonSerializer.Serialize(state);
         StateDeserializer = jsonString => JsonSerializer.Deserialize<TState>(jsonString);
      }

      public Reducer<TState, NewLocationAction> LocationReducer { get; set; }
      public Func<TState, string> GetLocation { get; set; }
      public Func<TState, string> StateSerializer { get; set; }
      public Func<string, TState> StateDeserializer { get; set; }
   }
}
