#pragma checksum "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_LoadReplyScriptsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14150e00004d8165d5193e9eac8ea4075c005854"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoadReplyScriptsPartial), @"mvc.1.0.view", @"/Views/Shared/_LoadReplyScriptsPartial.cshtml")]
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
#line 1 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\_ViewImports.cshtml"
using Shiftin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\_ViewImports.cshtml"
using Shiftin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14150e00004d8165d5193e9eac8ea4075c005854", @"/Views/Shared/_LoadReplyScriptsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5f1c74cb035fb1a883398e11c5d2c65958a8b14", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoadReplyScriptsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script type=\"text/javascript\">\r\n    function LoadReplies(pid) {\r\n        $.ajax({\r\n            async: true,\r\n            data: {\r\n                id: pid\r\n            },\r\n            type: \"POST\",\r\n            url: \"");
#nullable restore
#line 9 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_LoadReplyScriptsPartial.cshtml"
             Write(Url.Action("LoadReplies"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            success: function (partialView) {\r\n                $(\'#\' + pid).append(partialView);\r\n            }\r\n        });\r\n    };\r\n</script>");
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
