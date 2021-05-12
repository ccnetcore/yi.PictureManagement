 <template>
  <div>
    <div class="bg-white mt-3 mb-4 py-2 px-5 shadow-sm row">
      <div id="myHeader" class="col-xl-8 bg-blue mx-auto">
        <h4>
          <strong>{{ noteData.title }}</strong>
          <h6 style="color: #606266">
            发布时间：<em>{{ noteData.time }}</em>
          </h6>
        </h4>
        <p>{{ noteData.contents }}</p>

        <p>
          <router-link :to="{ name: 'Home' }"
            ><el-button type="warning" plain>返回首页</el-button></router-link
          ><el-button type="primary" plain>回复</el-button>
        </p>
      </div>
    </div>
    <div class="container-xl my-xl-2 con p-0">
      <div class="row justify-content-center">
        <div class="col-lg-9 col-12 my-xl-2">
          <div class="py-3 col-12 shadow-sm text-left bg-white">
            <div v-show="!exit">
              <h4><strong>暂无评论！赶紧来抢沙发吧!!!</strong></h4>
            </div>
            <div v-show="exit">
              <div v-for="(item, i) in commentList" :key="i">
                <h4>
                  <strong>第{{ i + 1 }}楼</strong>
                  <h6 style="color: #606266">
                    发布时间：<em>{{ item.time }}</em>
                  </h6>
                </h4>
                <p>{{ item.contents }}</p>

                <p><el-button type="primary" plain>点赞</el-button></p>
                <hr />
              </div>
            </div>
          </div>
        </div>

        <div class="col-lg-3 col-12 my-xl-2 row">
          <div>
            <div class="pt-3 col-12 shadow-sm text-center bg-white">
              <div class="row">
                <div class="col-xl-3 col-lg-6 col-3">
                  <img
                    src="\images\分享共享.png"
                    class="figure-img img-fluid rounded"
                    alt="..."
                  />
                  <a
                    ><figcaption class="figure-caption">下载数据</figcaption></a
                  >
                </div>
                <div class="col-xl-3 col-lg-6 col-3">
                  <img
                    src="\images\列表清单.png"
                    class="figure-img img-fluid rounded"
                    alt="..."
                  />
                  <a
                    ><figcaption class="figure-caption">重置提交</figcaption></a
                  >
                </div>
                <div class="col-xl-3 col-lg-6 col-3">
                  <img
                    src="\images\通知公告.png"
                    class="figure-img img-fluid rounded"
                    alt="..."
                  />
                  <a
                    ><figcaption class="figure-caption">重置文件</figcaption></a
                  >
                </div>
                <figure class="col-xl-3 col-lg-6 col-3">
                  <img
                    src="\images\邮件邮箱.png"
                    class="figure-img img-fluid rounded"
                    alt="..."
                  />
                  <a
                    ><figcaption class="figure-caption">邮件提醒</figcaption></a
                  >
                </figure>
              </div>

              <div class="row">
                <div class="col-6 border-top p-2">管理员</div>
                <div class="col-6 border-top border-left p-2">究极权限</div>
              </div>
            </div>

            <div class="pt-3 my-2 col-12 shadow-sm text-center bg-white">
              <div class="row border-bottom">
                <div class="col-12">
                  <p>
                    <img
                      style="height: 24px"
                      src="\images\sub_account.png"
                      class="img-fluid"
                    />数据中心
                  </p>
                </div>
              </div>
              <div class="row my-2" style="color: darkgray">
                <div class="col-6 border-right p-2">
                  <a>提交总数</a><br />
                  <a class="text-primary"><strong>666</strong></a
                  ><br />
                  <a
                    ><small
                      >较前日上升<span class="text-primary">123%</span></small
                    ></a
                  >
                </div>
                <div class="col-6 p-2">
                  <a>未提交数</a><br />
                  <a class="text-primary"><strong>666</strong></a
                  ><br />
                  <a
                    ><small
                      >较前日上升<span class="text-primary">123%</span></small
                    ></a
                  >
                </div>
              </div>
              <div class="row border-top pt-2">
                <div class="col-12">
                  <p>腾讯云安全保护中</p>
                </div>
              </div>
            </div>

            <div class="my-2 col-12 shadow-sm">
              <div class="row">
                <div
                  id="carouselExampleSlidesOnly"
                  class="carousel slide"
                  data-ride="carousel"
                >
                  <div class="carousel-inner">
                    <div class="carousel-item active">
                      <img
                        src="\images\3e3ce85346f6b5b9a3eb53d813d47780.jpeg"
                        class="d-block w-100"
                        alt="..."
                      />
                    </div>
                    <div class="carousel-item">
                      <img
                        src="\images\22a9106001f83c855e968d90c66d8cc8.jpeg"
                        class="d-block w-100"
                        alt="..."
                      />
                    </div>
                    <div class="carousel-item">
                      <img
                        src="\images\d7aa640a17da9cf651edaa48f49d0870.jpeg"
                        class="d-block w-100"
                        alt="..."
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
</style>
<script>
import comment from "@/api/comment";
import note from "@/api/note";
export default {
  data() {
    return {
      commentList: [],
      noteData: [],
      exit: false,
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      const noteid = this.$route.params.noteid;
      const r = note.getById(noteid);
      r.then((resp) => {
        const myresp = JSON.parse(resp.data);
        if (myresp.flag) {
          this.noteData = myresp.data;

          const p = comment.getList(noteid);
          p.then((resp) => {
            const myresp = JSON.parse(resp.data);
            if (myresp.flag) {
              this.commentList = myresp.data;
              if (this.commentList.length > 0) {
                this.exit = true;
              }
            }
          });
        }
      });
    },
  },
};
</script>

