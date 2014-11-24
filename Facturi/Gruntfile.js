module.exports = function (grunt) {
    'use strict';
    // Project configuration
    grunt.initConfig({
        // Metadata
        pkg: grunt.file.readJSON('package.json'),
        banner: '/*! &lt%= pkg.name %> - v&lt;%= pkg.version %> - ' +
            '&lt;%= grunt.template.today("yyyy-mm-dd") %> */\n',
        concat: {
            options: {
                        stripBanners: true
        },
                dist: {
                    src: ['scripts/lib/jquery/jquery-*.js', '!scripts/lib/jquery/jquery-*.min.*', '!scripts/lib/jquery/jquery-*.intellisense.*', 'scripts/lib/bootstrap/bootstrap.js', 'Scripts/respond.js', 'js/**/*.js'],
                        dest: 'assets/dist/app.js'
                },
                distCss: {
                    src: ['scripts/styles/lib/bootstrap/bootstrap.css', 'scripts/styles/lib/bootstrap/bootstrap-theme.css', 'scripts/styles/lib/bootstrap/bootstrap-responsive.css', 'scripts/styles/src/app.css'],
                        dest: 'assets/dist/app.css'
                }
        },
        uglify: {
            options: {
                banner: '<%= banner %>',
                compress: {
                    drop_console: true
                }
            },
            dist: {
                src: ['<%= concat.dist.dest %>'],
                dest: 'assets/dist/app.min.js'
            }
        },
        cssmin: {
            dist: {
                src: ['<%= concat.distCss.dest %>'],
                dest: 'assets/dist/app.min.css'
            }
        }
    });

    // These plugins provide necessary tasks
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    // Default task
    grunt.registerTask('default', ['concat', 'uglify', 'cssmin']);
};