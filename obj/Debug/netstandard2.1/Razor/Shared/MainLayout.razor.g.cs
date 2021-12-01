#pragma checksum "/home/lasse/Code/2ndSemProject/Shared/MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a92a1311a504eaadcedbddb12ad0f16c02cb2d7a"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using BlazorApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using BlazorApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/lasse/Code/2ndSemProject/_Imports.razor"
using System.Web;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "/home/lasse/Code/2ndSemProject/Shared/MainLayout.razor"
 if (AuthenticationService.User != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "    \r\n    ");
            __builder.OpenElement(1, "nav");
            __builder.AddAttribute(2, "class", "navbar navbar-expand navbar-dark bg-dark");
            __builder.AddMarkupContent(3, "\r\n        ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "navbar-nav");
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(7);
            __builder.AddAttribute(8, "href", "");
            __builder.AddAttribute(9, "Match", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 10 "/home/lasse/Code/2ndSemProject/Shared/MainLayout.razor"
                                    NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "class", "nav-item nav-link");
            __builder.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(12, "Home");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(13, "\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(14);
            __builder.AddAttribute(15, "href", "logout");
            __builder.AddAttribute(16, "class", "nav-item nav-link");
            __builder.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(18, "Logout");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n");
#nullable restore
#line 14 "/home/lasse/Code/2ndSemProject/Shared/MainLayout.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(22, "\r\n");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "container");
            __builder.AddMarkupContent(25, "\r\n    ");
#nullable restore
#line 17 "/home/lasse/Code/2ndSemProject/Shared/MainLayout.razor"
__builder.AddContent(26, Body);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(27, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthenticationService { get; set; }
    }
}
#pragma warning restore 1591
