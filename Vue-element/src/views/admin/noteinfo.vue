<template>
  <div>
    <el-form
      ref="searchForm"
      :inline="true"
      :model="searchWhere"
      class="demo-form-inline"
      style="margin-top:20px"
    >
      <el-form-item label="作者" size="mini" prop="author">
        <el-input
          v-model="searchWhere.author"
          placeholder="作者"
          style="width:150px"
        ></el-input>
      </el-form-item>

      <el-form-item label="标题" size="mini" prop="title">
        <el-input
          v-model="searchWhere.title"
          placeholder="标题"
          style="width:150px"
        ></el-input>
      </el-form-item>

      <el-form-item label="内容" size="mini" prop="contents">
        <el-input
          v-model="searchWhere.contents"
          placeholder="标题"
          style="width:150px"
        ></el-input>
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
      <el-table-column prop="id" label="ID" width="50">
      </el-table-column>
   
      <el-table-column prop="author" label="作者" width="200">
      </el-table-column>
     
      <el-table-column prop="time" label="发表时间" width="200">
      </el-table-column>


      <el-table-column prop="title" label="标题" width="300">
      </el-table-column>

          <el-table-column prop="classid" label="班级" width="100">
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
      title="编辑文件信息"
      :visible.sync="dialogFormVisible"
      width="500px"
    >
      <el-form
        :model="form"
        label-width="100px"
        label-position="right"
        ref="addForm"
        style="width:400px;margin-top:-20px; "
      >
      
        <el-form-item label="标题" prop="title">
          <el-input
            v-model="form.title"
            size="mini"
          ></el-input>
        </el-form-item>
        <el-form-item label="内容" prop="contents">
          <el-input
            v-model="form.contents"
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
import noteinfoApi from "@/api/note.js";

export default {
  data() {
    return {
      dialogFormVisible: false,
      dialogPressVisible: false,
      form: {
        id: null,
        author: "",
        time: "",
        title: "",
        contents: "",
      },
      bookinfolist: [],
      total: 0,
      currentPage: 1,
      pageSize: 10,

      //   rules: {
      //     uname: [{ required: true, message: "请输入姓名", trigger: "blur" }],
      //     sub: [{ required: true, message: "请选择", trigger: "blur" }],
      //     // sid: [
      //     //   { required: true, message: "学号不能为空", trigger: "blur" }
      //     //   // { type: "number", message: "学号必须为数字", trigger: "blur" }
      //     // ]
      //   },
      pickerOptions: {
        shortcuts: [
          {
            text: "最近一周",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "最近一个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: "最近三个月",
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
              picker.$emit("pick", [start, end]);
            },
          },
        ],
      },
      searchWhere: {
        id: null,
        author: "",
        time: "",
        title: "",
        contents: "",
      },
    };
  },
  created() {
    this.fetchData();
  },
  //   filters: {
  //     bookTypeFilter(type) {
  //       const booktypeobk = bookTypeOptions.find(obj => obj.type == type);
  //       return booktypeobk ? booktypeobk.name : null;
  //     }
  //   },
  methods: {
    fetchData() {
      console.log(this.searchWhere, this.currentPage, this.pageSize);
      noteinfoApi
        .search(this.currentPage, this.pageSize, this.searchWhere)
        .then((res) => {
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
      this.$refs[formName].validate((valid) => {
        if (valid) {
          //
          noteinfoApi.add(this.form).then((response) => {
            const resp = JSON.parse(response.data);
            if (resp.flag) {
              this.fetchData();
              this.dialogFormVisible = false;
            } else {
              this.$message({
                message: resp.message,
                type: "warning",
              });
            }
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    handleEdit(id) {
      this.addHandle();
      noteinfoApi.getStudentById(id).then((response) => {
        const resp = JSON.parse(response.data);
        console.log(resp);
        if (resp.flag) {
          this.form = resp.data;
        } else {
          this.$message({
            message: resp.message,
            type: "warning",
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
          noteinfoApi.add(this.form).then(response => {
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
          noteinfoApi.deleteBookById(id).then(response => {
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
    updateData(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          noteinfoApi.update(this.form).then((response) => {
            const resp = JSON.parse(response.data);
            if (resp.flag) {
              this.fetchData();
              this.form.id = null;
              this.dialogFormVisible = false;
            } else {
              this.$message({
                message: resp.message,
                type: "warning",
              });
            }
          });
        } else {
          return false;
        }
      });
    },
  },
};
</script>
<style scoped>
.el-pagination {
  margin-top: 40px;
}
.el-form-item {
  margin-left: 30px;
}
</style>
