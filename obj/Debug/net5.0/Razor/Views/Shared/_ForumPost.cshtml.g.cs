#pragma checksum "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63a026225e05140e9c8680d9d944a85e78e1e472"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ForumPost), @"mvc.1.0.view", @"/Views/Shared/_ForumPost.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63a026225e05140e9c8680d9d944a85e78e1e472", @"/Views/Shared/_ForumPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5f1c74cb035fb1a883398e11c5d2c65958a8b14", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ForumPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShiftIn.Models.ForumPost>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div");
            BeginWriteAttribute("id", " id=\"", 37, "\"", 51, 1);
#nullable restore
#line 2 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
WriteAttributeValue("", 42, Model.Id, 42, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card\"");
            BeginWriteAttribute("style", " style=\"", 65, "\"", 73, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    <div class=\"card-body shadow\">\r\n        <div class=\"row\">\r\n            <div class=\"col\">\r\n                ");
#nullable restore
#line 7 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
           Write(await Html.PartialAsync("_ProfilePublic", Model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col col-md-auto\">\r\n                <p");
            BeginWriteAttribute("class", " class=\"", 330, "\"", 338, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
                       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n\r\n\r\n        </div>\r\n        <div class=\"row m-2\">\r\n            <p class=\"lead\">");
#nullable restore
#line 17 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
                       Write(Html.DisplayFor(model => model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col text-center\">\r\n                <input type=\"button\" value=\"Reply\"");
            BeginWriteAttribute("onclick", " onclick=\"", 664, "\"", 690, 3);
            WriteAttributeValue("", 674, "reply(", 674, 6, true);
#nullable restore
#line 22 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
WriteAttributeValue("", 680, Model.Id, 680, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 689, ")", 689, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"w-auto btn btn btn-dark btn-outline-primary\">\r\n                <input type=\"button\" value=\"Like\"");
            BeginWriteAttribute("onclick", " onclick=\"", 795, "\"", 822, 3);
            WriteAttributeValue("", 805, "upvote(", 805, 7, true);
#nullable restore
#line 23 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
WriteAttributeValue("", 812, Model.Id, 812, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 821, ")", 821, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"w-auto btn btn btn-dark btn-outline-success\">\r\n                <input type=\"button\" value=\"View Replies\"");
            BeginWriteAttribute("onclick", " onclick=\"", 935, "\"", 967, 3);
            WriteAttributeValue("", 945, "LoadReplies(", 945, 12, true);
#nullable restore
#line 24 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
WriteAttributeValue("", 957, Model.Id, 957, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 966, ")", 966, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""w-auto btn btn btn-dark btn-outline-info"">
            </div>
            <div class=""col col-md-auto"">
                <div class=""row"">
                   
                    <!--Insert Icon-->
                    <svg height=""25"" width=""25"" version=""1.1"" id=""fi_841556"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" x=""0px"" y=""0px"" viewBox=""0 0 512 512"" style=""enable-background:new 0 0 512 512;"" xml:space=""preserve"">
<g>
                    <g>
                    <path d=""M256,16C114.841,16,0,130.393,0,271c0,92.292,50.749,177.785,132.442,223.116c2.227,1.236,4.731,1.884,7.278,1.884h232.56
			c2.546,0,5.051-0.648,7.278-1.884C461.251,448.784,512,363.292,512,271C512,130.393,397.159,16,256,16z M368.332,466H143.668
			C73.451,425.504,30,351.14,30,271C30,146.935,131.383,46,256,46s226,100.935,226,225C482,351.14,438.549,425.503,368.332,466z""></path>
	</g>
</g>
<g>
                    <g>
                    <path d=""M395.052,134.439c-0.361-0.457-1.562-1.757-2.");
            WriteLiteral(@"492-2.492C357.355,97.367,309.129,76,256,76
			c-53.129,0-101.355,21.367-136.56,55.947c-0.93,0.735-1.758,1.563-2.492,2.492C82.367,169.645,61,217.871,61,271
			c0,8.284,6.716,15,15,15h60c8.284,0,15-6.716,15-15s-6.716-15-15-15H91.689c3.101-34.25,16.707-65.512,37.571-90.527
			l31.281,31.281c2.929,2.929,6.767,4.393,10.606,4.393c3.838,0,7.678-1.465,10.606-4.393c5.858-5.858,5.858-15.355,0-21.213
			l-31.281-31.281c24.049-20.058,53.871-33.407,86.572-37.165C228.159,147.269,211,226.705,211,241c0,24.813,20.187,45,45,45
			s45-20.187,45-45c0-14.296-17.161-93.737-26.046-133.91c32.703,3.757,62.527,17.108,86.577,37.166l-31.284,31.285
			c-5.858,5.858-5.858,15.355,0,21.213c2.929,2.929,6.768,4.393,10.606,4.393c3.838,0,7.678-1.465,10.606-4.393l31.285-31.286
			c20.864,25.016,34.48,56.278,37.579,90.532H376c-8.284,0-15,6.716-15,15s6.716,15,15,15h60c8.284,0,15-6.716,15-15
			C451,217.871,429.633,169.645,395.052,134.439z M256,256c-8.271,0-15-6.729-15-14.995c0.045-6.297,6.489-39.454,15-79.69
			c8.511,40.236,14.955,73.392");
            WriteLiteral(@",15,79.69C270.998,249.273,264.27,256,256,256z""></path>
	</g>
</g>
<g>
                    <g>
                    <path d=""M286,346h-60c-24.813,0-45,20.187-45,45s20.187,45,45,45h60c24.813,0,45-20.187,45-45S310.813,346,286,346z M286,406h-60
			c-8.271,0-15-6.729-15-15s6.729-15,15-15h60c8.271,0,15,6.729,15,15S294.271,406,286,406z""></path>
	</g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
<g>
</g>
</svg>

                    <p>Likes : ");
#nullable restore
#line 90 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Shared\_ForumPost.cshtml"
                          Write(Model.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p class=\"m-1\">Likes</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        \r\n    </div>\r\n\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShiftIn.Models.ForumPost> Html { get; private set; }
    }
}
#pragma warning restore 1591
