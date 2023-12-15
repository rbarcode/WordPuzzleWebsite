using Microsoft.AspNetCore.Components;

namespace CapstoneBlazorServerSite.Components
{
    public partial class NavBarComponent
    {
        [Parameter]
        public bool IsAuthenticated { get; set; }
    }
}
