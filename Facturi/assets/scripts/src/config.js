require.config({
    baseUrl: 'assets/scripts/src',
    paths: {
        jquery: './../lib/jquery/jquery-2.1.1',
        knockout: './../lib/knockout/knockout-3.2.0',
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
        knockout: {
            exports: 'ko'
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