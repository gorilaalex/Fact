
/// <reference path="../../lib/amplify/amplify.core.js" />
/// <reference path="ext/knockout.mapping-latest.js" />
/// <reference path="../../lib/amplify/amplify.store.js" />
define(['jquery', 'knockout','knockoutmapping', 'aes', 'amplify'], function ($, ko,mapping, aes, amplify) {
    var my = {};
    ko.mapping = mapping;
    my.init = function () {
        console.log("init utils library");
        console.log("Utils loading...");
    };

    my.bindData = function (viewModel, DOMregion) {
        console.log(viewModel);
        console.log(DOMregion);

        console.log("in data bind");
        ko.applyBindings(viewModel, DOMregion);
        console.log("out data bind");

    };
    my.ajaxLoad = function (elementId) {
        $(elementId).addClass("effect");
        $("#overlay").fadeIn();
    };
    my.ajaxDone = function (elementId) {
        $(elementId).removeClass("effect");
        $("#overlay").fadeOut();
    };
    my.postOnServer = function (model, url, successFunction) {
        //console.log(model);
        // var data = JSON.stringify(model);
         console.log(url);
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
    my.getOnServer = function (url, beforeFunction, successFunction, errorFunction, completeFunction) {
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
    },
    my.doJSONGetWithLoad = function (url, successFunction, errorFunction) {
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
    },
       my.pushOnLocaleStore = function (key, value) {
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
       },
       my.pullFromLocalStore = function (key) {
           return amplify.store(key);
       },
       
    my.redirectToUrl = function (url) {
        console.log("redirect to..." + url);
        window.location.href = url;
    },

    my.redirectToLoginAfterRegistration = function (isRegistrationOk) {
        if (isRegistrationOk) {
            window.location.href = 'login?status=registration_ok';
        }
        else {
            window.location.href = '/';
        }
    },

    //#region Encrypt/Decrypt

    my.Encrypt = function (data, key) {
        return CryptoJS.AES.encrypt(data, key);
    },

    my.Decrypt = function (data, key) {
        var decrypted = CryptoJS.AES.decrypt(y, ckey);
        return decrypted.toString(CryptoJS.enc.Utf8);
    },

    //#endregion

    my.IsValidEmailAddress = function (email) {
        var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        return pattern.test(email);
    };


    my.StyleValidationError = function (error, target) {
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
    },
    my.StyleValidationErrorForHigherInputs = function (error, target) {
        var $tooltip = target.parent().find('.tooltip-wrapper');
        if ($tooltip) $tooltip.hide();

        var $errorWrapper = $('<div class="error-wrapper-upper"></div>');
        var $errorIndicator = $('<div class="error-arrow"></div>');

        $errorWrapper.append(error);
        $errorWrapper.append($errorIndicator);

        target.before($errorWrapper);
        target.addClass('mandatory');
    }
    return my;
});
