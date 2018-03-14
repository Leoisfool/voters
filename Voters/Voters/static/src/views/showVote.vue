<template>
  <div class="showVote">
    <el-container>
      <el-header>
        <el-row :gutter="20">
          <el-col :span="2">
            <h2>{{ msg }}</h2>
          </el-col>
          <el-col :span="10" :offset="12">
            <el-dropdown class="headerLink" @command="handleCommand">
              <span class="el-dropdown-link">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-kitkat"></use>
                </svg>
                <i class="el-icon-arrow-down el-icon--right"></i>
              </span>
              <el-dropdown-menu slot="dropdown">
                <el-dropdown-item></el-dropdown-item>
                <el-dropdown-item command="home">首页</el-dropdown-item>
                <el-dropdown-item command="myHost">我的主页</el-dropdown-item>
                <el-dropdown-item command="personalProfile">个人资料</el-dropdown-item>
                <el-dropdown-item command="loginOut">退出</el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </el-col>
        </el-row>
      </el-header>
      <el-main>
        <div id="myChart" :style="{width: '300px', height: '300px'}"></div>
      </el-main>
    </el-container>
  </div>
</template>

<script>
var echarts = require('echarts')
export default {
  name: 'HelloWorld',
  data () {
    return {
      msg: 'ShowTime',
      series: [
        {
          name: '访问来源',
          type: 'pie',
          radius: '55%',
          data: [
            {value: 235, name: '视频广告'}
          ]
        }
      ]
    }
  },
  mounted () {
    this.printChart()
  },
  methods: {
    printChart () {
      // 基于准备好的dom，初始化echarts实例
      var myChart = echarts.init(document.getElementById('myChart'))
      let url = 'http://localhost:12612/api/vote?id=' + sessionStorage.VoteId
      this.$http.get(url).then(res => {
        debugger
        let ids = res.data.ItemIds
        this.series[0].data = []
        let datas = this.series[0].data
        let obj = {}
        let getItemUrl
        ids.forEach((id) => {
          console.log(id)
          getItemUrl = 'http://localhost:12612/api/item?ItemId=' + id
          console.log(getItemUrl)
          this.$http.get(getItemUrl).then(itemRes => {
            obj.value = itemRes.data.Score
            obj.name = itemRes.data.Desc
            console.log(obj)
            datas.push(obj)
            console.log('datas' + datas)
            console.log(this.series[0].data)
          })
        })
      })
      // 绘制图表
      myChart.setOption({
        series: this.series
      })
    },
    loginOut () {
      this.$http.post('http://localhost:12612/api/logout', {
        Token: sessionStorage.Token
      })
        .then(res => {
          if (res.data.State === 1) {
            // this.$message('退出成功！')
            this.$router.push('/')
          } else {
            this.$message('退出失败')
          }
        })
        .catch(error => {
          console.log('error' + error)
        })
    },
    handleCommand (command) {
      if (command === 'home') {
        this.$router.push('/#vote')
      } else if (command === 'personalProfile') {
        this.$message('click on item' + command)
      } else if (command === 'loginOut') {
        this.loginOut()
      } else if (command === 'createVote') {
        this.dialogVisible = true
      } else if (command === 'myHost') {
        this.$router.push('/voters')
      } else {
        this.$message('error')
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.grid-content {
  min-height: 36px;
}

.headerLink {
  float: right;
  padding-right: 10px;
}
.headerLink .el-dropdown-link .icon {
  font-size: 1.9rem;
}
.el-main {
  min-height: 630px;
  background-color: #f1f1f1;
  color: #333;
  text-align: center;
}
.el-header,
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 60px;
}
h2 {
  color: rgb(63, 48, 48);
}
</style>
