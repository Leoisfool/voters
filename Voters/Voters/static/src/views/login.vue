<template>
  <div class="login">
    <form @submit.prevent="login">
      <div class="form-group">
        <i class="iconfont icon-user1"></i>
        <input type="text"  autocomplete="off" v-model="userInfo.UserName" placeholder="请输入用户名">
      </div>
      <div class="form-group">
        <i class="iconfont icon-password5"></i>
        <input type="password"  autocomplete="off" v-model="userInfo.Password" placeholder="请输入密码">
      </div>
      <div class="form-group">
        <button type="submit" class="button">登录</button>
      </div>
    </form>
    <br/>
  </div>
</template>

<script>
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
  computed: {
    Token () {
      return this.$store.state.Token
    },
    UserId () {
      return this.$store.state.UserId
    }
  },
  methods: {
    login: function () {
      this.$http.post('http://localhost:12612/api/login', this.userInfo)
        .then((res) => {
          if (res.data.State === 1) {
            this.$store.commit('setToken', res.data.Token)
            this.$store.commit('setUserId', res.data.UserId)
            this.$router.push({ path: '../voters/' })
          } else {
            this.$message.error('您没有登录进去呢，try again')
          }
        })
        .catch((error) => {
          console.log('error' + error)
        })
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
