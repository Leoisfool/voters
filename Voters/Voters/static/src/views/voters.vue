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
                <el-dropdown-item command="createVote">创建我的投票</el-dropdown-item>
                <el-dropdown-item command="loginOut">退出</el-dropdown-item>
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
            <el-col :span="1" :offset="7">
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
                <el-button type="success" plain @click="dialogVisible = true">
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
            <el-col :span="1" :offset="7">
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
                @click="doVote(scope.$index, scope.row)">投票</el-button>
              <el-button
                size="mini"
                @click="voteEdit(scope.$index, scope.row)">编辑</el-button>
              <el-button
                size="mini"
                type="danger"
                @click="voteDelete(scope.row)">删除</el-button>
            </template>
          </el-table-column>
        </el-table>
        <br>
        <div class="block" style="float:right">
          <el-pagination
            @current-change="handleCurrentChange"
            :current-page.sync="currentPage"
            :page-size="10"
            :background="background"
            layout="prev, pager, next, jumper"
            :total.sync="totalVotes">
          </el-pagination>
        </div>
      </el-main>
      <el-footer>Footer</el-footer>
    </el-container>

    <!-- 创建投票 -->
    <el-dialog
      title="创建投票"
      :visible.sync="dialogVisible"
      width="50%"
      :before-close="handleClose">
      <span>
        <el-form ref="form" :model="voteMsg" label-width="80px">
          <el-form-item label="投票主题">
            <el-input v-model="voteMsg.Topic"></el-input>
          </el-form-item>
          <el-form-item label="投票详情">
            <el-input
              type="textarea"
              :autosize="{ minRows: 2, maxRows: 4}"
              placeholder="请输入内容"
              v-model="voteMsg.Desc">
            </el-input>
          </el-form-item>
          <el-form-item label="是否激活">
            <el-tooltip :content="voteMsg.VoteAble == '1'?'激活':'未激活'" placement="top">
              <el-switch
                v-model="voteMsg.VoteAble"
                active-color="#13ce66"
                inactive-color="#ff4949"
                active-value="1"
                inactive-value="0">
              </el-switch>
            </el-tooltip>
          </el-form-item>
          <el-form-item label="选项个数">
            <el-input-number size="medium" :min="1" :max="4" v-model="voteMsg.MultiNum"></el-input-number>
          </el-form-item>
          <el-form-item label="截止时间">
          </el-form-item>
        </el-form>
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取消</el-button>
        <el-button type="primary" @click="createVoteFun()">确定</el-button>
      </span>
    </el-dialog>
    <!-- 添加item -->
    <el-dialog
      title="创建选项"
      :visible.sync="createItemVisible"
      width="40%"
      :before-close="closeItemdialog">
      <span ref="itemsBox">
        选项内容<el-input v-model="itemMsg.Desc"></el-input>
        <br>
        <br>
        <!-- <el-button
          round
          icon="el-icon-circle-plus-outline"
          @click="createItemFun()">添加</el-button> -->
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addFinish()">完 成</el-button>
        <el-button type="primary" @click="addItem()">继续添加</el-button>
      </span>
    </el-dialog>
    <!-- 查看单个投票信息 -->
    <el-dialog
      :title="voteMsgs.Topic"
      :visible.sync="viewDialogVisible"
      width="80%"
      center>
      <span>
        <el-alert
          :title="voteMsgs.Desc"
          type="success"
          :closable="false">
        </el-alert>
        <el-alert
          :title="'你需要投' + voteMsgs.MultiNum + '票'"
          type="success"
          :closable="false">
        </el-alert>
        <el-checkbox-group
          v-model="doVoteMsgs.ItemIds"
          :min="0"
          :max="voteMsgs.MultiNum">
          <el-checkbox v-for="item in items" :label="item.ItemId" :key="item.ItemId">{{item.Desc}}</el-checkbox>
        </el-checkbox-group>
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="viewDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="vote()">投 票</el-button>
      </span>
    </el-dialog>
    <!-- 编辑 -->
    <el-dialog
      title="编辑"
      :visible.sync="editVisible"
      width="500px"
      >
      <span>
        <el-form ref="form" :model="voteMsg" label-width="80px">
          <el-form-item label="投票主题">
            <el-input v-model="voteMsg.Topic"></el-input>
          </el-form-item>
          <el-form-item label="投票详情">
            <el-input
              type="textarea"
              :autosize="{ minRows: 2, maxRows: 4}"
              placeholder="请输入内容"
              v-model="voteMsg.Desc">
            </el-input>
          </el-form-item>
          <el-form-item label="是否激活">
            <el-tooltip :content="voteMsg.VoteAble == '1'?'激活':'未激活'" placement="top">
              <el-switch
                v-model="voteMsg.VoteAble"
                active-color="#13ce66"
                inactive-color="#ff4949"
                active-value="1"
                inactive-value="0">
              </el-switch>
            </el-tooltip>
          </el-form-item>
          <el-form-item label="选项个数">
            <el-input-number size="medium" :min="1" :max="4" v-model="voteMsg.MultiNum"></el-input-number>
          </el-form-item>
          <el-form-item label="截止时间">
          </el-form-item>
        </el-form>
      </span>
      <span>
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="editVisible = false">取消</el-button>
        <el-button @click="editVote()">确定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  data () {
    return {
      background: '#f1f1f1',
      tableData: [],
      dialogVisible: false,
      createItemVisible: false,
      viewDialogVisible: false,
      editVisible: false,
      Token: this.$store.state.Token,
      voteMsg: {
        UserBelong: sessionStorage.UserId,
        Topic: '',
        Desc: '',
        VoteAble: '',
        MultiNum: '',
        OverdueTime: '1520319941',
        CreateTime: '1520309941',
        Token: sessionStorage.Token
      },
      itemMsg: {
        VoteId: '',
        Desc: '',
        DescPicUrl: 'XXX',
        Token: sessionStorage.Token,
        UserId: sessionStorage.UserId
      },
      createItems: [],
      totalVotes: 0,
      currentPage: 1,
      voteMsgs: {},
      doVoteMsgs: {
        VoteId: '',
        Token: sessionStorage.Token,
        ItemIds: []
      },
      items: []
    }
  },
  mounted () {
    this.getPageNum()
    this.handleCurrentChange(1)
  },
  computed: {
    mySwitch () {
      if (this.VoteAble) {
        return '激活'
      } else {
        return '未激活'
      }
    }
  },
  methods: {
    loginOut: function () {
      this.$http.post('http://localhost:12612/api/logout', {
        Token: sessionStorage.Token
      })
        .then((res) => {
          if (res.data.State === 1) {
            // this.$message('退出成功！')
            this.$router.push('/')
          } else {
            this.$message('退出失败')
          }
        })
        .catch((error) => {
          console.log('error' + error)
        })
    },
    handleCommand (command) {
      if (command === 'home') {
        this.$router.push('/#vote')
      } else if (command === 'personalProfile') {
        this.$message('click on item ' + command)
      } else if (command === 'loginOut') {
        this.loginOut()
      } else if (command === 'createVote') {
        // this.$message('click on item ' + command)
        this.dialogVisible = true
      } else {
        this.$message('error')
      }
    },
    doVote (index, row) {
      this.voteMsgs = row
      this.doVoteMsgs.VoteId = row.VoteId
      this.doVoteMsgs.ItemIds = []
      let url = 'http://localhost:12612/api/vote?id=' + row.VoteId
      this.$http.get(url).then(res => {
        let ids = res.data.ItemIds
        this.items = []
        ids.forEach(id => {
          let getItemUrl = 'http://localhost:12612/api/item?ItemId=' + id
          this.$http.get(getItemUrl).then(itemRes => {
            this.items.push(itemRes.data)
          })
        })
      })
      this.viewDialogVisible = true
    },
    vote () {
      this.$http.post('http://localhost:12612/api/dovote', this.doVoteMsgs)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '投票成功'
            })
            this.viewDialogVisible = false
          } else {
            this.$message(res.data.ErrorInfo)
          }
        })
    },
    voteEdit (index, row) {
      console.log(row)
      this.voteMsg = row
      this.editVisible = true
      let url = 'http://localhost:12612/api/vote?id=' + row.VoteId
      this.$http.get(url).then(res => {
        let ids = res.data.ItemIds
        this.items = []
        ids.forEach(id => {
          let getItemUrl = 'http://localhost:12612/api/item?ItemId=' + id
          this.$http.get(getItemUrl).then(itemRes => {
            this.items.push(itemRes.data)
          })
        })
      })
    },
    voteDelete (row) {
      var delInfo = {
        VoteId: row.VoteId,
        Token: sessionStorage.Token
      }
      this.$confirm('该操作将永远删除该投票主题，是否继续？', '删除', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        this.$http.post('http://localhost:12612/api/deletevote', delInfo)
          .then((res) => {
            if (res.data.State === 1) {
              this.$message({
                type: 'success',
                message: '删除成功'
              })
              this.handleCurrentChange(this.currentPage)
            } else {
              this.$message({
                type: 'erroe',
                message: '删除失败'
              })
            }
          }).catch(() => {
            this.$message({
              type: 'info',
              message: '已取消删除'
            })
          })
      })
    },
    handleClose () {
      this.dialogVisible = false
    },
    addItem () {
      this.itemMsg.Desc = ''
      this.createItemFun()
      this.createItemVisible = true
    },
    addFinish () {
      this.createItemFun()
      this.createItemVisible = false
      this.handleCurrentChange(this.currentPage)
    },
    createVoteFun () {
      this.$http.post('http://localhost:12612/api/vote', this.voteMsg)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '创建成功'
            })
            this.itemMsg.VoteId = res.data.VoteId
            console.log('创建成功')
          } else {
            this.$message({
              type: 'error',
              message: '创建失败'
            })
          }
        })
      this.dialogVisible = false
      this.createItemVisible = true
    },
    closeItemdialog () {
      this.createItemVisible = false
    },
    createItemFun () {
      this.$http.post('http://localhost:12612/api/item', this.itemMsg)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '添加成功'
            })
          } else {
            this.$message({
              type: 'error',
              message: '添加失败'
            })
          }
        })
    },
    handleCurrentChange (val) {
      let url = 'http://localhost:12612/api/vote/' + this.currentPage + '?userId=' + sessionStorage.UserId
      this.tableData = []
      this.$http.get(url).then(res => {
        let response = res.data
        if (response.State === 1) {
          this.tableData = response.items
        }
      })
    },
    getPageNum () {
      let getPageNumUrl = 'http://localhost:12612/api/getpagenum?userid=73'
      this.$http.get(getPageNumUrl).then(res => {
        this.totalVotes = res.data.PageNum * 10
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
.voter .el-main {
  min-height: 630px;
  background-color: #f1f1f1;
  color: #333;
  text-align: center;
}
.voter .el-header, .el-footer {
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
  .voter .block{
    position: relative;
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
