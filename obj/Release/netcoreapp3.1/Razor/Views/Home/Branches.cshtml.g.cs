#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bccbba58f21cbc5a6721c571117ab069be0f4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Branches), @"mvc.1.0.view", @"/Views/Home/Branches.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bccbba58f21cbc5a6721c571117ab069be0f4cb", @"/Views/Home/Branches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9497bc13e4b77008064841e4ae31c9c37e1b2ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Branches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IOrderedQueryable<HelpersNetworkBranchesTb>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
  
    ViewData["Title"] = "Branch List";

    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    table thead tr th {
        font-family: ""Poppins"";
        font-weight: 500;
        background-color: #023041;
    }

    table tbody tr td {
        font-family: ""Montserrat"";
    }

    .mean-container .mean-bar {
        background-color: #4e7b88;
    }
</style>

<header>
    <div class=""header"" style=""background-color: #023041;
        top: 0px;
        position: fixed;
        z-index: 999;
        width: 100%"">
");
#nullable restore
#line 34 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
          
            await Html.RenderPartialAsync("_MenuBar");
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</header>
<div class=""container"">
    <div style=""margin-top:200px"">
        <div>
            <table id=""branchesTable"" class="" table table-bordered table-striped"">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Country</th>
                        <th>State</th>
                        <th>Local Government</th>
                        <th>Address</th>
                        <th>Contact Person</th>
                        <th>Contact Person Number</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 55 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                     foreach (var branch in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 1427, "\"", 1446, 2);
            WriteAttributeValue("", 1432, "row_", 1432, 4, true);
#nullable restore
#line 57 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
WriteAttributeValue("", 1436, branch.Id, 1436, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 58 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 59 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchCountry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 60 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchState);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 61 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchLocalGovt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 62 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 63 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.BranchContactPerson);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 64 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                           Write(branch.ContactPersonNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 66 "C:\Users\HI\Documents\HelpersNetwork\Views\Home\Branches.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n        <!-- /.card-body -->\r\n    </div>\r\n    <!-- /.card -->\r\n</div>\r\n<!-- /.col -->\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n\r\n    <script>\r\n\r\n        $(\".nav-link7\").css(\"color\", \"#4ac9f0\");\r\n    </script>\r\n    ");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IOrderedQueryable<HelpersNetworkBranchesTb>> Html { get; private set; }
    }
}
#pragma warning restore 1591
