using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace CapstoneBlazorServerSite.Pages
{
    public partial class Index : IAsyncDisposable
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        public bool IsAuthenticated { get; set; }

        [Inject]
        IJSRuntime JS {  get; set; }
        
        private IJSObjectReference module;

        protected override async Task OnInitializedAsync()
        {
            await CheckAuth();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/splashPageListener.js");
            await module.InvokeVoidAsync("initializeSplashPageListener");
        }

        private async Task CheckAuth()
        {
            if (await AuthenticationStateTask != null) 
            {
                IsAuthenticated = true;
            }
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
