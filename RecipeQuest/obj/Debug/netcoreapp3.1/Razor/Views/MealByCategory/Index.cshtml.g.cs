#pragma checksum "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44aa9ac40aa0b0eff3deac70b42ba4cc8d50ee5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MealByCategory_Index), @"mvc.1.0.view", @"/Views/MealByCategory/Index.cshtml")]
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
#line 1 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\_ViewImports.cshtml"
using RecipeQuest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\_ViewImports.cshtml"
using RecipeQuest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44aa9ac40aa0b0eff3deac70b42ba4cc8d50ee5c", @"/Views/MealByCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aee5b8e614d0a4da1b8586f38248ad0c053656f", @"/Views/_ViewImports.cshtml")]
    public class Views_MealByCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Recipe", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
 if (ViewBag.errorMsg.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 3 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
  Write(ViewBag.errorMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 4 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\" style=\"background-color: #e9f1f4\">\r\n        <h3>Results for Category: ");
#nullable restore
#line 9 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
                             Write(ViewBag.categorySearched);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"container-fluid\" style=\"background-color: #e9f1f4\">\r\n\r\n");
#nullable restore
#line 15 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
          var i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 17 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
             foreach (MealByCategory recipe in ViewBag.displayCategoryMeals)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-3 col-md-4 col-xs-3 thumb\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44aa9ac40aa0b0eff3deac70b42ba4cc8d50ee5c5815", async() => {
                WriteLiteral("\r\n                        <figure>\r\n                            <img");
                BeginWriteAttribute("src", " src=", 685, "", 710, 1);
#nullable restore
#line 22 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
WriteAttributeValue("", 690, recipe.StrMealThumb, 690, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width:90%; height:90%\">\r\n\r\n                            <figcaption>");
#nullable restore
#line 24 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
                                   Write(recipe.StrMeal);

#line default
#line hidden
#nullable disable
                WriteLiteral("</figcaption>\r\n                        </figure>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-mealid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
                                                                WriteLiteral(recipe.IdMeal);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["mealid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-mealid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["mealid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"

                i = i + 1;

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
                 if (i > 0 && i % 4 == 0)
                {
                    // close the div and start again

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            WriteLiteral("</div><div class=\"row\">\r\n");
#nullable restore
#line 35 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"




                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 45 "C:\Users\rmwil\source\projects\RecipeQuest\RecipeQuest\Views\MealByCategory\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591