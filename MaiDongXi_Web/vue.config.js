module.exports = {
  publicPath: '/dists/',
  outputDir: undefined,
  assetsDir: undefined,
  runtimeCompiler: undefined,
  productionSourceMap: undefined,
  parallel: undefined,
  css: undefined,
  baseUrl: '/',
    devServer: {
        proxy: {
            '/api': {
                target: 'http://www.maidongxi.xyz/',
                secure: false,  // 如果是https接口，需要配置这个参数
                changeOrigin: true, //是否跨域
                ws: true,
                pathRewrite: {
                  '^/api': ''
                }
            }
        }
    }
}