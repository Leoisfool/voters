<template>
    <div class="register">
      <form @submit.prevent="register">
        <div class="form-group">
          <i class="iconfont icon-user1"></i>
          <input type="text" v-model="ruleForm.UserName" placeholder="请输入用户名">
        </div>
        <div class="form-group">
          <i class="iconfont icon-password5"></i>
          <input type="password" v-model="ruleForm.Password" placeholder="请输入密码">
        </div>
        <div class="form-group">
          <i class="iconfont icon-password1"></i>
          <input type="password" v-model="ruleForm.rePassword" placeholder="请确认密码">
        </div>

        <div class="form-group">
          <button type="submit" class="button">注册</button>
        </div>
      </form>
    </div>
</template>

<script>
import axios from 'axios'
import qs from 'qs'
export default {
  data () {
    return {
      msg: '',
      rePassword: '',
      ruleForm: {
        UserName: '',
        Password: ''
      }
    }
  },
  methods: {
    register: function () {
      var formData = qs.stringify(this.ruleForm)
      this.$http
        .post('http://localhost:12612/api/register', formData)
        .then(res => {
          var RES = eval('(' + res.data + ')')
          if (RES.StateCode) {
            console.log('注册成功！')
            this.$router.push({ path: 'login' })
          } else {
            console.log('密码不正确或验证码不正确或者您已经注册')
          }
        })
      // this.$router.push({ path: 'login' })
    }
    // getName () {
    //   axios.get('http://127.0.0.1:8080/webapi/check_username', {
    //     params: {
    //       UserName: '钟力力'
    //     }
    //   }).then(function (response) {
    //     console.log(response)
    //   }).catch(function (err) {
    //     console.log(err)
    //   })
    // }
  }
}
</script>

<style>
.register{
    width: 100%;
}
.register .form-group input{
  border-top: 0px;
  border-radius: 0px;
}
.form-group:first-child input {
  border: 1px solid #c8c8c8;
  border-radius: 4px 4px 0 0;
}
.register .form-group:last-child input{
  border: 0 0 4px 4px;
}

</style>
