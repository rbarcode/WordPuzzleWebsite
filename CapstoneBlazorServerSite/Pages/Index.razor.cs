

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CapstoneBlazorServerSite.Pages
{
    public partial class Index : IAsyncDisposable
    {
        [Inject]
        IJSRuntime JS {  get; set; }
        
        private IJSObjectReference module;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/splashPageListener.js");
            await module.InvokeVoidAsync("initializeSplashPageListener");
        }

        public async ValueTask DisposeAsync() 
        { 
            if(module != null)
            {
                await module.DisposeAsync();
            }
            
        }

    }    
}
