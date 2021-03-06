﻿
/// <reference path="ext/knockout.mapping-latest.js" />

define(['require', 'knockout', 'aes'], function (require, ko) {

    return {
        Utils: function () {
            var self = this;
            self.bindData = function (viewModel, DOMregion) {
                ko.applyBindings(viewModel, DOMregion);
            };
            self.IsValidEmailAddress = function (email) {
                var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                return pattern.test(email);
            };

            self.ajaxLoad = function (elementId) {
                $(elementId).addClass("effect");
                $("#overlay").fadeIn();
            };

            self.ajaxDone = function (elementId) {
                $(elementId).removeClass("effect");
                $("#overlay").fadeOut();
            };

            self.postOnServer = function (model, url, successFunction) {
                //console.log(model);
                // var data = JSON.stringify(model);
                // console.log(data);
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: ko.mapping.toJSON(model),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () { },
                    success: function (data) {
                        successFunction(data);
                    },
                    error: function (error) {
                        console.log(error);
                    },
                });
            };

            self.getOnServer = function (url, beforeFunction, successFunction, errorFunction, completeFunction) {
                $.ajax({
                    url: url,
                    type: 'GET',
                    dataType: "json",
                    beforeFunction: function () {
                        if (beforeFunction) {
                            beforeFunction();
                        }
                    },
                    success: function (data) {
                        successFunction(data);
                    },
                    error: function (error) {
                        if (errorFunction) {
                            errorFunction();
                        }
                    },
                    complete: function () {
                        if (completeFunction) {
                            completeFunction();
                        }
                    }
                });
            };
            self.doJSONGetWithLoad = function (url, successFunction, errorFunction) {
                $.ajax({
                    url: url,
                    type: 'GET',
                    dataType: "json",
                    beforeSend: function () {
                        Utils.ajaxLoad("html");
                    },
                    success: function (data) {
                        if (successFunction) successFunction(data);
                    },
                    error: function (error) {
                        if (errorFunction) errorFunction();
                    },
                    complete: function () {
                        Utils.ajaxDone("html");
                    }
                });
            };
            self.pushOnLocaleStore = function (key, value) {
                try {
                    amplify.store(key, value);
                }
                catch (error) {
                    amplify.store(key, null);
                    try {
                        amplify.store(key, value);
                    }
                    catch (error) {
                        alert(error);
                    }
                }
            };
            self.pullFromLocalStore = function (key) {
                return amplify.store(key);
            };

            self.redirectToUrl = function (url) {
                window.location.href = url;
            };

            self.redirectToLoginAfterRegistration = function (isRegistrationOk) {
                if (isRegistrationOk) {
                    window.location.href = 'login?status=registration_ok';
                }
                else {
                    window.location.href = '/';
                }
            };
            //#region Encrypt/Decrypt

            self.Encrypt = function (data, key) {
                return CryptoJS.AES.encrypt(data, key);
            }

            self.Decrypt = function (data, key) {
                var decrypted = CryptoJS.AES.decrypt(y, ckey);
                return decrypted.toString(CryptoJS.enc.Utf8);
            }

            //#endregion


            self.StyleValidationError = function (error, target) {
                var $tooltip = target.parent().find('.tooltip-wrapper');
                if ($tooltip) $tooltip.hide();

                var $errorWrapper = $('<div class="error-wrapper"></div>');
                var $errorIndicator = $('<div class="error-arrow"></div>');

                $errorWrapper.append(error);
                $errorWrapper.append($errorIndicator);

                //var $dk_container = target.parent().find('.dk_container');
                //if ($dk_container) $dk_container.addClass('mandatory');

                target.before($errorWrapper);
                target.addClass('mandatory');
            };

            self.StyleValidationErrorForHigherInputs = function (error, target) {
                var $tooltip = target.parent().find('.tooltip-wrapper');
                if ($tooltip) $tooltip.hide();

                var $errorWrapper = $('<div class="error-wrapper-upper"></div>');
                var $errorIndicator = $('<div class="error-arrow"></div>');

                $errorWrapper.append(error);
                $errorWrapper.append($errorIndicator);

                target.before($errorWrapper);
                target.addClass('mandatory');
            };

            return self;

        },
        PasswordStrength: function () {
            var self = this;
            self.Password = koPassword;
            self.Is8CharactersLong = ko.computed(function () {
                if (self.Password() != null) {
                    return self.Password().length >= 8;
                }
                return false;
            });
            var regExSpaces = /^$|\s+/;
            self.HasNoSpaces = ko.computed(
                function () {
                    if (self.Password() != null) {
                        return !regExSpaces.test(self.Password());
                    }
                    return false;
                });
            var regDigit = /^(?=.*\d)/;
            self.ContainsOneDigit = ko.computed(function () {
                if (self.Password() != null) {
                    return regDigit.test(self.Password());
                }
                return false;
            })
            var lowerLetter = /[a-z]/;
            self.ContainsOneLowerLetter = ko.computed(function () {
                if (self.Password() != null) {
                    return lowerLetter.test(self.Password());
                }
                return false;
            });
            var upperLetter = /[A-Z]/
            self.ContainsOneUpperLetter = ko.computed(function () {
                if (self.Password() != null) {
                    return upperLetter.test(self.Password());
                }
                return false;
            });

            self.IsPasswordWarningMessageOn = ko.observable(false);
            self.IsPasswordHelperOn = ko.observable(false);
            self.showPasswordHelp = function () {
                self.IsPasswordHelperOn(true);
            };
            self.hidePasswordHelp = function () {
                self.IsPasswordHelperOn(false);
            };
            self.togglePasswordHelp = function () {
                self.IsPasswordHelperOn(!self.IsPasswordHelperOn());
            };

            self.isValid = function () {
                if (self.Is8CharactersLong() == false) {
                    return false;
                }
                if (self.HasNoSpaces() == false) {
                    return false;
                }
                if (self.ContainsOneDigit() == false) {
                    return false;
                }
                if (self.ContainsOneLowerLetter() == false) {
                    return false;
                }
                if (self.ContainsOneUpperLetter() == false) {
                    return false;
                }
                return true;
            }

            return self;
        }
    };
});