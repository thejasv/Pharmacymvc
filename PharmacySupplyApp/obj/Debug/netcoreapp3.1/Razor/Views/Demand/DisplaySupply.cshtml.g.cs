#pragma checksum "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1595d8a7d089b5c6d3a371e3b0aaf369fcaafac2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demand_DisplaySupply), @"mvc.1.0.view", @"/Views/Demand/DisplaySupply.cshtml")]
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
#line 1 "D:\mfpeassessment\PharmacySupplyApp\Views\_ViewImports.cshtml"
using PharmacySupplyApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\mfpeassessment\PharmacySupplyApp\Views\_ViewImports.cshtml"
using PharmacySupplyApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1595d8a7d089b5c6d3a371e3b0aaf369fcaafac2", @"/Views/Demand/DisplaySupply.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4f7d2b9a9dd05595eaebdc7474da09f691e9df7", @"/Views/_ViewImports.cshtml")]
    public class Views_Demand_DisplaySupply : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PharmacySupplyApp.Models.Supply>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
  
    ViewData["Title"] = "DisplaySupply";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div class=\"container\">\n    <table class=\"table table-hover table-bordered mt-5\">\n        <thead class=\"table-success\">\n        <tr>\n            <th>\n                ");
#nullable restore
#line 13 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
           Write(Html.DisplayNameFor(model => model.PharmacyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 16 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
           Write(Html.DisplayNameFor(model => model.MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 19 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
           Write(Html.DisplayNameFor(model => model.SupplyCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n        </tr>\n        </thead>\n        <tbody>\n");
#nullable restore
#line 24 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 27 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
               Write(Html.DisplayFor(modelItem => item.PharmacyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 30 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
               Write(Html.DisplayFor(modelItem => item.MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 33 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
               Write(Html.DisplayFor(modelItem => item.SupplyCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 36 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\DisplaySupply.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PharmacySupplyApp.Models.Supply>> Html { get; private set; }
    }
}
#pragma warning restore 1591
