<template>
  <div>
<h4>
              <p id="tit"><em>JIFT</em><strong>-文件</strong></p>
              <p><strong>快捷提交</strong></p>
            </h4>

      <el-form :model="form" status-icon ref="form">
        <el-row type="flex" justify="center">
          <el-col :span="22">
            <el-form-item
              label="第一步:"
            
              prop="uname"
            >
         
              <el-input v-model="form.uname" style="width:60%" placeholder="请输入姓名" auto-complete="off"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row type="flex" justify="center">
          <el-col :span="22">
            <el-form-item label="第二步:">
              <el-upload
                name="formFile"
                class="upload-demo"
                ref="upload"
                :with-credentials="true"
                :limit="1"
                :file-list="fileList"
                :action="uploadUrl()"
                :on-change="addFile"
                :on-success="successResp"

                :auto-upload="false"
                :data="this.form"
              >
                <el-button size="small" type="primary">选择文件</el-button>
              </el-upload>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
 
      <div class="text-center">

        <el-button style="width:100%" type="success" @click="insert('form')"
          >确认提交</el-button
        >
      </div>


        <hr />
            <div>
            <h4>
              <strong>未提交学生</strong><em><h6>管理员点击设置会员</h6></em>
            </h4>

            <a
              @click="gvip(item.id)"
              v-for="(item, i) in nodata"
              :key="i"
              class="btn btn-outline-warning text-warning"
              >{{ item.uname }}</a
            >

            <p><a class="text-info">详细了解</a></p>
            <hr />
          </div>
          <div>
            <h4>
              <strong>已提交学生</strong><em><h6>管理员点击重置数据</h6></em>
            </h4>

            <a
               @click="resFile(item.id)"
              v-for="(item, i) in mydata"
              :key="i"
              class="btn btn-outline-primary text-primary"
              >{{ item.uname }}</a>
            <p><a class="text-info">详细了解</a></p>
            <hr />
          </div>
     


  </div>
</template>
<script>
import home from "@/api/home";
import myfile from "@/api/myfile";
const myclassid = localStorage.getItem("class");
export default {
  data() {
    return {
            mydata: [],
            nodata: [],
            adm: false,
        form:{
            uname:"",
            classid:myclassid,
        },
      fileList: [],
      base_api:""
    };
  },
  created() {
    this.fetchData();
  },
  mounted() {
    this.base_api=process.env.VUE_APP_BASE_API;
  },
  methods: {
    fetchData() {
      const myuname = localStorage.getItem("token");
      const classid = localStorage.getItem("class");


      if (myuname != null) {
        this.adm = true;
      }
      this.mydata = [];
      this.nodata = [];
      const p = myfile.getFileList();
      p.then(resp => {
        const myresp = resp.data;
        myresp.forEach(item => {
          if (item.sub == "1") {
            this.mydata.push(item);
          } else {
            this.nodata.push(item);
          }
        });
      });

 

    },
outMy() {
      alert("登录超时!或权限不足！请重新登录！");
      localStorage.clear();
      this.$router.go(0);
    },
gvip(id) {
      const myuname = localStorage.getItem("token");
      if (myuname == null) {
        console.log("你无权这么做！");
      } else {
        const p = myfile.setVipFile(id);
        p.then(resp => {
          const myresp=JSON.parse(resp.data);
          if (myresp.flag) {
            this.fetchData();


            
            alert(myresp.message);
          } else {
            this.outMy();
          }
        });
      }
    },
resFile(id) {
      const myuname = localStorage.getItem("token");
      if (myuname == null) {
        console.log("你无权这么做！");
      } else {
        const p = myfile.resStudentFile(id);
        p.then(resp => {
          const myresp=JSON.parse(resp.data);
          if (myresp.flag) {
            this.fetchData();
            alert(myresp.message);
          } else {
            this.outMy();
          }
        });
      }
    },
    submitUpload() {
      this.$refs.upload.submit();
    },
    handleRemove(file, fileList) {
      console.log(file, fileList);
    },
    handlePreview(file) {
      console.log(file);
    },
    uploadUrl: function () {
      return this.base_api+"/file/index";
    },
    addFile(file, fileList) {
      this.fileList = fileList;
      //限制上传文件为5M
      var sizeIsSatisfy = file.size < 100 * 1024 * 1024 ? true : false;
      if (sizeIsSatisfy) {
        return true;
      } else {
        this.fileSizeIsSatisfy = false;
        return false;
      }
    },
    insert(formName) {
    this.$refs[formName].validate((valid) => {
        if (valid) {
            // if(this.fileList.length <= 0){
            //     this.$message.error("请至少上传一个文件！");
            //     return;
            // }
            // if(!this.fileSizeIsSatisfy){
            //     this.$message.error("上传失败！存在文件大小超过5M！");
            //     return;
            // }
            //手动上传文件，在点击确认的时候 校验通过才会去请求上传文件的url
            this.$refs.upload.submit();
     
        }
    });
},
successResp()
{
         this.fetchData();
            this.$message({
            type: "success",
            message: "提交成功"
          });
}
  },
};
</script>