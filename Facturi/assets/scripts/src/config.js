require.config({
    baseUrl: 'assets/scripts/src',
    paths: {
        jquery: './../lib/jquery/jquery-1.9.1',
        knockout: './../lib/knockout/knockout-2.2.0',
        templates: '../../templates',
        data: '../../data s'
    },
    shim: {
        jquery: {
            exports: '$'
        },
        knockout: {
            exports: 'ko'
        }
    }
});