#pragma checksum "/home/tmg/VisualStudio/mvc_testing/Oficina/Oficina/Views/Funcionario/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ce05fe20bc19990416f8ffa5410939acdb9effb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_Index), @"mvc.1.0.view", @"/Views/Funcionario/Index.cshtml")]
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
#line 1 "/home/tmg/VisualStudio/mvc_testing/Oficina/Oficina/Views/_ViewImports.cshtml"
using Oficina;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/tmg/VisualStudio/mvc_testing/Oficina/Oficina/Views/_ViewImports.cshtml"
using Oficina.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ce05fe20bc19990416f8ffa5410939acdb9effb", @"/Views/Funcionario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9460c4b31f988ec05baaa1b36b3183b4ac609ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Funcionario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Oficina.Models.Funcionario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/tmg/VisualStudio/mvc_testing/Oficina/Oficina/Views/Funcionario/Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutWithSidebar.cshtml";
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"text-center\">\n  <h1>Oficina Mecânica SCC</h1> \n  Bem vindo ");
#nullable restore
#line 10 "/home/tmg/VisualStudio/mvc_testing/Oficina/Oficina/Views/Funcionario/Index.cshtml"
       Write(ViewBag.FuncionarioNome);

#line default
#line hidden
#nullable disable
            WriteLiteral("!\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Oficina.Models.Funcionario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
