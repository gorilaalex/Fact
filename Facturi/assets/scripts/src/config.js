require.config({
    baseUrl: 'assets/scripts/src',
    paths: {
        jquery: './../lib/jquery/jquery-2.1.1',
        knockout: './../lib/knockout/knockout-3.2.0',
        knockoutmapping: './../lib/knockout/knockout.mapping-latest',
        jqueryvalidate: './../lib/jquery/jquery.validate',
        aes: './../lib/aes/aes',
        utils: './../src/Utils/utils',
        amplify: './../lib/amplify/amplify.store',
        templates: '../../templates',
        data: '../../data s'
    },
    shim: {
        jquery: {
            exports: '$'
        },
        jqueryvalidate: {
            exports: '$.valid()'
        },
        knockout: {
            exports: 'ko'
        },
        knockoutmapping: {
            exports: 'mapping'
        },
        aes: {
            exports: 'aes'
        },
        utils: {
            exports: 'utils'
        },
        amplify: {
            exports: 'amplify'
        }
    }
});