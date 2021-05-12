using CC.Jift.IBLL;
using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.BLL
{
    public class StudentAddOrDel:IStudentAddOrDel
    {
        private IStudentBll studentBll;
        private IMailBll mailBll;
        private IMyFileBll myFileBll;
        public StudentAddOrDel(IStudentBll _studentBll,IMailBll _mailBll,IMyFileBll _myFileBll)
        {
            studentBll = _studentBll;
            mailBll = _mailBll;
            myFileBll = _myFileBll;
        }
        public student Add(student mystudent)//添加学生同时加入其他表
        {
            studentBll.Add(mystudent);
           int classid= mystudent.classid;
           string name = mystudent.name;

            myfile myfileEnity = new myfile();
            myfileEnity.classid = classid;
            myfileEnity.sub = 0;
            myfileEnity.uname = name;
            myFileBll.Add(myfileEnity);
            return mystudent;
        }
        public bool Delete(student mystudent)//添加学生同时加入其他表
        {
            bool end=  studentBll.Delete(mystudent);
            int classid = mystudent.classid;
            string name = mystudent.name;

            myfile myfileEnity= myFileBll.GetEntities(n => n.uname == name && n.classid == classid).FirstOrDefault();

            myFileBll.Delete(myfileEnity);
            return end;
        }
    }
}
