<template>
  <div class="voter">
    <el-container>
      <el-header>
        <el-row :gutter="20">
          <el-col :span="10" :offset="14">
            <el-dropdown class="headerLink">
              <span class="el-dropdown-link">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-kitkat"></use>
                </svg>
                <i class="el-icon-arrow-down el-icon--right"></i>
              </span>
              <el-dropdown-menu slot="dropdown">
                <el-dropdown-item></el-dropdown-item>
                <el-dropdown-item>首页</el-dropdown-item>
                <el-dropdown-item>个人资料</el-dropdown-item>
                <el-dropdown-item @click="loginOut">退出登录</el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </el-col>
        </el-row>
      </el-header>
      <el-main>Main</el-main>
      <el-footer>Footer</el-footer>
    </el-container>
    
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
.el-row {
  margin-bottom: 20px;
  margin-top: 10px;
  &:last-child {
    margin-bottom: 0;
  }
}
.grid-content {
  min-height: 36px;
}

.voter .headerLink{
  float: right;
  padding-right: 10px;
}

.voter .headerLink .el-dropdown-link .icon{
  font-size: 1.9rem;
}
.el-main {
  background-color: #f1f1f1;
  color: #333;
  text-align: center;
  line-height: 160px;
}
.el-header, .el-footer {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}
@media all and (min-width: 1000px) {
  
}

@media all and (min-width:) {
  
}
</style>
