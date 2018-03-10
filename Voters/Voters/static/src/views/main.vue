<template>
  <div class="mainContainer">
    <header>
      <button @click="jump" class="uxButton">
        Voters
      </button>
      <el-breadcrumb separator="/" class="option">
        <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
        <el-breadcrumb-item :to="{ path: 'voters' }" v-show="showMyHost">我的主页</el-breadcrumb-item>
        <el-breadcrumb-item :to="{ path: 'sign/login'}" v-show="showLogin">登录</el-breadcrumb-item>
        <el-breadcrumb-item :to="{ path: 'sign/register'}" v-show="showRegister">注册</el-breadcrumb-item>
        <el-breadcrumb-item href="javascript:;" v-show="showLoginout">退出</el-breadcrumb-item>
      </el-breadcrumb>
      <div>
        <router-view></router-view>
      </div>
    </header>
    <section class="firstBox">
      <div class="uxRow">
        <div class="theFirst"> 一个简洁随心的投票系统</div>
        <flip-box front="V" back="民"></flip-box>
        <flip-box front="O" back="主"></flip-box>
      </div>
      <div class="uxRow">
        <flip-box front="T" back="和"></flip-box>
        <flip-box front="E" back="协"></flip-box>
        <flip-box front="R" back="自"></flip-box>
        <flip-box front="S" back="由"></flip-box>
      </div>
    </section>
    <div class="dropDown">
      <a href="#vote">
        <svg class="icon" aria-hidden="true">
          <use xlink:href="#icon-quqi"></use>
        </svg>
      </a>
    </div>
    <section id="vote">
      <el-table
        :data="tableData"
        border
        style="width: 100%">
        <el-table-column
          fixed
          prop="title"
          label="标题"
          width="250">
        </el-table-column>
        <el-table-column
          prop="voteAble"
          label="投票开放与否"
          width="150">
        </el-table-column>
        <el-table-column
          prop="sponsor"
          label="发起者"
          width="120">
        </el-table-column>
        <el-table-column
          prop="date"
          label="过期时间"
          width="120">
        </el-table-column>
        <el-table-column
          prop="introduction"
          label="介绍"
          width="520">
        </el-table-column>
        <el-table-column
          fixed="right"
          label="操作"
          width="200">
          <template slot-scope="scope">
            <el-button @click="handleClick(scope.row)" type="text" size="small">查看</el-button>
            <el-button type="text" size="small">不感兴趣</el-button>
            <el-button type="text" size="small">关注</el-button>
          </template>
        </el-table-column>
      </el-table>
    </section>
  </div>
</template>

<script>
import axios from 'axios'
axios.defaults.timeout = 5000
export default {
  data () {
    return {
      msg: 'hello',
      showLogin: true,
      showRegister: true,
      showMyHost: false,
      showLoginout: false,
      tableData: [{
        id: 1,
        title: '你能接受同性恋吗？',
        sponsor: 'sponsor zl',
        voteAble: '开放',
        date: '2016-05-03',
        introduction: '爱无关性别爱无关性别爱无关性别爱无关性别爱无关性别'
      }, {
        id: 2,
        title: '你能接受同性恋吗？',
        voteAble: '开放',
        sponsor: 'sponsor zl',
        date: '2016-05-03',
        introduction: '爱无关性别'
      }, {
        id: 3,
        title: '你能接受同性恋吗？',
        sponsor: 'sponsor zl',
        voteAble: '开放',
        date: '2016-05-03',
        introduction: '爱无关性别'
      }, {
        id: 4,
        title: '你能接受同性恋吗？',
        sponsor: 'sponsor zl',
        voteAble: '开放',
        date: '2016-05-03',
        introduction: '爱无关性别'
      }]
    }
  },
  methods: {
    jump () {
      this.$router.push('voters')
    },
    ifLogin () {
      debugger
      if(sessionStorage.Token){
        this.$store.commit('setToken', sessionStorage.Token)
        this.$store.commit('setUserId', sessionStorage.UserId)
      }
      this.$http.post('http://localhost:12612/api/iflogin',{
        'Token': this.$store.state.Token
      }).then (res => {
        if(res.data.State === 1){
          this.showLogin = false
          this.showRegister = false
          this.showLoginout = true
          this.showMyHost = true
        } else if (res.data.State === 0){
          this.showLogin = true
          this.showRegister = true
          this.showLoginout = false
          this.showMyHost = false
          console.log('没有登录')
        }
      })
    },
    handleClick (row) {
      console.log(row)
    }
  },
  beforeMount: function () {
    this.ifLogin()
  },
  mounted: function () {
    axios.interceptors.request.use(config => {
      console.log('request init.')
      return config
    }, error => {
      return Promise.reject(error)
    })
    axios.interceptors.response.use(data => {
      console.log('response init.')
    }, error => {
      return Promise.reject(error)
    })
  },
  components: {
    'flip-box': {
      props: ['front', 'back'],
      template: '<div class="flipBox"><div class="flip"><div class="front">{{ front }}</div><div class="back">{{ back }}</div></div></div>'
    }
  }
}
</script>

<style>
.mainContainer {
  position: relative;
  display: -webkit-flex;
  display: flex;
  flex-direction: column;
  /* TODO */
  background-color:#ffe;
}
.uxButton {
  -moz-appearance: none;
  -webkit-appearance: none;
  outline: none;
  height: 65px;
  padding: 0px 10px;
  background-color: #333;
  border: none;
  color: #ffff99;
  font-size: 2rem;
  font-family: sans-serif;
}
.option {
  float: right;
  margin-top: 22px;
  margin-right: 14px;
}

.flipBox {
  perspective: 1000;
}
.flip {
  position: relative;
  transform-style: preserve-3d;
  transition: 0.6s;
  margin: 1px;
}
.front,
.back {
  position: absolute;
  width: 100%;
  backface-visibility: hidden; /* 避免在实现动画效果时露出背面 */
}
.front {
  z-index: 2;
}
.flipBox:nth-child(odd) .flip .back {
  z-index: 1;
  transform: rotateY(-180deg); /* 最开始就翻转180度，以背面示人 */
  color: #ff9;
  background-color:#333;
}

.flipBox:nth-child(even) .flip .back{
  color: black;
  background-color:white;
  transform: rotateX(180deg)
}
.flipBox:nth-child(even) .flip .front{
  color: snow;
  background-color:#9cf;
}
.flipBox:nth-child(odd) .flip .front{
  color: black;
  background-color:#fc9;
}
.flipBox:nth-child(even):hover .flip{
  transform: rotateX(180deg)
}
.flipBox:hover .flip {
  transform: rotateY(180deg);
}

.theFirst{
  margin: 1px;
  background-color: rgba(0, 0, 0, 0.12);
  color: white;
}

@media all and (min-width: 1000px) {
  .firstBox {
    width: 80%;
    margin: 35px auto;
    height: 400px;
    display: flex;
    display: -webkit-flex;
    flex-direction: column;
  }
  .uxRow {
    display: flex;
    display: -webkit-flex;
    flex-direction: row;
    flex: 1;
  }
  .uxRow:first-child div:first-child {
    flex: 2;
  }
  .uxRow div {
    flex: 1;
  }

  .front,.back,.uxRow div:first-child{
    height: 196px;
  }
  .flipBox:nth-child(even) .flip{
    transform-origin: 40% 98px;
  }
  .theFirst{
    text-align: center;
    font-size: 1.3rem;
    line-height: 12rem;
  }
  .front,.back{
    text-align: center;
    font-size: 6rem;
    line-height: 12rem;
  }
  .mainContainer .dropDown{
    margin: 0 auto;
  }
  .mainContainer .dropDown .icon{
    font-size: 2.5rem;
  }

  .mainContainer #vote{
    width: 80%;
    margin: 35px auto;
  }
}

@media all and (min-width: 601px) and (max-width: 999px) {
  /* 翻转Box */
  .firstBox {
    width: 80%;
    margin: 80px auto;
    height: 250px;
    display: flex;
    display: -webkit-flex;
    flex-direction: column;
  }
  .uxRow {
    display: flex;
    display: -webkit-flex;
    flex-direction: row;
    flex: 1;
  }
  .uxRow:first-child div:first-child {
    flex: 2;
  }
  .uxRow div {
    flex: 1;
  }

  .front,.back,.uxRow div:first-child{
    height: 121px;
  }
  .flipBox:nth-child(even) .flip{
    transform-origin: 0 61px;
  }
  .front,.back{
      text-align: center;
      font-size: 4rem;
      line-height: 7rem;
  }
  .theFirst{
    text-align: center;
    font-size: 1.1rem;
    line-height: 7rem;
  }
  .mainContainer .dropDown{
    margin: 0 auto;
  }
  .mainContainer .dropDown .icon{
    font-size: 2.5rem;
    margin: 30px auto;
  }
  .mainContainer #vote{
    float: left;
    margin-left: 10%;
    width: 80%;
  }
}

@media all and (max-width: 600px) {
  .firstBox {
    width: 100%;
    margin-top: 1vmax;
    display: flex;
    display: -webkit-flex;
    flex-direction: column;
  }
  .uxRow {
    display: flex;
    display: -webkit-flex;
    flex-direction: column;
    flex: 1;
  }
  .uxRow div {
    height: 17vmax;
    flex: 1;
  }
  .front,.back,.uxRow div:first-child{
    height: 16vmax;
  }
  .mainContainer .dropDown{
    display: none;
  }
  .front,.back{
      text-align: center;
      font-size: 4rem;
      line-height: 7rem;
  }
  .theFirst{
    text-align: center;
    font-size: 1.1rem;
    line-height: 7rem;
  }
  .mainContainer #vote{
    position: absolute;
    top: 140vmax;
  }
}
</style>
