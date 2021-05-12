using CC.Jift.IBLL;
using CC.Jift.IDAL;
using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CC.Jift.BLL
{

    public class MyFileBll : BaseBll<myfile>, IMyFileBll
    {
        public MyFileBll(IBaseDal<myfile> cd) : base(cd)
        {
            CurrentDal = cd;
        }
        public int UpdataList(List<myfile> myfiles)
        {
            foreach (var k in myfiles)
            {
                k.filename = "";
                k.filedown = "";
                k.sub = 0;
                k.time = "";
                CurrentDal.Update(k);
            }
            return DbSession.SaveChanges();//这里把SaveChanges方法提到了循环体外，自然就与数据库交互一次
        }
    }
}
