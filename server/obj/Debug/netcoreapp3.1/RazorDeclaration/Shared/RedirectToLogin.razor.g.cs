// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CoreRadzen.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 6 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 7 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using CoreRadzen.Shared;

#line default
#line hidden
#line 8 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Radzen;

#line default
#line hidden
    public partial class RedirectToLogin : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 3 "C:\JIM\CORE-RADZEN\server\Shared\RedirectToLogin.razor"
       
    [Parameter]
    public bool IsAuthenticated { get; set; }

    protected override void OnInitialized()
    {
        if (!IsAuthenticated)
        {
            UriHelper.NavigateTo("Account/Login", true);
        }
        else
        {
            UriHelper.NavigateTo("Unauthorized", true);
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UriHelper { get; set; }
    }
}
#pragma warning restore 1591
