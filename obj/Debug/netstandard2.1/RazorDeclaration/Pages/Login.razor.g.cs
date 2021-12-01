// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using BlazorApp.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using BlazorApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using BlazorApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/_Imports.razor"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/Pages/Login.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "/home/lasse/Code/blazor-webassembly-jwt-authentication-example/Pages/Login.razor"
       
    private Model model = new Model();
    private bool loading;
    private string error;

    protected override void OnInitialized()
    {
        // redirect to home if already logged in
        if (AuthenticationService.User != null)
        {
            NavigationManager.NavigateTo("");
        }
    }

    private async void HandleValidSubmit()
    {
        loading = true;
        try
        {
            await AuthenticationService.Login(model.Username, model.Password);
            var returnUrl = NavigationManager.QueryString("returnUrl") ?? "";
            NavigationManager.NavigateTo(returnUrl);
        }
        catch (Exception ex)
        {
            error = ex.Message;
            loading = false;
            StateHasChanged();
        }
    }

    private class Model
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthenticationService { get; set; }
    }
}
#pragma warning restore 1591
