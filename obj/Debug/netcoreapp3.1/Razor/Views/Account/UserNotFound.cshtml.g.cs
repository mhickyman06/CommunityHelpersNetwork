#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\Account\UserNotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3528fb4dad4636278f0da8c6b20861b473dbb62e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_UserNotFound), @"mvc.1.0.view", @"/Views/Account/UserNotFound.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using HelpersNetwork;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using HelpersNetwork.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using HelpersNetwork.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using HelpersNetwork.Models.SeedRoles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HI\Documents\HelpersNetwork\Views\_ViewImports.cshtml"
using ReflectionIT.Mvc.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3528fb4dad4636278f0da8c6b20861b473dbb62e", @"/Views/Account/UserNotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9497bc13e4b77008064841e4ae31c9c37e1b2ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_UserNotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HI\Documents\HelpersNetwork\Views\Account\UserNotFound.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header>\r\n    <div class=\"header\" style=\"background-color: #023041; top: 0px; position: fixed; z-index: 999; width: 100%\">\r\n");
#nullable restore
#line 7 "C:\Users\HI\Documents\HelpersNetwork\Views\Account\UserNotFound.cshtml"
          
            await Html.RenderPartialAsync("_MenuBar");
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</header>
<div style=""margin-top:100px"">
    <div class=""home-page-welcome"">
        <h3 class=""mt-2 h-st b-h2"">UserNotFound</h3>
    </div>
</div>
<div class=""m-5 container"" style=""padding-top:80px;padding-bottom:80px"">
    <div>
        <h4 class=""text-danger text-center"">The Login User Was not Found</h4>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
