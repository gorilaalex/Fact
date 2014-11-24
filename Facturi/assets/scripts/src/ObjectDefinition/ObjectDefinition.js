define(['require', 'knockout'], function (require, ko) {
    return {

        //user definition
        User: function () {
            var self = this;
            self.Id = ko.observable();
            self.Username = ko.observable();
            self.Password = ko.observable();
            self.Email = ko.observable();
            self.FirstName = ko.observable();
            self.LastName = ko.observable();

            self.init = function (data) {
                self.Id(data.Id);
                self.Username(data.Username);
                self.Password(data.Password);
                self.Email(data.Email);
                self.FirstName(data.FirstName);
                self.LastName(data.LastName);
            };

            return self;
        },
        //company definition
        Company: function () {
            var self = this;
            self.Id = ko.observable();
            self.ContractorName = ko.observable();
            self.SerialNumber = ko.observable();
            self.CIF = ko.observable();
            self.CUI = ko.observable();
            self.IBAN = ko.observable();
            self.Bank = ko.observable();
            self.Email = ko.observable();
            self.Telephone = ko.observable();
            self.SocialCapital = ko.observable();
            self.TVARate = ko.observable();
            self.UserId = ko.observable();

            self.init = function (data) {
                self.Id(data.Id);
                self.UserId(data.UserId);
                self.ContractorName(data.ContractorName);
                self.SerialNumber(data.SerialNumber);
                self.CIF(data.CIF);
                self.CUI(data.CUI);
                self.IBAN(data.IBAN);
                self.Bank(data.Bank);
                self.Email(data.Email);
                self.Telephone(data.Telephone);
                self.SocialCapital(data.SocialCapital);
                self.TVARate(data.TVARate);
            };

            return self;
        },
        //product definition
        Product: function () {
            var self = this;

            return self;
        },

        //fact definition
        Fact: function () {
            var self = this;

            return self;
        }
    };
});