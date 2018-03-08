// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import App from './App'
import router from './router'
import '../static/fonticon/iconfont.css'
import '../static/fonticon/iconfont.js'
import VueResourse from 'vue-resource'
import echarts from 'echarts'

Vue.use(ElementUI)
Vue.use(echarts)
Vue.use(VueResourse)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
