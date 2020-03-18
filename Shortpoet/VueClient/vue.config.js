// const fs = require('fs')
// const path = require('path')
module.exports = {
    configureWebpack: {
      devtool: 'source-map'
    },
    // publicPath: process.env.NODE_ENV === 'production'
    //   ? '/production-sub-path/'
    //   : '/',
    devServer: {
      proxy: 'https://localhost:8080',
      // adding public seemed to do the same as
      // adding the below cmd to package.json
      // "servelocal": "vue-cli-service serve --host localhost",
      public: 'https://localhost:8080/',
      port: 8080, // CHANGE YOUR PORT HERE!
      https: true,
      // hotOnly: false,
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE, PATCH, OPTIONS",
        "Access-Control-Allow-Headers": "X-Requested-With, content-type, Authorization"
      }
    }
  }
  