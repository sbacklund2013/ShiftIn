#pragma checksum "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d8a68baf3018e04e62ffd5ab9faf8aa995377cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ForumPosts_LoadThread), @"mvc.1.0.view", @"/Views/ForumPosts/LoadThread.cshtml")]
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
#line 1 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\_ViewImports.cshtml"
using Shiftin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\_ViewImports.cshtml"
using Shiftin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d8a68baf3018e04e62ffd5ab9faf8aa995377cc", @"/Views/ForumPosts/LoadThread.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5f1c74cb035fb1a883398e11c5d2c65958a8b14", @"/Views/_ViewImports.cshtml")]
    public class Views_ForumPosts_LoadThread : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShiftIn.Models.ForumPost>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_UpvoteScriptpartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ReplyScriptspartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LikeScripts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_LoadReplyScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
  
    ViewData["Title"] = "Thread View";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var author = ViewBag.post.Author;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\"");
            BeginWriteAttribute("style", " style=\"", 198, "\"", 206, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    <div class=\"card-body\">\r\n        <div class=\"row\">\r\n            <div class=\"col\">\r\n                <h3>\r\n                    ");
#nullable restore
#line 14 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
               Write(ViewBag.post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h3>\r\n                <p>\r\n                    ");
#nullable restore
#line 17 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
               Write(ViewBag.post.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n\r\n\r\n        </div>\r\n\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col\">\r\n                <h6>By: ");
#nullable restore
#line 27 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
                   Write(ViewBag.post.Author.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <input type=\"button\" value=\"Reply\"");
            BeginWriteAttribute("onclick", " onclick=\"", 680, "\"", 713, 3);
            WriteAttributeValue("", 690, "reply(", 690, 6, true);
#nullable restore
#line 28 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
WriteAttributeValue("", 696, ViewBag.post.Id, 696, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 712, ")", 712, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"w-auto btn btn-sm btn-outline-dark\">\r\n                <input type=\"button\" value=\"Like\"");
            BeginWriteAttribute("onclick", " onclick=\"", 809, "\"", 843, 3);
            WriteAttributeValue("", 819, "upvote(", 819, 7, true);
#nullable restore
#line 29 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
WriteAttributeValue("", 826, ViewBag.post.Id, 826, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 842, ")", 842, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"w-auto btn btn-sm btn-outline-dark\">\r\n\r\n            </div>\r\n        </div>\r\n        <hr />\r\n\r\n");
#nullable restore
#line 35 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
       Write(await Html.PartialAsync("_ForumPost", item));

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\sback\source\repos\Shiftin\Shiftin\Views\ForumPosts\LoadThread.cshtml"
                                                        

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d8a68baf3018e04e62ffd5ab9faf8aa995377cc7942", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d8a68baf3018e04e62ffd5ab9faf8aa995377cc9063", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d8a68baf3018e04e62ffd5ab9faf8aa995377cc10188", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2d8a68baf3018e04e62ffd5ab9faf8aa995377cc11318", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShiftIn.Models.ForumPost>> Html { get; private set; }
    }
}
#pragma warning restore 1591
