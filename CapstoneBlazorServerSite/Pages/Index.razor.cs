using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CapstoneBlazorServerSite.Pages
{
    public partial class Index
    {

        [Inject]
        IJSRuntime JS {  get; set; }
        
        private IJSObjectReference? module;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/splashPageListener.js");
            await module.InvokeVoidAsync("initializeSplashPageListener");
            Console.WriteLine("splashPageListener loaded!");
        }

        public async ValueTask DisposeAsync() 
        { 
            if(module != null)
            {
                await module.DisposeAsync();
                Console.WriteLine("This is the JS object: " + module);
            }
            
        }

    }    
}
