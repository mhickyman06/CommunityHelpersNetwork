#pragma checksum "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d72684979c3584ad9e6edad50f7b93d854939803"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListProjectVideos_Index), @"mvc.1.0.view", @"/Views/ListProjectVideos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d72684979c3584ad9e6edad50f7b93d854939803", @"/Views/ListProjectVideos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9497bc13e4b77008064841e4ae31c9c37e1b2ed", @"/Views/_ViewImports.cshtml")]
    public class Views_ListProjectVideos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagingList<YouTubeVideoDetails>>
    {
        private global::AspNetCore.Views_ListProjectVideos_Index.__Generated__PagerViewComponentTagHelper __PagerViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateProjectVideo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administrator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-3 mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateProjectVideo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
  
    ViewData["Title"] = "List Project Videos";

    Layout = "_AdministratorPortalLayout";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    .card{\r\n        padding-left:0;\r\n        padding-right:0\r\n    }\r\n</style>\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"mt-5\">\r\n        <div>\r\n            <h3>Project Videos</h3>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d72684979c3584ad9e6edad50f7b93d8549398036612", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div class=\"row mt-5\">\r\n");
#nullable restore
#line 23 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                 foreach (var gallery in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card col-lg-3 col-md-4 col-sm-6 col-xs-12\"");
            BeginWriteAttribute("id", " id=\"", 627, "\"", 654, 2);
            WriteAttributeValue("", 632, "col_", 632, 4, true);
#nullable restore
#line 26 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
WriteAttributeValue("", 636, gallery.InbuiltId, 636, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"card-header\">\r\n                            <p>");
#nullable restore
#line 28 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                          Write(gallery.PublicationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"card-body\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 881, "\"", 905, 1);
#nullable restore
#line 31 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
WriteAttributeValue("", 888, gallery.VideoUrl, 888, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d72684979c3584ad9e6edad50f7b93d8549398039627", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                                                                       WriteLiteral(gallery.ThumbnailPath);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 31 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                            <div class=\"mt-2\">\r\n                                <p>");
#nullable restore
#line 33 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                              Write(gallery.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 34 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                              Write(gallery.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"card-footer\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d72684979c3584ad9e6edad50f7b93d85493980312563", async() => {
                WriteLiteral("<i class=\"fa fa-edit\" aria-hidden=\"true\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                                                                                                                               WriteLiteral(gallery.InbuiltId);

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
            WriteLiteral("\r\n                            <a class=\"btn btn-danger  btn-sm\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1555, "\"", 1600, 3);
            WriteAttributeValue("", 1565, "ConfirmDelete(\'", 1565, 15, true);
#nullable restore
#line 39 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
WriteAttributeValue("", 1580, gallery.InbuiltId, 1580, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1598, "\')", 1598, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\" fas fa-trash-alt\"></i>\r\n                            </a>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 44 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""modal fade"" id=""myModal"">
                    <div class=""modal-dialog"">
                        <div class=""modal-content"">
                            <div class=""modal-header"">
                                <h3 class=""modal-title"">Delete ProjectPhoto</h3>
                                <a href=""#"" style=""margin-left:auto"" class=""close"" data-dismiss=""modal"">&times;</a>
                            </div>
                            <div class=""modal-body"">
                                <h4 class=""modal-bodycontent"">Are you sure you want to remove this Project Photo?</h4>
                            </div>
                            <div class=""modal-footer"">
                                <a href=""#"" class=""btn btn-default"" data-dismiss=""modal"">Cancel</a>
                                <a href=""#"" class=""btn btn-success"" onclick=""DeleteNews()"">Confirm</a>
                            </div>
                        </div>
                    </div>
          ");
            WriteLiteral("      </div>\r\n                <input type=\"hidden\" id=\"hiddennewsid\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"mt-5 text-center\">\r\n        <nav aria-label=\"ListProjectVideos navigation example\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d72684979c3584ad9e6edad50f7b93d85493980317457", async() => {
            }
            );
            __PagerViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_ListProjectVideos_Index.__Generated__PagerViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__PagerViewComponentTagHelper);
#nullable restore
#line 68 "C:\Users\HI\Documents\HelpersNetwork\Views\ListProjectVideos\Index.cshtml"
__PagerViewComponentTagHelper.pagingList = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("paging-list", __PagerViewComponentTagHelper.pagingList, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </nav>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var ConfirmDelete = function (NewsId) {
            $(""#hiddennewsid"").val(NewsId);
            $(""#myModal"").modal('show');
        }

        var DeleteNews = function () {
            var newsid = $(""#hiddennewsid"").val();
            $.ajax({
                type: ""POST"",
                url: ""/api/Administrator/DeleteProjectVideos"",
                data: {
                    ""Id"": newsid
                },
                success: function (result) {
                    $(""#myModal"").modal(""hide"");
                    $(""#col_"" + newsid).remove();
                }
            })
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagingList<YouTubeVideoDetails>> Html { get; private set; }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:pager")]
        public class __Generated__PagerViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__PagerViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public ReflectionIT.Mvc.Paging.IPagingList pagingList { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Pager", new { pagingList });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
