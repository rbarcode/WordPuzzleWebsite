using Microsoft.AspNetCore.Components;

namespace CapstoneBlazorServerSite.Components
{
    public partial class MainMenuComponent
    {
        [Parameter]
        public bool IsAuthenticated { get; set; }
    }
}
