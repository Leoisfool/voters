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
import axios from 'axios'
import VueAxios from 'vue-axios'
import Vuex from 'vuex'
import echarts from 'echarts'
Vue.prototype.$http = axios

Vue.use(Vuex)
Vue.use(VueAxios, axios)
Vue.use(ElementUI)
Vue.use(VueResourse)

Vue.config.productionTip = true

router.beforeEach((to, from, next) => {
  window.document.title = to.meta.title
  next()
})

const store = new Vuex.Store({
  state: {
    UserId: '',
    Token: '',
    loginOrReg: ''
  },
  mutations: {
    setUserId (state, userId) {
      state.UserId = userId
      sessionStorage.UserId = state.UserId
    },
    setToken (state, token) {
      state.Token = token
      sessionStorage.Token = state.Token
    },
    setLoginOrReg (state, value) {
      state.loginOrReg = value
    }
  }
})

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})
