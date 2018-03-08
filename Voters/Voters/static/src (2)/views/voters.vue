<template>
  <div class="voter">
    <el-container>
      <el-header>
        <el-row :gutter="20">
          <el-col :span="2">
            <h2>REPOSITORIES</h2>
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
                <el-dropdown-item command="personalProfile">个人资料</el-dropdown-item>
                <el-dropdown-item command="personalProfile">创建我的投票</el-dropdown-item>
                <el-dropdown-item command="loginOut">退出登录</el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </el-col>
        </el-row>
      </el-header>
      <el-main>
        <div class="naive">        
          <el-row>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1" offset="7">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="7">
              <div class="grid-content">
                <el-button type="success" plain>
                  <svg class="icon" aria-hidden="true">
                    <use xlink:href="#icon-add"></use>
                  </svg>
                  添加投票
                </el-button>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1" offset="7">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
            <el-col :span="1">
              <div class="grid-content">
                <svg class="icon" aria-hidden="true">
                  <use xlink:href="#icon-binggun"></use>
                </svg>
              </div>
            </el-col>
          </el-row>
        </div>
        <el-table
          :data="tableData">
          <el-table-column
            label="主题"
            fixed
            width="100">
            <template slot-scope="scope">
              <svg class="icon" aria-hidden="true">
                <use xlink:href="#icon-kafei"></use>
              </svg>
              <span>{{ scope.row.Topic }}</span>
            </template>
          </el-table-column>
          <el-table-column
            label="详情"
            width="280">
            <template slot-scope="scope">
              <svg class="icon" aria-hidden="true">
                <use xlink:href="#icon-pijiu"></use>
              </svg>
              <span>{{ scope.row.Desc }}</span>
            </template>
          </el-table-column>
          <el-table-column
            label="创建时间"
            width="120">
            <template slot-scope="scope">
              <i class="el-icon-time"></i>
              <span>{{ scope.row.CreateTime }}</span>
            </template>
          </el-table-column>
          <el-table-column
            label="结束时间"
            width="180">
            <template slot-scope="scope">
              <i class="el-icon-time"></i>
              <span style="margin-left: 10px">{{ scope.row.OverdueTime }}</span>
            </template>
          </el-table-column>
          <el-table-column 
            fixed="right"
            label="操作"
            width="220px"
            >
            <template slot-scope="scope">
              <el-button
                size="mini"
                @click="handleEdit(scope.$index, scope.row)">投票</el-button>
              <el-button
                size="mini"
                @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
              <el-button
                size="mini"
                type="danger"
                @click="handleDelete(scope.$index, scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
        <div id="main" style="width: 600px;height:400px;"></div>
      </el-main>
      <el-footer>Footer</el-footer>
    </el-container>
  </div>
</template>

<script>
import echarts from 'echarts'
export default {
  data () {
    return {
      Token: 'hello',
      logOutURL: 'http://127.0.0.1:8080/webapi/logout',
      tableData: [{
        "UserBelong":1,
        "Topic":"USA大选",
        "Desc":"2016美国总统大选,大家选出你支持的人，快快哦",
        "VoteAble":1,
        "MultiNum":1,
        "OverdueTime":1520319941,
        "CreateTime":1520309941,
        "Token":"21BAD4931F81504C5AF7E7A7F793CEE2"
      },{
        "UserBelong":1,
        "Topic":"USA大选",
        "Desc":"2016美国总统大选,大家选出你支持的人，快快哦",
        "VoteAble":1,
        "MultiNum":1,
        "OverdueTime":1520319941,
        "CreateTime":1520309941,
        "Token":"21BAD4931F81504C5AF7E7A7F793CEE2"
      },{
        "UserBelong":1,
        "Topic":"USA大选",
        "Desc":"2016美国总统大选,大家选出你支持的人，快快哦",
        "VoteAble":1,
        "MultiNum":1,
        "OverdueTime":1520319941,
        "CreateTime":1520309941,
        "Token":"21BAD4931F81504C5AF7E7A7F793CEE2"
      },{
        "UserBelong":1,
        "Topic":"USA大选",
        "Desc":"2016美国总统大选,大家选出你支持的人，快快哦",
        "VoteAble":1,
        "MultiNum":1,
        "OverdueTime":1520319941,
        "CreateTime":1520309941,
        "Token":"21BAD4931F81504C5AF7E7A7F793CEE2"
      },{
        "UserBelong":1,
        "Topic":"USA大选",
        "Desc":"2016美国总统大选,大家选出你支持的人，快快哦",
        "VoteAble":1,
        "MultiNum":1,
        "OverdueTime":1520319941,
        "CreateTime":1520309941,
        "Token":"21BAD4931F81504C5AF7E7A7F793CEE2"
      }]
    }
  },
  mounted () {
    this.draw()
  },
  methods: {
    loginOut () {
      this.$http.post(this.logOutURL, this.Token).then(res => {
        var stateCode = eval('(' + res.data + ')')
        if (stateCode.StateCode) {
          console.log('退出成功！')
        } else {
          console.error('出错啦！')
        }
      })
    },
    handleCommand (command) {
      if (command === 'home'){
        this.$router.push('/#vote')
      }else if (command === 'personalProfile') {
        this.$message('click on item ' + command)        
      }else if ( command === 'loginOut') {
        this.$message('click on item ' + command)        
      }else {
        this.$message('error')
      }
    },
    handleEdit(index, row) {
      console.log(index, row);
    },
    handleDelete(index, row) {
      console.log(index, row);
    },
    draw () {
      // 基于准备好的dom，初始化echarts实例
      var myChart = echarts.init(document.getElementById('main'))
      // 绘制图表
      myChart.setOption({
          title: {
              text: 'ECharts 入门示例'
          },
          tooltip: {},
          xAxis: {
              data: ['衬衫', '羊毛衫', '雪纺衫', '裤子', '高跟鞋', '袜子']
          },
          yAxis: {},
          series: [{
              name: '销量',
              type: 'bar',
              data: [5, 20, 36, 10, 10, 20]
          }]
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
  min-height: 630px;
  background-color: #f1f1f1;
  color: #333;
  text-align: center;
}
.el-header, .el-footer {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

h2{
  color: rgb(63, 48, 48);
}

@media all and (min-width: 1000px) {
  .voter .el-table{
    width: 60%;
    left: 40%;
    top: -280px;
  }
}

@media all and (max-width: 1000px) {
  .voter .naive{
    display: none;
  }
  .voter .el-table{
    width: 100%;
  }
}
</style>
