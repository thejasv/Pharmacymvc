#pragma checksum "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93ff96a6d78a979672834a21a48cd5f82a9c3cfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demand_Index), @"mvc.1.0.view", @"/Views/Demand/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93ff96a6d78a979672834a21a48cd5f82a9c3cfe", @"/Views/Demand/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4f7d2b9a9dd05595eaebdc7474da09f691e9df7", @"/Views/_ViewImports.cshtml")]
    public class Views_Demand_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<PharmacySupplyApp.Models.MedicineDemand>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n    <div class=\"row justify-content-center mx-5 mt-5 md-3\">\n        <div class=\"col-4\">\n            <b>");
#nullable restore
#line 10 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
          Write(Html.DisplayNameFor(model=>model[0].MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\n        </div>\n        <div class=\"col-4\">\n            <b>");
#nullable restore
#line 13 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
          Write(Html.DisplayNameFor(model=>model[0].Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\n        </div>\n    </div>\n");
#nullable restore
#line 16 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
     using(Html.BeginForm("Index"))
    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
 for (int i=0;i<Model.ToList().Count;i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row justify-content-center mx-5 my-1\">\n        <div class=\"col-4\">\n            ");
#nullable restore
#line 22 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
       Write(Html.DisplayFor(m=> Model[i].MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 23 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
       Write(Html.HiddenFor(m => Model[i].MedicineName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n        <div class=\"col-4\">\n            ");
#nullable restore
#line 26 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
       Write(Html.EditorFor(m=>Model[i].Count,new {htmlAttributes = new {min=0}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n    </div>\n");
#nullable restore
#line 29 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row justify-content-center m-3"">
            <div class=""col-3"">
                <div class=""form-group"">
                    <input type=""submit"" value=""Submit"" class=""btn btn-success"" />
                </div>
            </div>
        </div>
");
#nullable restore
#line 37 "D:\mfpeassessment\PharmacySupplyApp\Views\Demand\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<PharmacySupplyApp.Models.MedicineDemand>> Html { get; private set; }
    }
}
#pragma warning restore 1591
