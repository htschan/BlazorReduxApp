using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorReduxApp.BlazorRedux
{
   public class ReduxComponent<TState, TAction> : ComponentBase, IDisposable
   {
      [Inject] public Store<TState, TAction> Store { get; set; }
      [Inject] private NavigationManager UriHelper { get; set; }

      public TState State => Store.State;

      public RenderFragment ReduxDevTools;

      public void Dispose()
      {
         Store.Change -= OnChangeHandler;
      }

      protected override Task OnAfterRenderAsync(bool firstRender)
      {
         Store.Init(UriHelper);
         Store.Change += OnChangeHandler;

         ReduxDevTools = builder =>
         {
            var seq = 0;
            builder.OpenComponent<ReduxDevTools>(seq);
            builder.CloseComponent();
         };
         return base.OnAfterRenderAsync(firstRender);
      }

      private void OnChangeHandler(object sender, EventArgs e)
      {
         StateHasChanged();
      }

      public void Dispatch(TAction action)
      {
         Store.Dispatch(action);
      }
   }
}
