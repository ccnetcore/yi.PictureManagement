module.exports = {
  publicPath:'./',
  devServer: {
    port: 6789,
    open: true,
    https: false,
    host: "localhost",
    proxy: {
      [process.env.VUE_APP_BASE_API]: {
        target: process.env.VUE_APP_SERVICE_URL,
        secure: false,
        changeOrigin: true,
        pathRewrite: {
          ["^" + process.env.VUE_APP_BASE_API]: ""
        }
      }
    }
  },
  lintOnSave: false,
  productionSourceMap: false
};
