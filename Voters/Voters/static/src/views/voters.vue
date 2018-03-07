<template>
  <div>
      <button @click="loginOut">退出登录</button>
  </div>
</template>

<script>
export default {
  data () {
    return {
      Token: 'hello',
      logOutURL: 'http://127.0.0.1:8080/webapi/logout'
    }
  },
  mounted () {
    this.getParams()
  },
  methods: {
    getParams () {
      this.Token = this.$route.params.Token
    },
    loginOut () {
      this.$http.post(this.logOutURL, this.Token).then(res => {
        var stateCode = eval('(' + res.data + ')')
        if (stateCode.StateCode) {
          console.log('退出成功！')
        } else {
          console.error('出错啦！')
        }
      })
    }
  }
}
</script>

<style>
</style>
