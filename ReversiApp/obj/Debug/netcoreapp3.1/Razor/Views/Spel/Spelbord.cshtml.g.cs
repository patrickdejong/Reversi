#pragma checksum "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b356f30dab62b6ca65eee474d0ef1749c380bdb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Spel_Spelbord), @"mvc.1.0.view", @"/Views/Spel/Spelbord.cshtml")]
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
#line 1 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\_ViewImports.cshtml"
using ReversiApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\_ViewImports.cshtml"
using ReversiApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b356f30dab62b6ca65eee474d0ef1749c380bdb8", @"/Views/Spel/Spelbord.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3ef263d10da3a5aa7c5d18bc5b5dacd404439af", @"/Views/_ViewImports.cshtml")]
    public class Views_Spel_Spelbord : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReversiApp.Models.Spel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/app.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/vendor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/templates.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExitSoloGame", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditOmschrijving", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Pass", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Surrender", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExitGame", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
  
    ViewData["Title"] = "Spelbord";
    Layout = null;
    Kleur winning = Model.OverwegendeKleur();
    string winningPlayer;
    if (winning == Kleur.Zwart) {
        winningPlayer = "Black";
    } else if(winning == Kleur.Wit) {
        winningPlayer = "White";
    }
    else {
        winningPlayer = "Everyone";
    }
    bool gameEnded = Model.Afgelopen();
    if (Model.Token == "WhiteSurrenders") {
        winningPlayer = "Black";
        gameEnded = true;
    }
    if (Model.Token == "BlackSurrenders") {
        winningPlayer = "White";
        gameEnded = true;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb89258", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.js""></script>
    <meta charset=""UTF-8"">
    <title>Javascript getting started</title>
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"" integrity=""sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"" integrity=""sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp"" crossorigin=""anonymous"">
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"" integrity=""sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"" crossorigin=""anonymous""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b356f30dab62b6ca65eee474d0ef1749c380bdb810350", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b356f30dab62b6ca65eee474d0ef1749c380bdb811617", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb812888", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb813988", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb815088", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb816896", async() => {
                WriteLiteral("\r\n    <script>\r\n        (function () {\r\n            poll = function () {\r\n                Game.Reversi.showBord(\"");
#nullable restore
#line 48 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                                  Write(Model.Token);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""");
            },
                pollInterval = setInterval(function () { // run function every ... ms
                    poll();
                }, 5000);
        })();
    </script>




    <div style=""float:right;padding-right:15px;"">
        <h4>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb817791", async() => {
                    WriteLiteral("Logout");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 61 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
         if (Model.Spelers.Count < 2) {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h4>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb819267", async() => {
                    WriteLiteral("Exit match");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 63 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>
    <header style=""visibility: hidden"" id=""feedback-success"" class=""header--state-success"" role=""alert""><img src=""https://image.flaticon.com/icons/svg/1828/1828743.svg"" class=""img--icon-success""> Mike wil deelnemen aan jouw spel. Ga je akkoord? <button id=""Kruisje"" class=""button--exit"" onclick=""fadeOut()"">X</button> <button id=""Akkoord"" class=""button--accept"" onclick=""fadeOut()"">Akkoord</button> <button id=""Weigeren"" onclick=""fadeOut()"">Weigeren</button></header>

    <div style=""text-align:center"">
");
#nullable restore
#line 68 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
         if (gameEnded) {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h1>");
#nullable restore
#line 69 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
           Write(winningPlayer);

#line default
#line hidden
#nullable disable
                WriteLiteral(" won!</h1>\r\n");
#nullable restore
#line 70 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
        }
        else {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h4 style=\"align-self:center\">Currently winning: ");
#nullable restore
#line 72 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                                                        Write(winningPlayer);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 73 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>
    <div class=""canvas--class"" style=""display:inline-flex;float:left"">
        <canvas id=""myChart""></canvas>
    </div>
    <div style=""display:flex;"">
        <script>function fadeOut() { $(""header"").fadeOut(1e3) } function afterInit() { console.log(""Game init voltooid"") }</script>
        <table id=""spelbord"" style=""margin-left:15%;display:block;"">
        </table>
        <script>
            Game.Reversi.showBord(""");
#nullable restore
#line 83 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                              Write(Model.Token);

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n        </script>\r\n\r\n        <div style=\"text-align:center;margin-left:5%\">\r\n            <h3>Description: ");
#nullable restore
#line 87 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                        Write(Html.DisplayFor(modelItem => Model.Omschrijving));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3><br />\r\n");
#nullable restore
#line 88 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
             if (Model.Spelers.Count < 2) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb823876", async() => {
                    WriteLiteral("\r\n                    <input name=\"oudedef\"");
                    BeginWriteAttribute("value", " value=\"", 3808, "\"", 3835, 1);
#nullable restore
#line 90 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
WriteAttributeValue("", 3816, Model.Omschrijving, 3816, 19, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" hidden />\r\n                    <input name=\"omschrijving\" placeholder=\"A new name\" />\r\n                    <button type=\"submit\">Rename game</button>\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 94 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <h4>Turn: ");
#nullable restore
#line 96 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                 Write(Model.AandeBeurt);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n\r\n            <h3>Players:</h3>\r\n");
#nullable restore
#line 99 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
             foreach (Speler speler in Model.Spelers) {
                if (speler.Kleur == Kleur.Zwart) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <h4>Black: ");
#nullable restore
#line 101 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                          Write(Html.DisplayFor(modelItem => speler.Naam));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 102 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                }
                else if (speler.Kleur == Kleur.Wit) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <h4>White: ");
#nullable restore
#line 104 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                          Write(Html.DisplayFor(modelItem => speler.Naam));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 105 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                }
                else {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <h4>?: ");
#nullable restore
#line 107 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                      Write(Html.DisplayFor(modelItem => speler.Naam));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n");
#nullable restore
#line 108 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                }

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n    <footer>\r\n");
#nullable restore
#line 114 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
         if (gameEnded == false) {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb828775", async() => {
                    WriteLiteral("Pass");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb830095", async() => {
                    WriteLiteral("Surrender");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 117 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"

        }
        else {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b356f30dab62b6ca65eee474d0ef1749c380bdb831644", async() => {
                    WriteLiteral("Exit game");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_13.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 121 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </footer>

    <script>
        $(document).ready(function () {
            function sleep(ms) {
                return new Promise(resolve => setTimeout(resolve, ms));
            }
            sleep(1000);
            var myChart;

            Game.Stats.getBlackStones(""");
#nullable restore
#line 132 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                                  Write(Model.Token);

#line default
#line hidden
#nullable disable
                WriteLiteral("\").then(blackStonesCount => {\r\n                Game.Stats.getWhiteStones(\"");
#nullable restore
#line 133 "C:\Users\patri\Documents\GitHub\Reversi\ReversiApp\Views\Spel\Spelbord.cshtml"
                                      Write(Model.Token);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""").then(whiteStoneCount => {
                    console.log(""whiteStones = "", whiteStoneCount, "", blackStones = "" + blackStonesCount);

                    var ctx = document.getElementById('myChart').getContext('2d');
                    myChart = new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: ['White', 'Black'],
                            datasets: [{
                                label: '# of Pieces',
                                data: [whiteStoneCount, blackStonesCount],
                                backgroundColor: [
                                    'rgba(255, 255, 255, 0.8)',
                                    'rgba(0, 0, 0, 0.6)'
                                ],
                                borderColor: [
                                    'rgba(0, 0, 0, 1)',
                                    'rgba(255, 255, 255, 1)'
                                ],
                                borde");
                WriteLiteral(@"rWidth: 1
                            }]
                        },
                        options: {
                            responsive: true,
                            maintainAspectRatio: false,
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true,
                                        userCallback: function (label, index, labels) {
                                            // when the floored value is the same as the value we have a whole number
                                            if (Math.floor(label) === label) {
                                                return label;
                                            }
                                        }
                                    }
                                }]
                            }
                        }
                    });
                });


 ");
                WriteLiteral("           });\r\n        });\r\n    </script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReversiApp.Models.Spel> Html { get; private set; }
    }
}
#pragma warning restore 1591
