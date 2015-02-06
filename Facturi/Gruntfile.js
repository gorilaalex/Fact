module.exports = function (grunt) {
    'use strict';
    // Project configuration
    grunt.initConfig({
        // Metadata
        pkg: grunt.file.readJSON('package.json'),
        clean: ["assets/dist*"],
        concat: {
            options: {
                stripBanners: true,
                banner: '/*! <%= pkg.name %> - v<%= pkg.version %> - ' +
        '<%= grunt.template.today("yyyy-mm-dd") %> */',
                separator: ';',
                },
                dist: {
                    src: ['assets/scripts/lib/jquery/jquery-*.js', '!assets/scripts/lib/jquery/jquery-*.min.*', '!assets/scripts/lib/jquery/jquery-*.intellisense.*', 'assets/scripts/lib/bootstrap/bootstrap.js',
                        'assets/scripts/lib/jquery/jquery.validate.js', 'assets/scripts/lib/jquery/jquery.validate.unobtrusive.js',
                        'assets/scripts/lib/aes/aes.js', 'assets/scripts/lib/amplify/amplify.*.js', 'assets/scripts/lib/knockout/knockout-*.js',
                        'assets/scripts/lib/knockout/knockout.mapping-latest.js', 'assets/scripts/lib/modernizr/modernizr-*.js',
                        'assets/scripts/lib/moment/moment.js', 'assets/scripts/lib/notify/notify.js', 'assets/scripts/lib/sammy/sammy-latest.js',
                        'assets/scripts/lib/select/select2.js',
                        'js/**/*.js'],
                        dest: 'assets/dist/app.js'
                },
                distCss: {
                    src: ['assets/styles/lib/bootstrap/bootstrap-*.css', 'assets/styles/lib/bootstrap/bootstrap.css',
                    'assets/styles/src/app.css', ],
                    dest: 'assets/dist/app-style.css'
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
            minify: {
                expand: true,
                src: ['<%= concat.distCss.dest %>'],
                dest: '',
                ext: '.min.css'
            }
},
        imagemin: {
            dynamic: {
                files: [{
                    expand: true,
                    cwd: 'assets/images/',
                    src: ['**/*.{png,jpg,gif}'],
                    dest: 'assets/dist/images/'
                }]
            }
        },
        watch: {
            scripts: {
                files: ['assets/scripts/src/*.js'],
                tasks: ['concat', 'uglify'],
                options: {
                    spawn: false,
                    reload: true,
                    dateFormat: function (time) {
                        grunt.log.writeln('The watch finished in ' + time + 'ms at' + (new Date()).toString());
                        grunt.log.writeln('Waiting for more changes...');
                    },
                        event: ['added', 'deleted'],
                },
            }
        },
        cachebreaker: {
            dev: {
                options: {
                    match: ['build_<%= pkg.version %>/config.js'],
                    replacement: 'md5',
                    src: {
                        path: 'assets/scripts/src/config.js'
                    }
                },
                files: {
                    src: ['index.html']
                }
            }
        }

    });

    // These plugins provide necessary tasks
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-remove-logging');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-string-replace');
    grunt.loadNpmTasks('grunt-cache-breaker');

    grunt.loadNpmTasks('grunt-contrib-imagemin');

    grunt.loadNpmTasks('grunt-contrib-watch');

    // Default task
    grunt.registerTask('default', ['clean','concat','uglify' ,'cssmin','imagemin','watch']);
};