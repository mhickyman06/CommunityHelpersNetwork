#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4df145251ca9f47a27767c9bddd29ce01efd2d14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrative_DailyView), @"mvc.1.0.view", @"/Views/Administrative/DailyView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4df145251ca9f47a27767c9bddd29ce01efd2d14", @"/Views/Administrative/DailyView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d54771ef3fff688cc446c338c1f81d54612ddb2e", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrative_DailyView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HelpersNetwork.Views.Home.DailyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
  
    ViewData["Title"] = "DailyInspirationQuote";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container m-5\">\r\n\r\n\r\n    <h1>DailyInspiration Quote</h1>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 18 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
               Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 24 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
               Write(Html.DisplayNameFor(model => model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            \r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n           \r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
                   Write(Html.DisplayFor(modelItem => modelItem.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                   \r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
                   Write(Html.DisplayFor(modelItem => modelItem.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                   \r\n                    <td>\r\n                        ");
#nullable restore
#line 42 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
                   Write(Html.DisplayFor(modelItem => modelItem.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td> \r\n                   \r\n                   \r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 48 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrative\DailyView.cshtml"
                   Write(Html.ActionLink("EditDailyView", "EditDailyView", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                      \r\n                    </td>\r\n                </tr>\r\n            \r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HelpersNetwork.Views.Home.DailyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
