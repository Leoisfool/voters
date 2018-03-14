import Vue from 'vue'
import Router from 'vue-router'
import Login from './../views/login.vue'
import Main from './../views/main'
import Voters from '@/views/voters'
import Register from '@/views/newregister'
import sign from '@/views/sign'
import Edit from '@/views/edit'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Main',
      meta: {
        title: 'Voters'
      },
      component: Main
    },
    {
      path: '/edit',
      name: 'edit',
      meta: {
        title: '编辑'
      },
      component: Edit
    },
    {
      path: '/voters',
      name: 'Voters',
      meta: {
        title: '投票管理'
      },
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
          meta: {
            title: '登录'
          },
          component: Login
        },
        {
          path: 'register',
          name: 'register',
          meta: {
            title: '注册'
          },
          component: Register
        }
      ]
    }
  ]
})
