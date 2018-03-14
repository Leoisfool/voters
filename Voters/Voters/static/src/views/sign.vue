<template>
  <div class="sign">
    <div class="main">
      <h4 class="title">
        <router-link to="login" @click.native="change('login')" :class="{'active': loginSelected}">登录</router-link>
        <b>.</b>
        <router-link to="register" @click.native="change('register')" :class="{'active': registerSelected}">注册</router-link>
      </h4>
      <div class="container">
        <router-view></router-view>
      </div>
    </div>
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
      msg: 'I,m ',
      loginSelected: true,
      registerSelected: false
    }
  },
  http: {
    root: '/root',
    headers: {
      Authorization: 'zhongli'
    }
  },
  mounted: function () {
    this.change(this.$store.state.loginOrReg)
  },
  methods: {
    change: function (selected) {
      if (selected === 'login') {
        this.loginSelected = true
        this.registerSelected = false
        this.$store.commit('setLoginOrReg', 'login')
        sessionStorage.loginOrReg = 'login'
      } else {
        this.registerSelected = true
        this.loginSelected = false
        this.$store.commit('setLoginOrReg', 'register')
        sessionStorage.loginOrReg = 'register'
      }
    }
  }
}
</script>

<style>
.sign{
  width: 100%;
  height: 100%;
  min-height: 750px;
  text-align: center;
  font-size: 14px;
  background-color: #f1f1f1;
}
.sign .main {
    width: 400px;
    margin: 60px auto;
    padding: 50px 50px;
    background-color: #fff;
    border-radius: 4px;
    box-shadow: 0 0 8px rgba(0,0,0,.1);
    vertical-align: middle;
    display: inline-block;
}
.sign .main .container{
    margin: 40px auto;
}
.sign .main .title b,a{
  padding: 10px;
  font-weight: 700;
  color: #969696;
  line-height: 1.1;
  text-decoration: none;
}
.sign .main .title b{
    padding: 10px;
}
.sign .main a:active{
  font-weight: 700;
  color: #ea6f5a;
  border-bottom: 2px solid #ea6f5a;
}
.active{
  color: #ea6f5a;
  border-bottom: 2px solid #ea6f5a;
}

.form-group {
  position: relative;
  width: 80%;
  margin: 0 auto;
}
.form-group input {
  position: relative;
  width: 70%;
  height: 50px;
  margin: 0 auto;
  padding: 4px 12px 4px 35px;
  border: 1px solid #c8c8c8;
  border-radius: 0 0 4px 4px;
  background-color: hsla(0, 0%, 71%, 0.1);
  vertical-align: middle;
  outline: 0px;
}
.form-group .iconfont {
  position: absolute;
  top: 15px;
  left: 30px;
  font-size: 1.4rem;
}
/* .login div:nth-child(2) input {
  border-top: 0px;
} */
.form-group .verifyCode {
  width: 70%;
  height: 40px;
  top: 30px;
  border-radius: 4px;
  padding: 4px 35px 4px 12px;
}
.form-group .verifyImg {
  position: absolute;
  width: 40%;
  height: 48px;
  top: 30px;
  left: 168px;
  background-color: #eee;
  border: 1px solid #c8c8c8;
  border-left: 0px;
  border-radius: 0 4px 4px 0;
}
.form-group .verifyImg img {
  position: relative;
  width: 100%;
  height: 48px;
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
@media all and (max-width: 700px){
  .sign {
    height: auto;
    min-height: 0;
    background-color: transparent;
  }
  .sign .main {
    width: 400px;
    margin: 60px auto 0;
    padding: 50px 50px 30px;
    background-color: #fff;
    border-radius: 0;
    box-shadow: none;
    vertical-align: middle;
    display: inline-block;
  }
}
</style>
