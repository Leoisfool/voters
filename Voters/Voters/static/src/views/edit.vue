<template>
  <div class="edit">
    <el-container>
      <el-header>
        <el-row :gutter="20">
          <el-col :span="2">
            <h2>Edit</h2>
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
        <!-- 编辑 -->
        <el-form ref="form" label-width="80px" class="form">
            <el-form-item class="inputStyle" label="投票主题">
                <el-input v-model="VoteInfo.Topic"></el-input>
            </el-form-item>
            <el-form-item class="inputStyle" label="投票详情">
                <el-input
                type="textarea"
                :autosize="{ minRows: 2, maxRows: 4}"
                placeholder="请输入内容"
                v-model="VoteInfo.Desc">
                </el-input>
            </el-form-item>
            <el-form-item class="inputStyle" label="是否激活">
                <el-tooltip :content="VoteInfo.VoteAble === 1?'激活':'未激活'" placement="top">
                <el-switch
                    v-model="VoteInfo.VoteAble"
                    active-color="#13ce66"
                    inactive-color="#ff4949"
                    active-value="1"
                    inactive-value="0">
                </el-switch>
                </el-tooltip>
            </el-form-item>
            <el-form-item class="inputStyle" label="选项个数">
                <el-input-number size="medium" :min="1" :max="4" v-model="VoteInfo.MultiNum"></el-input-number>
            </el-form-item>
        </el-form>
        <el-button @click="editVote()" class="addItemButton">确定</el-button>
        <br>
        <br>
        <el-table
          :data="itemData"
          class="itemTable">
            <el-table-column
            label="修改选项"
            width="140">
            <template slot-scope="scope">
                <el-popover trigger="hover" placement="top">
                <p>选项内容: {{ scope.row.Desc }}</p>
                <p>票   数: {{ scope.row.Score }}</p>
                <div slot="reference" class="name-wrapper">
                    <el-tag size="medium">{{ scope.row.Desc }}</el-tag>
                </div>
                </el-popover>
            </template>
            </el-table-column>
            <el-table-column label=" ">
            <template slot-scope="scope">
                <el-button
                size="mini"
                @click="itemEdit(scope.$index, scope.row)">编辑</el-button>
                <el-button
                size="mini"
                type="danger"
                @click="itemDelete(scope.$index, scope.row)">删除</el-button>
            </template>
            </el-table-column>
        </el-table>
        <el-button type="primary" class="addItemButton" @click="addItem()">添加选项</el-button>
      </el-main>
    </el-container>

    <!-- 编辑item -->
    <el-dialog
      title="编辑选项"
      :visible.sync="editItemVisible"
      width="40%"
      :before-close="closeItemdialog">
      <span ref="itemsBox">
        选项内容<el-input v-model="editItemInfo.Desc"></el-input>
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="confirmEditItem()">确 定</el-button>
      </span>
    </el-dialog>
    <!-- 添加item -->
    <el-dialog
      title="添加选项"
      :visible.sync="addItemVisible"
      width="40%"
      :before-close="closeItemdialog">
      <span ref="itemsBox">
        选项内容<el-input v-model="addItemInfo.Desc"></el-input>
      </span>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addItemFun()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  data () {
    return {
      VoteInfo: {},
      itemData: [],
      editItemVisible: false,
      addItemVisible: false,
      editItemInfo: {
        ItemId: 1,
        VoteId: 1,
        Desc: '还没有呢',
        DescPicUrl: 'XXXX',
        Token: sessionStorage.Token
      },
      delItemInfo: {},
      addItemInfo: {
        Desc: '还没有呢'
      }
    }
  },
  mounted () {
    this.getVoteInfo()
  },
  computed: {},
  methods: {
    addItem () {
      this.addItemInfo.Desc = ''
      this.addItemVisible = true
      this.addItemInfo.VoteId = sessionStorage.VoteId
      this.addItemInfo.Token = sessionStorage.Token
    },
    addItemFun () {
      this.$http.post('http://localhost:12612/api/item', this.addItemInfo)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '添加成功'
            })
            this.getVoteInfo()
          } else {
            this.$message({
              type: 'error',
              message: '添加失败了'
            })
          }
        })
        .catch(res => {
          this.$message({
            type: 'error',
            message: res.data
          })
        })
      this.addItemVisible = false
    },
    itemDelete (index, row) {
      this.delItemInfo = row
      this.delItemInfo.Token = sessionStorage.Token
      this.$confirm('此操作将永久删除该文件, 是否继续?', '删除选项', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      })
        .then(() => {
          this.$http.post('http://localhost:12612/api/deleteitem', this.delItemInfo)
            .then(res => {
              if (res.data.State === 1) {
                this.$message({
                  type: 'success',
                  message: '删除成功!'
                })
                this.getVoteInfo()
              } else {
                this.$message.error('删除失败')
              }
            })
            .catch(res => {
              this.$message.error('出错了')
            })
        })
        .catch(() => {
          this.$message({
            type: 'info',
            message: '已取消删除'
          })
        })
    },
    itemEdit (index, row) {
      this.editItemInfo = row
      this.editItemVisible = true
    },
    confirmEditItem () {
      debugger
      this.editItemInfo.Token = sessionStorage.Token
      this.editItemInfo.UserId = sessionStorage.UserId
      this.$http.put('http://localhost:12612/api/item', this.editItemInfo)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '修改成功'
            })
          } else {
            this.$message.error('修改失败')
          }
        })
        .catch(res => {
          this.$message.error('进入了catch里面')
        })
      this.getVoteInfo()
      this.closeItemdialog()
    },
    closeItemdialog () {
      this.editItemVisible = false
      this.addItemVisible = false
    },
    getVoteInfo () {
      let url = 'http://localhost:12612/api/vote?id=' + sessionStorage.VoteId
      this.$http.get(url).then(res => {
        this.VoteInfo = res.data
        this.switch()
        let ids = res.data.ItemIds
        this.itemData = []
        ids.forEach(id => {
          let getItemUrl = 'http://localhost:12612/api/item?ItemId=' + id
          this.$http.get(getItemUrl).then(itemRes => {
            this.itemData.push(itemRes.data)
          })
        })
      })
    },
    switch () { // 编辑Vote时修改参数
      this.VoteInfo.Token = sessionStorage.Token
      if (this.VoteInfo.VoteAble === '投票ing') {
        this.VoteInfo.VoteAble = 1
      } else {
        this.VoteInfo.VoteAble = 0
      }
    },
    editVote () {
      debugger
      this.$http.put('http://localhost:12612/api/vote', this.VoteInfo)
        .then(res => {
          if (res.data.State === 1) {
            this.$message({
              type: 'success',
              message: '编辑成功'
            })
          }
        })
        .catch(res => {
          this.message.error('上传失败')
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

<style>
.grid-content {
  min-height: 36px;
}

.edit .headerLink {
  float: right;
  padding-right: 10px;
}
.edit .headerLink .el-dropdown-link .icon {
  font-size: 1.9rem;
}
.edit .el-main {
  min-height: 630px;
  background-color: #f1f1f1;
  color: #333;
  text-align: center;
}
.edit .el-header,
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 60px;
}
h2 {
  color: rgb(63, 48, 48);
}
.inputStyle{
    text-align: left;
}
.addItemButton{
  float: right;
  margin: 10px 0 20px 0;
}
.itemTable{
  width: 100%;
}
@media all and (min-width: 1000px) {
  .itemTable{
    width: 70%;
    margin: 0 15%;
  }
  .edit .form{
    width: 70%;
    margin: 0 auto;
  }
}
</style>
