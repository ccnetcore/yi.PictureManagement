<template>
  <div>
    <el-form
      ref="searchForm"
      :inline="true"
      :model="searchWhere"
      class="demo-form-inline"
      style="margin-top:20px"
    >
      <el-form-item label="姓名" size="mini" prop="name">
        <el-input
          v-model="searchWhere.name"
          placeholder="姓名"
          style="width:150px"
        ></el-input>
      </el-form-item>
      <el-form-item
        label="学号"
        size="mini"
        prop="press"
        @click.right.prevent.native="dialogPressVisible = true"
      >
        <el-input
          v-model="searchWhere.sid"
          placeholder="学号"
          style="width:120px"
        ></el-input>
      </el-form-item>
      <el-form-item label="积分" size="mini" prop="num">
        <el-input
          v-model="searchWhere.num"
          placeholder="积分"
          style="width:150px"
        ></el-input>
      </el-form-item>

      <el-form-item label="是否提交" size="mini" prop="sub">
        <el-select
          v-model="searchWhere.sub"
          placeholder="请选择"
          style="width:120px"
        >
          <el-option
            v-for="option in bookTypeOptions"
            :key="option.type"
            :label="option.name"
            :value="option.type"
          ></el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="提交时间" size="mini" prop="time">
        <el-date-picker
          v-model="searchWhere.time"
          style="width:300px"
          type="daterange"
          align="right"
          unlink-panels
          range-separator="|"
          start-placeholder="开始日期"
          end-placeholder="结束日期"
          :picker-options="pickerOptions"
        ></el-date-picker>
      </el-form-item>
      <el-form-item size="mini" >
        <el-button type="primary" @click="fetchData">查询</el-button>
        <el-button @click="resetForm('searchForm')">重置</el-button>
        <el-button type="primary" @click="addHandle">新增</el-button>
      </el-form-item>
    </el-form>
    <el-table
      :data="bookinfolist"
      style="width: 100%;margin-top:20px"
      max-height="620px"
    >
      <el-table-column fixed type="index" label="序号" width="60">
      </el-table-column>
      <el-table-column prop="id" label="ID" width="100">
      </el-table-column>
   
      <el-table-column prop="name" label="学生姓名" width="100">
      </el-table-column>
      <el-table-column prop="sid" label="学生学号" width="100">
      </el-table-column>
      <el-table-column prop="time" label="发表时间" width="150">
      </el-table-column>
      <el-table-column prop="num" label="积分" width="100"> </el-table-column>
      <el-table-column prop="sub" label="是否提交" width="100">
        <template slot-scope="scope">
          <span>{{ scope.row.sub | bookTypeFilter }}</span>
        </template>
      </el-table-column>
      <el-table-column prop="classid" label="班级ID" width="100">
      </el-table-column>
      
      <el-table-column fixed="right" label="操作" width="150">
        <template slot-scope="scope">
          <el-button
            size="mini"
            type="primary"
            @click="handleEdit(scope.row.id)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.row.id)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <el-pagination
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
      :current-page="currentPage"
      :page-sizes="[10, 20, 30, 40]"
      :page-size="pageSize"
      layout="total, sizes, prev, pager, next, jumper"
      :total="total"
    >
    </el-pagination>

    <!-- 新增对话框 -->
    <el-dialog
      title="编辑学生信息"
      :visible.sync="dialogFormVisible"
      width="500px"
    >
      <el-form
        :model="form"
        label-width="100px"
        label-position="right"
        ref="addForm"
        style="width:400px;margin-top:-20px; "
        :rules="rules"
      >
        <el-form-item label="学号" prop="sid">
          <el-input-number v-model="form.sid"  :min="0" :max="100000" ></el-input-number>
        </el-form-item>
        <el-form-item label="姓名" prop="name">
          <el-input
            v-model="form.name"
            size="mini"
          ></el-input>
        </el-form-item>
        <el-form-item label="提交时间" prop="time">
          <el-date-picker
            size="mini"
            v-model="form.time"
            align="right"
            type="date"
            placeholder="选择日期"
            value-format="yyyy/MM/dd HH:mm:ss"
          ></el-date-picker>
        </el-form-item>
        <el-form-item label="积分" prop="num">
          <el-input-number v-model="form.num"  :min="0" :max="100" ></el-input-number>
        </el-form-item>
        <el-form-item label="是否提交" prop="sub">
          <el-select
            v-model="form.sub"
            placeholder="请选择"
            size="mini"
          >
            <el-option
              v-for="option in bookTypeOptions"
              :key="option.type"
              :label="option.name"
              :value="option.type"
            ></el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false" size="mini"
          >取 消</el-button
        >
        <el-button
          type="primary"
          @click="form.id === null ? addData('addForm') : updateData('addForm')"
          size="mini"
          >确 定</el-button
        >
      </div>
    </el-dialog>
    <!-- 选择出版社对话框 -->
    <el-dialog
      title="准备更新"
      :visible.sync="dialogPressVisible"
      width="800px"
    >
      <!-- <Press @sendData="getData"></Press> -->
    </el-dialog>
  </div>
</template>
<script>
import studentinfoApi from "@/api/studentinfo.js";
const bookTypeOptions = [
  { type: "1", name: "已提交" },
  { type: "0", name: "未提交" }
];
export default {
  data() {
    return {
      dialogFormVisible: false,
      dialogPressVisible: false,
      form: {
        id: null,
        sid: "",
        name: "",
        time:"",
        num:"",
        sub:"",
      },
      bookinfolist: [],
      total: 0,
      currentPage: 1,
      pageSize: 10,
      bookTypeOptions,
      rules: {
        name: [{ required: true, message: "请输入姓名", trigger: "blur" }],
        sub: [{ required: true, message: "请选择", trigger: "blur" }],
        sid: [
          { required: true, message: "学号不能为空", trigger: "blur" }
          // { type: "number", message: "学号必须为数字", trigger: "blur" }
        ]
      },
    pickerOptions: {
        shortcuts: [
          {
            text: "最近一周",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit("pick", [start, end]);
            }
          },
          {
            text: "最近一个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
              picker.$emit("pick", [start, end]);
            }
          },
          {
            text: "最近三个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
              picker.$emit("pick", [start, end]);
            }
          }
        ]
      },
      searchWhere: {
        id: null,
        sid: "",
        name: "",
        sub: "",
        time: "",
        num:""
      }
    };
  },
  created() {
    this.fetchData();
  },
  filters: {
    bookTypeFilter(type) {
      const booktypeobk = bookTypeOptions.find(obj => obj.type == type);
      return booktypeobk ? booktypeobk.name : null;
    }
  },
  methods: {
    fetchData() {
      console.log(this.searchWhere,this.currentPage, this.pageSize)
      studentinfoApi
    //     //   .getBookInfoList()
        .search(this.currentPage, this.pageSize, this.searchWhere)
        .then(res => {
          // const resp = res.data;  
          const resp = JSON.parse(res.data);
          this.bookinfolist = resp.data.rows;
          this.total = resp.data.total;
        });
    },
    addHandle() {
      this.dialogFormVisible = true;
      this.$nextTick(() => {
        this.$refs["addForm"].resetFields();
      });
    },
    addData(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          //
          studentinfoApi.add(this.form).then(response => {
            const resp =JSON.parse(response.data);
            if (resp.flag) {
              this.fetchData();
              this.dialogFormVisible = false;
            } else {
              this.$message({
                message: resp.message,
                type: "warning"
              });
            }
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    handleDelete(id) {
      this.$confirm("确定要删除吗?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          studentinfoApi.deleteBookById(id).then(response => {
            const resp =JSON.parse(response.data) ;
            this.$message({
              type: resp.flag ? "success" : "error",
              message: resp.message
            });
            if (resp.flag) {
              this.fetchData();
            }
          });
        })
        .catch(() => {
          console.log("cancel");
        });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    handleEdit(id) {
      this.addHandle();
      studentinfoApi.getStudentById(id).then(response => {
        const resp =JSON.parse(response.data);
         console.log(resp);
        if (resp.flag) {
          this.form = resp.data;
         
        } else {
          this.$message({
            message: resp.message,
            type: "warning"
          });
        }
      });
    },
    handleSizeChange(size) {
      this.pageSize = size;
      this.fetchData();
    },
    handleCurrentChange(currentPage) {
      this.currentPage = currentPage;
      this.fetchData();
    },
    updateData(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          studentinfoApi.update(this.form).then(response => {
            const resp =JSON.parse(response.data) ;
            if (resp.flag) {
              this.fetchData();
              this.form.id = null;
              this.dialogFormVisible = false;
            } else {
              this.$message({
                message: resp.message,
                type: "warning"
              });
            }
          });
        } else {
          return false;
        }
      });
    }
  }
};
</script>
<style scoped>
.el-pagination {
  margin-top: 40px;
}
.el-form-item{
  margin-left: 30px;
}

</style>
