/// <reference path="../Utils/fact-app-module.js" />
/// <reference path="../Utils/fact-app-navigation.js" />
/// <reference path="../Utils/utils.js" />
/// <reference path="../Utils/ext/crypto/core.js" />
/// <reference path="../Utils/ext/aes.js" />
/// <reference path="../Utils/ext/crypto/core.js" />
/// <reference path="../Utils/ext/crypto/enc-utf16.js" />
/// <reference path="../Utils/ext/crypto/enc-base64.js" />
/// <reference path="../Utils/ext/crypto/aes.js" />
/// <reference path="../Utils/ext/crypto/_referenceCrypto.js" />
function LoginViewModel() {
    var self = this;
    self.Username = ko.observable('');
    self.Password = ko.observable('');
    self.RememberMe = ko.observable(false);

    self.Challenge;
    self.Response;
    self.UseCaptcha = ko.observable(false);

    self.bindCaptcha = function () {
        self.Challenge = $("input#recaptcha_challenge_field").val();
        self.Response = $("input#recaptcha_response_field").val();
    };

    return self;
};
function LoginModule() {
    var self = this;
    self.Model = ko.observable(new LoginViewModel());
    self.Message = ko.observable();

    self.init = function () {
        console.log("login module init");
    };

    self.signUp = function () {
        Utils.redirectToUrl("/account/register");
    };

    self.initViewModel = function (data) {
        self.Model().Username(data.Username);
        self.Model().Password(data.Password);
        self.Model().RememberMe(data.RememberMe);

        self.bindValidation();
    };

    self.bindValidation = function () {
        $.validator.setDefaults({
            submitHandler: function () { }
        });

        $("#login").validate({
            rules: {
                username: {
                    required: true,
                    email: true
                },
                password: {
                    required: true
                }
            },
            messages: {
                username: {
                    email: "Please enter a valid email address.",
                    required: "Please enter a valid email address."
                },
                password: { required: "Please enter a password." }
            },
            errorElement: "div",
            errorPlacement: function (error, element) {
                Utils.StyleValidationError(error, element);
            },
            highlight: function (element, errorClass, validClass) {
            $(element).addClass('mandatory').removeClass('valid');
            },
            unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('mandatory').addClass('valid');
        }
        });
    };

    self.login = function () {
        if (!$("#login").valid()) {
            return;
        }
       // var password = Utils.Encrypt(self.Model().Password(), self.Model().Username());
        // console.log(password);
        //var encrypted = CryptoJS.AES.encrypt(self.Model().Password(), self.Model().Username());
        //  var crypto = CryptoJS.HmacSHA1(self.Model().Password(), self.Model().Username()).toString();
       //var passhash = CryptoJS.MD5(self.Model().Password()).toString();
       //self.Model().Password(passhash);

        if (self.Model().Username() != null && self.Model().Username() != ''  && self.Model().Password() != null && self.Model().Password() != '') {
            if (self.Model().RememberMe() == true) {
                Utils.pushOnLocaleStore("rememberMe", self.Model().Username());
            }
            Utils.postOnServer(self.Model(), $("#LoginUrl").val(), self.loginSuccess);
        }
    };

    self.loginSuccess = function (data) {
        if (data != null && data.IsSuccess) {
            if (self.Model().RememberMe() == true) {
                Utils.pushOnLocaleStore("rememberMe", self.Model().Username());
            }
            else {
                Utils.pushOnLocaleStore("rememberMe", null);
            }
            if (data.ReturnUrl != null) {
                Utils.redirectToUrl(data.ReturnUrl);
            }
        }
        else {
            self.Message(data.Message);
        }
    };

    return self;
};

$(document).ready(function () {

    var loginModule = new LoginModule();

    var rememberMeValue = Utils.pullFromLocalStore("rememberMe");
    if(rememberMeValue && rememberMeValue !=null )
    {
        loginModule.Model().RememberMe(true);
        loginModule.Model().Username(rememberMeValue);
        console.log(loginModule.Model().Username());
    }
    loginModule.initViewModel(loginModule.Model());

    Utils.bindData(loginModule, document.getElementById("container"));
});
