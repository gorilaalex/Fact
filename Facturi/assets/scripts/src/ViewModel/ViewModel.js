define(['require', 'jquery', 'knockout','utils', '../ObjectDefinition/ObjectDefinition', '../Module/ClientDataProxy'], function (require, $, ko,utils) {
    var ViewModels;
    (function (ViewModels) {
        var UserViewModel = function () {
            var self = this;
            self.Model = ko.observable(new User());
            return self;
        };
        var LoginViewModel = function () {
            var self = this;
            
            self.LoginUser = ko.observable();
            self.Init = function () {
                console.log("init login");
            };

            self.Model = ko.observable();
            self.Message = ko.observable();

            self.signUp = function () {
                window.location.href = "/account/register";
                //utils.redirectToUrl("/account/register");
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
                    }
                });
            };

            self.login = function () {
                if (!$("#login").valid()) {
                    return;
                }

                // var password = CryptoJS.AES.encrypt(self.Model().Password(), self.Model().Username());
                 console.log($("#LoginUrl").val());
                //  debugger;
                //  self.Model().Password(password);
                if (self.Model.Username != null && self.Model.Username != '' && self.Model.Password != null && self.Model.Password != '') {
                    utils.postOnServer(self.Model, $("#LoginUrl").val(), self.loginSuccess);
                }
            };

            self.loginSuccess = function (data) {
                if (data != null && data.IsSuccess) {
                    if (self.Model().RememberMe() == true) {
                        utils.pushOnLocaleStore("rememberMe", self.Model().Username());
                    }
                    else {
                        utils.pushOnLocaleStore("rememberMe", null);
                    }
                    if (data.ReturnUrl != null) {
                        //NavigationModel.getInstance().SetToDashboard();
                        window.location.href = data.ReturnUrl;
                        //FactAppModule.getInstance().init();
                    }
                }
                else {
                    self.Message(data.Message);
                }
            };

            return self;
        };

        var RegisterViewModel = function () {
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
        };

        var CompanyViewModel = function () {
            var self = this;

            return self;
        };

        var FactViewModel = function () {
            var self = this;
            /*self.Persons = ko.observableArray();
            self.Init = function () {
                var ObjectDefinition = require('./../moduleB/ObjectDefinition');
                var ClientDataProxy = require("./../moduleA/ClientDataProxy");
                var persons = ClientDataProxy.Session.getInstance().getPersons();
                var aux = ko.utils.arrayMap(persons, function (p) {
                    var person = new ObjectDefinition.Person();
                    person.init(p);
                    return person;
                });
                self.Persons.push.apply(self.Persons, aux);
            };*/
            return self;
        };

        var ProductViewModel = function () {
            var self = this;

            return self;
        };

        var Utils = function () {
            var self = this;
            self.Worker = ko.observable();

            self.Init = function () {

                var ObjectDefinition = require('./../Utils/utils');
                var ClientDataProxy = require("./../Module/ClientDataProxy");

                var utils = new Utils();
                self.Worker = utils;
                console.log(utils);
            }

            return self;
        };

        ViewModels.UserViewModel = UserViewModel;
        ViewModels.ProductViewModel = ProductViewModel;
        ViewModels.FactViewModel = FactViewModel;
        ViewModels.CompanyViewModel = CompanyViewModel;
        ViewModels.RegisterViewModel = RegisterViewModel;
        ViewModels.LoginViewModel = LoginViewModel;
        ViewModels.Utils = Utils;

    })(ViewModels || (ViewModels = {}));

    return ViewModels;
});