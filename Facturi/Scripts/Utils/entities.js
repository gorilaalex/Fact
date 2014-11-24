
function Company() {
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
};

function Product() {
    var self = this;
    self.Id = ko.observable();

    self.init = function (data) {

    };
    return self;
};
function User() {
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
        console.log(self.Username());
    };
};

function FactModel() {
    var self = this;
    // products, firma care cumpara , data la care a fost creata, 
};


