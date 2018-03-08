<template>
  <div class="login">
    <form>
      <div class="form-group">
        <i class="iconfont icon-user1"></i>
        <input type="text"  autocomplete="off" v-model="userInfo.UserName" placeholder="请输入用户名">
      </div>
      <div class="form-group">
        <i class="iconfont icon-password5"></i>
        <input type="password"  autocomplete="off" v-model="userInfo.Password" placeholder="请输入密码">
      </div>
      <div class="form-group">
        <button type="button" @click="login" class="button">登录</button>
      </div>
    </form>
    <br/>
  </div>
</template>

<script>
import qs from 'qs'
export default {
  data () {
    return {
      userInfo: {
        UserName: '',
        Password: ''
      },
      msg: 'I am login ',
      loginOutToken: ''
    }
  },
  http: {
    root: '/root',
    headers: {
      Authorization: 'Basic YXBpOnBhc3N3b3Jk'
    }
  },
  methods: {
    login: function () {
      // var formData = qs.stringify(this.userInfo)
      // this.$http
      //   .post('http://127.0.0.1:8080/webapi/login_user', formData, {
      //     headers: {
      //       'Content-Type': 'application/x-www-form-urlencoded'
      //     }
      //   })
      //   .then(res => {
      //     if (res.data.StateCode) {
      //       console.log('登录成功！')
      //       this.loginOutToken = res.data.Token
      //       console.log('Token' + res.data.Token)
      //       debugger
      //       let uxlogPath = '../uxlog/' + this.loginOutToken
      //       this.$router.push(uxlogPath)
      //     } else {
      //       console.log('密码不正确或验证码不正确或者您已经登录')
      //     }
      //   })
      this.$router.push('../voters/')
    }
  }
}
</script>

<style>
.login {
  width: 100%;
}
.form-group:first-child input {
  border-radius: 4px 4px 0 0;
}
.login div:nth-child(2) input {
  border-top: 0px;
}
.form-group .button {
  position: relative;
  width: 273px;
  height: 40px;
  padding: 4px 0px;
  top: 40px;
  border-radius: 25px;
  background-color: #3194d0;
  outline: none;
  border: 0px;
  font-size: 18px;
  color: white;
}
.form-group .button:hover {
  background-color: #187cb7;
}
@media all and (max-width: 768px) {
}
</style>
