#pragma checksum "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c93fed2c0a3b09455fd051195064fcb439433058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Edit_Views_Profile_Friends), @"mvc.1.0.view", @"/Areas/Edit/Views/Profile/Friends.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Edit/Views/Profile/Friends.cshtml", typeof(AspNetCore.Areas_Edit_Views_Profile_Friends))]
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
#line 1 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using MeetMe.Web;

#line default
#line hidden
#line 2 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using MeetMe.Web.Models;

#line default
#line hidden
#line 3 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using MeetMe.Data.Models;

#line default
#line hidden
#line 4 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 5 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using MeetMe.Web.Areas.Edit.Models;

#line default
#line hidden
#line 6 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\_ViewImports.cshtml"
using MeetMe.Data.Models.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c93fed2c0a3b09455fd051195064fcb439433058", @"/Areas/Edit/Views/Profile/Friends.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34925d623053b34953179de3da8856883f600829", @"/Areas/Edit/_ViewImports.cshtml")]
    public class Areas_Edit_Views_Profile_Friends : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FriendsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_NavigationMenuEditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "View", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("Background:white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-lg-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteFriend", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
  
    ViewData["Title"] = "Friends";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(115, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(121, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dff4010b35374a3891550a84dc0289b7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(165, 99, true);
            WriteLiteral("\r\n\r\n<h4 class=\"alert-warning\" style=\"text-align:center;\">Редактиране на приятелите</h4>\r\n<br />\r\n\r\n");
            EndContext();
#line 14 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
 if (Model.Friends.Count == 0)
{

#line default
#line hidden
            BeginContext(299, 99, true);
            WriteLiteral("    <div style=\"text-align:center\"><strong>Няма налични приятели във вашият списък</strong></div>\r\n");
            EndContext();
#line 17 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
}

#line default
#line hidden
            BeginContext(401, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 20 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
  
    int rowCounter = Model.Friends.Count % 5 == 0 ? (Model.Friends.Count / 5) : ((Model.Friends.Count / 5) + 1);

#line default
#line hidden
            BeginContext(526, 43, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <br />\r\n\r\n");
            EndContext();
#line 28 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
     for (int row = 0; row < rowCounter; row++)
    {

#line default
#line hidden
            BeginContext(625, 45, true);
            WriteLiteral("        <br />\r\n        <div class=\"row\">\r\n\r\n");
            EndContext();
#line 33 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
             for (int col = 0; col < 5; col++)
            {

#line default
#line hidden
            BeginContext(733, 46, true);
            WriteLiteral("                <div class=\"col-lg-2\">\r\n\r\n\r\n\r\n");
            EndContext();
#line 39 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                     if (((row * 5) + col) < Model.Friends.Count())
                    {
                        var base64 = Convert.ToBase64String(Model.Friends[(row * 5) + col].ProfilePicture);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", @base64);

#line default
#line hidden
            BeginContext(1071, 28, true);
            WriteLiteral("                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1099, "\"", 1112, 1);
#line 43 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
WriteAttributeValue("", 1105, imgSrc, 1105, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1113, 111, true);
            WriteLiteral(" style=\"width:130px; height:130px\" />\r\n                        <div><br /></div>\r\n                        <div>");
            EndContext();
            BeginContext(1224, 120, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaec7acfe4a7420989a7cf04b6f8fe71", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                                                                                             WriteLiteral(Model.Friends[(row * 5) + col].UserId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Fragment = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-fragment", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Fragment, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1344, 88, true);
            WriteLiteral("</div>\r\n                        <div class=\"alert-danger\">\r\n                            ");
            EndContext();
            BeginContext(1432, 386, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4690005b262b475a95c1b9d4c6395d07", async() => {
                BeginContext(1561, 54, true);
                WriteLiteral("\r\n                                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1615, "\"", 1661, 1);
#line 48 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
WriteAttributeValue("", 1623, Model.Friends[(row * 5) + col].UserId, 1623, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1662, 149, true);
                WriteLiteral(" name=\"FriendId\" />\r\n                                <button type=\"submit\" class=\"btn-group-sm\">Изтрий приятел</button>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1818, 112, true);
            WriteLiteral("\r\n                            <div style=\"background-color:white\"><br /></div>\r\n                        </div>\r\n");
            EndContext();
#line 53 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                    }

#line default
#line hidden
            BeginContext(1953, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 56 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"

            }

#line default
#line hidden
            BeginContext(1996, 16, true);
            WriteLiteral("        </div>\r\n");
            EndContext();
#line 59 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"

    }

#line default
#line hidden
            BeginContext(2021, 16, true);
            WriteLiteral("</div>\r\n<br />\r\n");
            EndContext();
#line 63 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
 if (Model.allPages > 1)
{

#line default
#line hidden
            BeginContext(2066, 40, true);
            WriteLiteral("    <ul class=\"pagination\">\r\n        <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2106, "\"", 2167, 1);
#line 66 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
WriteAttributeValue("", 2114, Model.currentPage == 1 ? "disabled" : string.Empty, 2114, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2168, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2169, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "375480dfc68242b780877b5d2e8e49f7", async() => {
                BeginContext(2209, 40, true);
                WriteLiteral(" <span aria-hidden=\"true\">&laquo;</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 66 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                                                                                 WriteLiteral(Model.previousPage);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2253, 19, true);
            WriteLiteral("</li>\r\n        <li>");
            EndContext();
            BeginContext(2272, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0a3497dcbf14b8d8b47848ed994e769", async() => {
                BeginContext(2314, 17, false);
#line 67 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                                                Write(Model.currentPage);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("a", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 67 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                     WriteLiteral(Model.currentPage);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2335, 18, true);
            WriteLiteral("</li>\r\n        <li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2353, "\"", 2427, 1);
#line 68 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
WriteAttributeValue("", 2361, Model.currentPage == Model.allPages ? "disabled" : string.Empty, 2361, 66, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2428, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2429, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "29db8ea15b0b469e93f57b85f88ca60c", async() => {
                BeginContext(2467, 40, true);
                WriteLiteral(" <span aria-hidden=\"true\">&raquo;</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("a", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
                                                                                                WriteLiteral(Model.nextPage);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2511, 18, true);
            WriteLiteral("</li>\r\n    </ul>\r\n");
            EndContext();
#line 70 "C:\Users\user\source\repos\MeetMeProject\MeetMe.Web\Areas\Edit\Views\Profile\Friends.cshtml"
}

#line default
#line hidden
            BeginContext(2532, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FriendsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
