#pragma checksum "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27a07958db34f3d54bc6a43536539556a883b930"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27a07958db34f3d54bc6a43536539556a883b930", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WedConnect>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 81, true);
            WriteLiteral("<h1>Welcome to the \"Dojo Wedding Planner!\"</h1>\n<a href=\"/logout\">Logout</a>\n\n<a>");
            EndContext();
            BeginContext(100, 17, false);
#line 5 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
Write(ViewBag.samedayrs);

#line default
#line hidden
            EndContext();
            BeginContext(117, 249, true);
            WriteLiteral("</a>\n\n<table class=\"table\">\n    <thead class=\"thead-dark\">\n      <tr>\n        <th scope=\"col\">Wedding</th>\n        <th scope=\"col\">Date</th>\n        <th scope=\"col\">Guest</th>\n        <th scope=\"col\">Action</th>\n      </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 17 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
         foreach(var i in ViewBag.AllWed){

#line default
#line hidden
            BeginContext(409, 43, true);
            WriteLiteral("            <tr>\n                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 452, "\"", 479, 2);
            WriteAttributeValue("", 459, "/detail/", 459, 8, true);
#line 19 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 467, i.WeddingId, 467, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(480, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(482, 8, false);
#line 19 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                                  Write(i.WedOne);

#line default
#line hidden
            EndContext();
            BeginContext(490, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(494, 8, false);
#line 19 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                                              Write(i.WedTwo);

#line default
#line hidden
            EndContext();
            BeginContext(502, 34, true);
            WriteLiteral("</a></td>\n                    <td>");
            EndContext();
            BeginContext(537, 9, false);
#line 20 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                   Write(i.WedDate);

#line default
#line hidden
            EndContext();
            BeginContext(546, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
            BeginContext(577, 17, false);
#line 21 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                   Write(i.WedtoUser.Count);

#line default
#line hidden
            EndContext();
            BeginContext(594, 30, true);
            WriteLiteral("</td>\n                    <td>");
            EndContext();
#line 22 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                         if(i.WedtoUser.Count == 0){

#line default
#line hidden
            BeginContext(653, 30, true);
            WriteLiteral("                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 683, "\"", 727, 4);
            WriteAttributeValue("", 690, "/addrsvp/", 690, 9, true);
#line 23 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 699, i.WeddingId, 699, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 711, "/", 711, 1, true);
#line 23 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 712, ViewBag.Userid, 712, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(728, 10, true);
            WriteLiteral(">RSVP</a>\n");
            EndContext();
#line 24 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                        }

#line default
#line hidden
            BeginContext(764, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 25 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                         if(i.WedtoUser.Count > 0)
                        {
                            int resert = 0;
                            bool rsvp = false;
                            

#line default
#line hidden
#line 29 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                             foreach(var y in i.WedtoUser){
                                

#line default
#line hidden
#line 30 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                 if(y.UserId == ViewBag.Userid){
                                    rsvp = true;
                                    resert = y.WedConnectId;
                                }

#line default
#line hidden
#line 33 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                 
                            }

#line default
#line hidden
#line 35 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                             if(rsvp == true){

#line default
#line hidden
            BeginContext(1278, 34, true);
            WriteLiteral("                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1312, "\"", 1334, 2);
            WriteAttributeValue("", 1319, "/unrsvp/", 1319, 8, true);
#line 36 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1327, resert, 1327, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1335, 13, true);
            WriteLiteral(">Un-RSVP</a>\n");
            EndContext();
#line 37 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                            }

#line default
#line hidden
#line 38 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                             if(rsvp == false){

#line default
#line hidden
            BeginContext(1426, 34, true);
            WriteLiteral("                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1460, "\"", 1504, 4);
            WriteAttributeValue("", 1467, "/addrsvp/", 1467, 9, true);
#line 39 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1476, i.WeddingId, 1476, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 1488, "/", 1488, 1, true);
#line 39 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1489, ViewBag.Userid, 1489, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1505, 10, true);
            WriteLiteral(">RSVP</a>\n");
            EndContext();
#line 40 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                            }

#line default
#line hidden
#line 40 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                             
                        }

#line default
#line hidden
            BeginContext(1571, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 43 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                     if(ViewBag.Userid == @i.UserId){

#line default
#line hidden
            BeginContext(1626, 37, true);
            WriteLiteral("                        <a> | </a> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1663, "\"", 1690, 2);
            WriteAttributeValue("", 1670, "/delete/", 1670, 8, true);
#line 44 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1678, i.WeddingId, 1678, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1691, 12, true);
            WriteLiteral(">Delete</a>\n");
            EndContext();
#line 45 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
                    }

#line default
#line hidden
            BeginContext(1725, 50, true);
            WriteLiteral("                    </td>\n                  </tr>\n");
            EndContext();
#line 48 "/Users/gmanallen/Coding Dojo/c#/entity_framework/WeddingPlanner/Views/Home/Dashboard.cshtml"
        }

#line default
#line hidden
            BeginContext(1785, 119, true);
            WriteLiteral("    </tbody>\n  </table>\n\n  <a href=\"/newwedding\"><button type=\"button\" class=\"btn btn-primary\">New Wedding</button></a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WedConnect> Html { get; private set; }
    }
}
#pragma warning restore 1591
