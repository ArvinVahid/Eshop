#pragma checksum "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c70ef9d37336c6385892f7447acb1f80eddd2149"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Components_GroupsComponent), @"mvc.1.0.view", @"/Views/Components/GroupsComponent.cshtml")]
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
#line 1 "G:\Projects\Eshop\Eshop.Web\Views\_ViewImports.cshtml"
using Eshop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\Eshop\Eshop.Web\Views\_ViewImports.cshtml"
using Eshop.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c70ef9d37336c6385892f7447acb1f80eddd2149", @"/Views/Components/GroupsComponent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"186fec18b0db8eedd013d16e579c9af50038ec0e", @"/Views/_ViewImports.cshtml")]
    public class Views_Components_GroupsComponent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Eshop.Core.Entities.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"list-group\">\r\n");
#nullable restore
#line 4 "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item d-flex justify-content-between align-items-center\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 220, "\"", 258, 4);
            WriteAttributeValue("", 227, "/Groups/", 227, 8, true);
#nullable restore
#line 7 "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml"
WriteAttributeValue("", 235, item.Id, 235, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 245, "/", 245, 1, true);
#nullable restore
#line 7 "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml"
WriteAttributeValue("", 246, item.Name, 246, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml"
                                                 Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
            WriteLiteral("        </li>\r\n");
#nullable restore
#line 10 "G:\Projects\Eshop\Eshop.Web\Views\Components\GroupsComponent.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Eshop.Core.Entities.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591