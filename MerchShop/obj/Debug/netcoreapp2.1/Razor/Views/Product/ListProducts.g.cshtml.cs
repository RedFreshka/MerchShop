#pragma checksum "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26e82da8a6146a107cd0ce84610ad23f3068c538"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ListProducts), @"mvc.1.0.view", @"/Views/Product/ListProducts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/ListProducts.cshtml", typeof(AspNetCore.Views_Product_ListProducts))]
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
#line 1 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\_ViewImports.cshtml"
using MerchShop;

#line default
#line hidden
#line 2 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\_ViewImports.cshtml"
using MerchShop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26e82da8a6146a107cd0ce84610ad23f3068c538", @"/Views/Product/ListProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ce5415d19715f88da0329605551bda8546351ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ListProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MerchShop.ViewModels.ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 30, true);
            WriteLiteral("<h1 style=\"text-align:center\">");
            EndContext();
            BeginContext(81, 24, false);
#line 2 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml"
                         Write(Model.ProductSubcategory);

#line default
#line hidden
            EndContext();
            BeginContext(105, 72, true);
            WriteLiteral("</h1>\r\n<div class=\"row\" style=\"display:flex; justify-content:center;\">\r\n");
            EndContext();
#line 4 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml"
      
        foreach (var item in Model.GetProducts)
        {

#line default
#line hidden
            BeginContext(243, 96, true);
            WriteLiteral("   <div class=\"card col-3\" style=\"margin-right:50px; margin-bottom:50px;\">\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 339, "\"", 356, 1);
#line 7 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml"
WriteAttributeValue("", 345, item.Image, 345, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(357, 143, true);
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\" style=\"font-size:medium\">");
            EndContext();
            BeginContext(501, 16, false);
#line 9 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml"
                                                               Write(item.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(517, 51, true);
            WriteLiteral("</h5>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 12 "C:\Users\redfreshka\source\repos\MerchShop\MerchShop\Views\Product\ListProducts.cshtml"
        }
        

#line default
#line hidden
            BeginContext(590, 6, true);
            WriteLiteral("</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MerchShop.ViewModels.ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
