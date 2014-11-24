﻿define(['require', 'jquery', 'knockout', '../moduleB/ObjectDefinition', '../moduleA/ClientDataProxy'], function (require, $, ko) {
    var ViewModels;
    (function (ViewModels) {

        //Person View Model
        var PersonViewModel = function () {
            var self = this;
            self.Persons = ko.observableArray();
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
            };
            return self;
        };

        var UserViewModel = function () {
            var self = this;

            return self;
        };

        var LoginViewModel = function () {
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

            return self;
        };

        ViewModels.PersonViewModel = PersonViewModel;
        ViewModels.UserViewModel = UserViewModel;

    })(ViewModels || (ViewModels = {}));

    return ViewModels;
});