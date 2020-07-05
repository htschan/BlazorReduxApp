using System;

namespace BlazorReduxApp.BlazorRedux
{
   public class StringEventArgs : EventArgs
   {
      public StringEventArgs(string s)
      {
         String = s;
      }

      public string String { get; }
   }

   public delegate void StringEventHandler(object sender, StringEventArgs args);
}
