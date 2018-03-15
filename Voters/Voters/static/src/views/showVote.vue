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
        <!-- <div id="myChart" :style="{width: '300px', height: '300px'}"></div> -->
        <el-table
          :data="tableData"
          border
          style="width: 100%">
          <el-table-column
            prop="itemDesc"
            label="选项"
            width="180">
          </el-table-column>
          <el-table-column
            prop="Score"
            label="得票">
          </el-table-column>
        </el-table>
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
      tableData: [
        {
          itemDesc: 'sfcsd',
          Score: 4
        }
      ]
      // myData: [
      //   {value: 235, name: '视频广告'}
      // ]
    }
  },
  mounted () {
    // this.series[0].data = this.showData
    this.createData()
  },
  methods: {
    createData () {
      // var myData = []
      let url = 'http://localhost:12612/api/vote?id=' + sessionStorage.VoteId
      this.$http.get(url)
        .then(res => {
          let ItemIds = res.data.ItemIds
          ItemIds.forEach(element => {
            // debugger
            this.getItemsInfo(element)
          })
        })
        .catch(res => {
          console.log(res.data)
        })
    },
    getItemsInfo (id, myData) {
      // var myChart = echarts.init(document.getElementById('myChart'))
      var getItemUrl = 'http://localhost:12612/api/item?ItemId=' + id
      var obj = {
        itemDesc: '',
        Score: ''
      }
      // var box = document.getElementById('box')
      this.$http.get(getItemUrl)
        .then(itemRes => {
          // debugger
          obj.Score = itemRes.data.Score
          obj.itemDesc = itemRes.data.Desc
          this.tableData.push(obj)
          // this.printChart(myData)
        })
    },
    printChart (myData) {
      // 基于准备好的dom，初始化echarts实例
      var myChart = echarts.init(document.getElementById('myChart'))
      // 绘制图表
      myChart.setOption({
        backgroundColor: '#2c343c',
        visualMap: {
          show: false,
          min: 80,
          max: 600,
          inRange: {
            colorLightness: [0, 1]
          }
        },
        series: [
          {
            name: '访问来源',
            type: 'pie',
            radius: '55%',
            data: myData,
            roseType: 'angle',
            label: {
              normal: {
                textStyle: {
                  color: 'rgba(255, 255, 255, 0.3)'
                }
              }
            },
            labelLine: {
              normal: {
                lineStyle: {
                  color: 'rgba(255, 255, 255, 0.3)'
                }
              }
            },
            itemStyle: {
              normal: {
                color: '#c23531',
                shadowBlur: 200,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
              }
            }
          }
        ]
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
