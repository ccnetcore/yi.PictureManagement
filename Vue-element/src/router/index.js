import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue"
import myClass from "../views/Class.vue"

import Note from "../views/Note.vue"
import StuLayout from "../views/StuLayout.vue"
import AdminLayout from "../views/AdmLayout.vue"
import studentinfo from "../views/admin/studentinfo.vue"
import adminfo from "../views/admin/adminfo.vue"
import fileinfo from "../views/admin/fileinfo.vue"
import noteinfo from "../views/admin/noteinfo.vue"
import ls from '../views/ls.vue'
import noteBody from "../components/noteBody.vue"
import imageBody from "../components/imageBody.vue"
import fileBody from "../components/fileBody.vue"
import wpBody from "../components/wpBody.vue"
Vue.use(VueRouter);

const routes = [{
        path: "/",
        name: "stu",
        component: StuLayout,
        redirect: "/class",
        children: [{
                path: "/ls",
                name: "ls",
                component: ls
            },
            {
                path: "/home",
                name: "Home",
                component: Home,
                redirect: "/noteBody",
                children: [{
                        path: "/noteBody",
                        name: "noteBody",
                        component: noteBody
                    },
                    {
                        path: "/imageBody",
                        name: "imageBody",
                        component: imageBody
                    },
                    {
                        path: "/fileBody",
                        name: "fileBody",
                        component: fileBody
                    },
                    {
                        path: "/wpBody",
                        name: "wpBody",
                        component: wpBody
                    },
                ]
            },
            {
                path: "/about",
                name: "About",
                component: About
            },
            {
                path: "/class",
                name: "Class",
                component: myClass
            },

            {
                path: "/note",
                name: "Note",
                component: Note
            }
        ]
    },
    {
        path: "/adm",
        name: "adm",
        component: AdminLayout,
        redirect: "/adminfo",
        children: [{
                path: "/adminfo",
                name: "adminfo",
                component: adminfo
            },
            {
                path: "/studentinfo",
                name: "studentinfo",
                component: studentinfo
            },
            {
                path: "/fileinfo",
                name: "fileinfo",
                component: fileinfo
            },
            {
                path: "/noteinfo",
                name: "noteinfo",
                component: noteinfo
            }

        ]
    }

];

const router = new VueRouter({
    // mode: "history",
    base: process.env.BASE_URL,
    routes
});

export default router;