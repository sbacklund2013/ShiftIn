#pragma checksum "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12561f02447d0d021fd6af3e0a80850c6344a77d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Details), @"mvc.1.0.view", @"/Views/Profiles/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12561f02447d0d021fd6af3e0a80850c6344a77d", @"/Views/Profiles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5f1c74cb035fb1a883398e11c5d2c65958a8b14", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShiftIn.Models.Profile>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row py-5 px-4"">
    <div class=""col-md-5 mx-auto"">
        <div class=""bg-white shadow rounded overflow-hidden"" style=""padding-top:4px;"">
            <div class=""px-4 pt-0 pb-4 cover"">
                <div class=""media align-items-end profile-head"">
                    <div class=""profile mr-3""><img");
            BeginWriteAttribute("src", " src=\"", 395, "\"", 439, 1);
#nullable restore
#line 12 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
WriteAttributeValue("", 401, Html.DisplayFor(model=>model.Picture), 401, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\" width=\"190\" class=\"rounded mb-2 img-thumbnail\"></div>\r\n                    <div class=\"media-body mb-5 text-black\">\r\n                        <h4 class=\"mt-0 mb-0\"> ");
#nullable restore
#line 14 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                          Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p class=\"small mb-4\"> <i class=\"fas fa-map-marker-alt mr-2\"></i>");
#nullable restore
#line 15 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                                                                    Write(Html.DisplayFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"px-2 py-2\">\r\n                <h5 class=\"mb-0\">Interests</h5>\r\n                <div class=\"p-2 rounded shadow-sm bg-light\">\r\n");
#nullable restore
#line 23 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                     if (Model.Interests.Count != 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                         foreach (var interest in Model.Interests)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"font-weight-bold mb-0\"> ");
#nullable restore
#line 27 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                                         Write(interest.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                            <p class=\"font-italic mb-0\"> ");
#nullable restore
#line 28 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                                    Write(interest.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 29 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"py-2 px-2\">\r\n                <div class=\"d-flex align-items-center justify-content-between mb-3\">\r\n                    <h5 class=\"mb-0\">Cars</h5>\r\n                </div>\r\n\r\n");
#nullable restore
#line 38 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                 if (Model.Cars.Count != 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                     foreach (var Car in Model.Cars)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"font-weight-bold mb-0\">");
#nullable restore
#line 42 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                                     Write(Car.Year + " " + Car.Make + " " + Car.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <div class=\"profile mr-3\">\r\n");
#nullable restore
#line 44 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                             if (Car.CarImages != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                 foreach (var image in Car.CarImages)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <img");
            BeginWriteAttribute("src", " src=\"", 2188, "\"", 2207, 1);
#nullable restore
#line 48 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
WriteAttributeValue("", 2194, image.Path, 2194, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\" width=\"130\" class=\"rounded mb-2 img-thumbnail\">\r\n");
#nullable restore
#line 49 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 52 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\sback\source\repos\ShiftIn\Shiftin\Views\Profiles\Details.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShiftIn.Models.Profile> Html { get; private set; }
    }
}
#pragma warning restore 1591
