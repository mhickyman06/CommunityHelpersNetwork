#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d945c0dca4eff3a652c80c3c2a0b17c4fe6ecbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d945c0dca4eff3a652c80c3c2a0b17c4fe6ecbb", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36f17b747331f9978aa572b9d5cb89328ed1b07f", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\HI\Documents\HelpersNetwork\Views\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Confirm Email";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .email-confirmtext-head {
        color: black;
        font-size: x-large;
        font-family: ""Montserrat"";
        font-weight: 700;
    }
    .email-confirmtext {
        color: black;
        font-size: large;
        font-family: ""Montserrat"";
        font-weight: 700;
    }
</style>

<header>
    <div class=""header"" style=""background-color: #023041; top: 0px; position: fixed; z-index: 999; width: 100%"">
");
#nullable restore
#line 24 "C:\Users\HI\Documents\HelpersNetwork\Views\Account\ConfirmEmail.cshtml"
          
            await Html.RenderPartialAsync("_MenuBar");
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</header>\r\n<div style=\"margin-top:100px\">\r\n    <div class=\"home-page-welcome\">\r\n        <h3 class=\"mt-2 h-st b-h2\">Email Confirmation</h3>\r\n    </div>\r\n</div>\r\n\r\n<div style=\"margin-top:100px; margin-bottom:200px\">\r\n");
            WriteLiteral("    <div class=\"mt-3\">\r\n        <p class=\"text-center email-confirmtext\">Thank You For confirmng Your Email Account. ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d945c0dca4eff3a652c80c3c2a0b17c4fe6ecbb5285", async() => {
                WriteLiteral("Click this to Login");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n    </div>\r\n</div>");
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
