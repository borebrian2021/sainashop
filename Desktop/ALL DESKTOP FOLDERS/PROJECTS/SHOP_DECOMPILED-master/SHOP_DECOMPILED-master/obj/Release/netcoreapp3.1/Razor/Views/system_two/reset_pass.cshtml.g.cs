#pragma checksum "C:\Users\AMBIENT\Desktop\ALL DESKTOP FOLDERS\PROJECTS\SHOP_DECOMPILED-master\SHOP_DECOMPILED-master\Views\system_two\reset_pass.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c502cabcea9b64d2eb0936d2990ef9055df12c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_system_two_reset_pass), @"mvc.1.0.view", @"/Views/system_two/reset_pass.cshtml")]
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
#line 1 "C:\Users\AMBIENT\Desktop\ALL DESKTOP FOLDERS\PROJECTS\SHOP_DECOMPILED-master\SHOP_DECOMPILED-master\Views\_ViewImports.cshtml"
using SHOP_DECOMPILED;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AMBIENT\Desktop\ALL DESKTOP FOLDERS\PROJECTS\SHOP_DECOMPILED-master\SHOP_DECOMPILED-master\Views\_ViewImports.cshtml"
using SHOP_DECOMPILED.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c502cabcea9b64d2eb0936d2990ef9055df12c8", @"/Views/system_two/reset_pass.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff92a7f7e8cb6131c6c835eb6e87017751546d98", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_system_two_reset_pass : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hiden"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\AMBIENT\Desktop\ALL DESKTOP FOLDERS\PROJECTS\SHOP_DECOMPILED-master\SHOP_DECOMPILED-master\Views\system_two\reset_pass.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout_other.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-2""></div>
    <div class=""col-lg-8"">
        <div class=""card_log_in text-center"">
            <div class=""container-fluid text-center"">


                <p class=""text"">Reset password </p>

                <hr />

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c502cabcea9b64d2eb0936d2990ef9055df12c84396", async() => {
                WriteLiteral(@"
                    <p class=""text"">Please enter phone number that was used to create this account.An SMS code will be sent. </p>

                    <input class=""custome_input"" type=""tel"" id=""phoneNumber"" value=""+2547"" placeholder=""UserId"" />
                    <input class=""custome_input"" type=""text""  id=""code"" value=""Enter code here"" placeholder=""UserId"" />
                    <p><a href=""#"" class=""btn btn-default button-general"" id=""sign-in-button"" onclick=""submitPhoneNumberAuth()"">Send Code</a></p>
                    <p><a href=""#"" class=""btn btn-default button-general"" id=""confirm-code""  onclick=""submitPhoneNumberAuthCode()"" >Verify Code</a></p>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c502cabcea9b64d2eb0936d2990ef9055df12c86361", async() => {
                WriteLiteral("\n                    <input class=\"custome_input \" type=\"password\" placeholder=\"New password\" />\n                    <input class=\"custome_input \" type=\"password\" placeholder=\"Repeat password\" />\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            \n                <p><a href=\"#\" class=\"btn btn-default button-general\">Back to log in</a></p>\n            </div>\n        </div>\n    </div>\n    <div class=\"col-lg-2\"></div>\n</div>\n\n\n<!-- Add two inputs for \"phoneNumber\" and \"code\" -->\n");
            WriteLiteral(@"
<!-- Add two buttons to submit the inputs -->


<!-- Add a container for reCaptcha -->
<div id=""recaptcha-container""></div>

<!-- Add the latest firebase dependecies from CDN -->
<script src=""https://www.gstatic.com/firebasejs/6.3.3/firebase-app.js""></script>
<script src=""https://www.gstatic.com/firebasejs/6.3.3/firebase-auth.js""></script>

<script>
    // Paste the config your copied earlier
    var firebaseConfig = {
        apiKey: ""AIzaSyBHHJ7rQ60mD13vAs_8mH9cijhFS-w3yJY"",
        authDomain: ""sms-verification-37d5c.firebaseapp.com"",
        projectId: ""sms-verification-37d5c"",
        storageBucket: ""sms-verification-37d5c.appspot.com"",
        messagingSenderId: ""54152728260"",
        appId: ""1:54152728260:web:f2abc4fcb75be41791c391"",
        measurementId: ""G-QBHYR5NYC7""
    };

    firebase.initializeApp(firebaseConfig);

    // Create a Recaptcha verifier instance globally
    // Calls submitPhoneNumberAuth() when the captcha is verified
    window.recaptchaVerifier = new firebase.auth.RecaptchaVeri");
            WriteLiteral(@"fier(
        ""recaptcha-container"",
        {
            size: ""invisible"",
            callback: function (response) {
                submitPhoneNumberAuth();
            }
        }
    );

    // This function runs when the 'sign-in-button' is clicked
    // Takes the value from the 'phoneNumber' input and sends SMS to that phone number
    function submitPhoneNumberAuth() {
        var phoneNumber = document.getElementById(""phoneNumber"").value;
        var appVerifier = window.recaptchaVerifier;
        firebase
            .auth()
            .signInWithPhoneNumber(phoneNumber, appVerifier)
            .then(function (confirmationResult) {
                window.confirmationResult = confirmationResult;
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    // This function runs when the 'confirm-code' button is clicked
    // Takes the value from the 'code' input and submits the code to verify the phone number
    // Return a user object if ");
            WriteLiteral(@"the authentication was successful, and auth is complete
    function submitPhoneNumberAuthCode() {
        var code = document.getElementById(""code"").value;
        confirmationResult
            .confirm(code)
            .then(function (result) {
                var user = result.user;
                console.log(user);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    //This function runs everytime the auth state changes. Use to verify if the user is logged in
    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            console.log(""USER LOGGED IN"");
        } else {
            // No user is signed in.
            console.log(""USER NOT LOGGED IN"");
        }
    });
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
