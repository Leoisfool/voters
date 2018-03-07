import Vue from 'vue'
import Router from 'vue-router'
import Login from './../views/login.vue'
import Main from './../views/main'
import Voters from '@/views/voters'
import Register from '@/views/newregister'
import sign from '@/views/sign'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Main',
      component: Main
    },
    {
      path: '/voters',
      name: 'Voters',
      component: Voters
    },
    {
      path: '/sign',
      name: 'sign',
      component: sign,
      children: [
        {
          path: 'login',
          name: 'login',
          component: Login
        },
        {
          path: 'register',
          name: 'register',
          component: Register
        }
      ]
    }
  ]
})
