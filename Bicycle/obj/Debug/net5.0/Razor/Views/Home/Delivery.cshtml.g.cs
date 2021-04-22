#pragma checksum "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ad6d58628856533125da2d03299d7df660caefa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Delivery), @"mvc.1.0.view", @"/Views/Home/Delivery.cshtml")]
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
#line 2 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Bicycle;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Bicycle.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Bicycle.DataAccess.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Spidya\Bicycle\Bicycle\Views\_ViewImports.cshtml"
using Bicycle.Entities.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ad6d58628856533125da2d03299d7df660caefa", @"/Views/Home/Delivery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d221b9e07418c09e3784cb6e242b9dd41eefae9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Delivery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RentBicycle>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/png7-300x300.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:30%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Card image cap"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
   
    var station = ViewBag.Station;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""modal fade"" id=""myModal"" role=""dialog"">
    <div class=""modal-dialog modal-sm"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Teslim Etme</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <h4 class=""bodyMessaje""><i class=""fa fa-check alert-success""></i></h4>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default btn-warning"" data-dismiss=""modal"">Kapat</button>
            </div>
        </div>
    </div>
</div>
<div class=""col-sm-12"">
    <div class=""row ml-1"">
        <ul class=""list-group"">
            <li class=""list-group-item"">Teslim etmek istediğiniz bisikletleri onaylayın</li>
            <li class=""list-group-item""><strong>Ağ:</strong><span class=""text-black-50"">");
#nullable restore
#line 25 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
                                                                                   Write(station.Network.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </li>\r\n            <li class=\"list-group-item\"><strong>İstasyon:</strong><span class=\"text-black-50\">");
#nullable restore
#line 26 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
                                                                                         Write(station.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n            <li class=\"list-group-item\"><strong>Serbest Bisiklet:</strong><span class=\"text-black-50 FreeBikes\">");
#nullable restore
#line 27 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
                                                                                                           Write(station.FreeBikes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n            <li class=\"list-group-item\"><strong>Boş Yer:</strong><span class=\"text-black-50 EmptySlots\">");
#nullable restore
#line 28 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
                                                                                                   Write(station.EmptySlots);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"row\">\r\n        <input type=\"hidden\" class=\"stationid\"");
            BeginWriteAttribute("name", " name=\"", 1572, "\"", 1598, 1);
#nullable restore
#line 32 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
WriteAttributeValue("", 1579, ViewBag.Station.Id, 1579, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 33 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
         foreach (var bike in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-3 mt-1\">\r\n                <div class=\"card\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2ad6d58628856533125da2d03299d7df660caefa8609", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <a class=\"btn btn-warning btn-sm mt-1 delivery customlink\"");
            BeginWriteAttribute("name", " name=\"", 1925, "\"", 1940, 1);
#nullable restore
#line 38 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
WriteAttributeValue("", 1932, bike.Id, 1932, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><strong>Teslim Et</strong></a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 41 "C:\Spidya\Bicycle\Bicycle\Views\Home\Delivery.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<script>
    $("".delivery"").click(function myfunction() {
        var sid = $("".stationid"").attr(""name"");
        var rentid = $(this).attr(""name"");
        var selectedObject = $(this);
        var FreeBikes = parseInt($("".FreeBikes"").html());
        var EmptySlots = parseInt($("".EmptySlots"").html());
        $.ajax({
            type: ""GET"",
            url: ""/Home/DeliveryConfirm"",
            data: { sid: sid, rentid: rentid },
            success: function myfunction(data) {
                if (!data) {
                    $("".bodyMessaje"").html('');
                    $("".bodyMessaje"").html(""Boş yer yok ya da geçersiz işlem"");
                } else {
                    $("".bodyMessaje"").html('');
                    $("".bodyMessaje"").html(""Bisiklet teslim edildi."");
                    $("".FreeBikes"").html('');
                    $("".FreeBikes"").html(parseInt(FreeBikes + 1));
                    $("".EmptySlots"").html('');
                    $("".EmptySlots");
            WriteLiteral(@""").html(parseInt(EmptySlots - 1));
                    selectedObject.parent().parent().remove();
                }
                $(""#myModal"").modal('show');
                setTimeout(function () { $('#myModal').modal('hide'); }, 6000);
            },
            error: function myfunction() {
                alert(""Beklenmedik bir hata oluştu.Biraz sonra tekrar deneyin"");
            }
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RentBicycle>> Html { get; private set; }
    }
}
#pragma warning restore 1591