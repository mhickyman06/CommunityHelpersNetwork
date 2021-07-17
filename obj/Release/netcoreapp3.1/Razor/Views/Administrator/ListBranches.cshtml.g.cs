#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2448eadcc5fb288741dcd8212669c563d93a9def"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_ListBranches), @"mvc.1.0.view", @"/Views/Administrator/ListBranches.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2448eadcc5fb288741dcd8212669c563d93a9def", @"/Views/Administrator/ListBranches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9497bc13e4b77008064841e4ae31c9c37e1b2ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_ListBranches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IOrderedQueryable<HelpersNetworkBranchesTb>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditBranch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administrator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
  
    ViewData["Title"] = "Branch List";

    Layout = "_AdministratorPortalLayout";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-fluid"">
    <div class=""mt-5"">
        <div>
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Branch List</h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""ListBranchesTable"" class="" table table-bordered table-striped"">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Country</th>
                                <th>State</th>
                                <th>Local Government</th>
                                <th>Address</th>
                                <th>Contact Person</th>
                                <th>Contact Person Number</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 34 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                             foreach (var branch in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("id", " id=\"", 1274, "\"", 1293, 2);
            WriteAttributeValue("", 1279, "row_", 1279, 4, true);
#nullable restore
#line 36 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
WriteAttributeValue("", 1283, branch.Id, 1283, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <td>");
#nullable restore
#line 37 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchCountry);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchState);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 40 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchLocalGovt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 42 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.BranchContactPerson);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 43 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                   Write(branch.ContactPersonNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2448eadcc5fb288741dcd8212669c563d93a9def9084", async() => {
                WriteLiteral("<i class=\"fa fa-edit\" aria-hidden=\"true\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                                                                                                                                        WriteLiteral(branch.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <a class=\"btn btn-danger mb-2  btn-sm\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2122, "\"", 2159, 3);
            WriteAttributeValue("", 2132, "ConfirmDelete(\'", 2132, 15, true);
#nullable restore
#line 46 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
WriteAttributeValue("", 2147, branch.Id, 2147, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2157, "\')", 2157, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <i class=\" fas fa-trash-alt\"></i>\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 51 "C:\Users\HI\Documents\HelpersNetwork\Views\Administrator\ListBranches.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                    <div class=""modal fade"" id=""myModal"">
                        <div class=""modal-dialog"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <h3 class=""modal-title"">Delete Branch</h3>
                                    <a href=""#"" style=""margin-left:auto"" class=""close"" data-dismiss=""modal"">&times;</a>
                                </div>
                                <div class=""modal-body"">
                                    <h4 class=""modal-bodycontent"">Are you sure you want to delete this Branch?</h4>
                                </div>
                                <div class=""modal-footer"">
                                    <a href=""#"" class=""btn btn-default"" data-dismiss=""modal"">Cancel</a>
                                    <a href=""#"" class=""btn btn-success"" onclick=""DeleteNews()"">Confirm</a>
   ");
            WriteLiteral(@"                             </div>
                            </div>
                        </div>
                    </div>
                    <input type=""hidden"" id=""hiddennewsid"" />
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        $(document).ready(function () {

            //$(""#ListBranchesTable"").DataTable({
            //    ""scrollY"": ""450px"",
            //    ""scrollCollapse"": true,
            //    ""paging"": true,
            //});
        });

        var ConfirmDelete = function (NewsId) {
            $(""#hiddennewsid"").val(NewsId);
            $(""#myModal"").modal('show');
        }



        var DeleteNews = function () {

            var userid = $(""#hiddennewsid"").val();

            $.ajax({
                type: ""POST"",
                url: ""api/Administrator/DeleteBranch"",
                //dataType : ""application/json"",
                data: {
                    Id: userid
                },
                success: function (result) {

                    $(""#myModal"").modal(""hide"");
                    $(""#row_"" + userid).remove();
                    $(""#col_"" + userid).remove();
                },
                error: function (errors) {
            ");
                WriteLiteral("        console.log(errors)\r\n                }\r\n            })\r\n        }\r\n\r\n    </script>\r\n");
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
