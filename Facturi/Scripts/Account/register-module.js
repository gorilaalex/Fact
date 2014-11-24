/// <reference path="../Utils/entities.js" />
/// <reference path="../Utils/ext/crypto/_referenceCrypto.js" />

/// <reference path="../Utils/utils.js" />
function RegistrationModel() {
    var self = this;
    self.Username = ko.observable();
    self.Password = ko.observable();
    self.ConfirmPassword = ko.observable();
    self.FirstName = ko.observable();
    self.LastName = ko.observable();


    self.bindCaptcha = function () {
        self.Challenge = $("input#recaptcha_challenge_field").val();
        self.Response = $("input#recaptcha_response_field").val();
    };

    return self;
}

function RegisterModule() {
    var self = this;
    self.UserModel = ko.observable(new RegistrationModel());
    self.Message = ko.observable();
    self.init = function () {
        console.log("init");
        self.bindValidation();
    };

    self.PasswordMatch = ko.computed(function () {
        if (self.UserModel().Password() == null || self.UserModel().Password == undefined || self.UserModel().Password() == '') return false;
        return self.UserModel().Password() == self.UserModel().ConfirmPassword();
    });


    self.bindValidation = function () {
        $.validator.setDefaults({
            submitHandler: function () {
            }
        });

        $("#register").validate({
            rules: {
                username: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength: 6
                },
                confirmpassword: {
                    required: true,
                    minlength: 6
                },
                recaptcha_response_field: {
                    required: true
                }
            },
            messages: {
                username: {
                    email: "Please enter a valid email address.",
                    required: "Please enter a valid email address."
                },
                password: {
                    required: "Please enter a password.",
                    minlength: "Please enter a password of minimum 6 characters."
                },
                confirmPassword: {
                    required: "Please confirm password",
                    minlength: "Please enter a password of minimum 6 characters."
                },
                recaptcha_response_field: {
                    required: "Captcha word verification is mandatory."
                    }
            },
            errorElement: "div",
            errorPlacement: function (error, element) {
                Utils.StyleValidationError(error, element);
            }
        });
    };


    self.register = function () {
        if (!$("#register").valid()) {
            return;
        }

        if (!self.PasswordMatch()) return;
        self.UserModel().bindCaptcha();
       // CryptoJS.AES.encrypt
      //  var password = CryptoJS.AES.encrypt(self.UserModel().Password, self.UserModel().Username);
       // console.log(password);
      //  debugger;
      //  self.UserModel().Password(password);
      //  self.UserModel().ConfirmPassword(password);

       

       Utils.postOnServer(self.UserModel(), $("#RegisterUrl").val(), self.registerSuccess);

    };

    

    self.registerSuccess = function (data) {
        if (data.IsSuccess) {
            console.log("the user was registreted.");
            Utils.redirectToLoginAfterRegistration(data.IsSuccess);
        }
        else {
           self.Message("Error! " + data.Message);
        }
    };

    self.cancel = function () {
        Utils.redirectToLoginAfterRegistration(false);
    };

    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;
};

RegisterModule.getInstance = function () {
    var singletonClass = new RegisterModule();
    return singletonClass;
};