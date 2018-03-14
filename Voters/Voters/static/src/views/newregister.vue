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
          <input type="password" v-model="rePassword" @blur="checkPassword()" placeholder="请确认密码">
        </div>

        <div class="form-group">
          <button type="submit" class="button">注册</button>
        </div>
      </form>
    </div>
</template>

<script>
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
      if (this.ruleForm.UserName === '' || this.ruleForm.Password === '') {
        this.$message.error('输入不能为空')
      } else if (this.checkPassword()) {
        this.$http.post('http://localhost:12612/api/register', this.ruleForm)
          .then((res) => {
            debugger
            if (res.data.State === 1) {
              console.log('注册成功！')
              this.$router.push({ path: 'login' })
              this.$parent.change('login')
            } else {
              this.$message.error('注册失败')
            }
          })
          .catch((error) => {
            console.log('error' + error)
          })
      } else {
        this.$message.error('密码不一致')
        this.rePassword = ''
      }
    },
    checkPassword () {
      if (this.ruleForm.Password === this.rePassword) {
        return true
      } else {
        return false
      }
    }
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
