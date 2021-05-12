using CC.Jift.IBLL;
using CC.Jift.IDAL;
using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CC.Jift.BLL
{
    public class MyClassBll : BaseBll<myclass>, IMyClassBll
    {
        public MyClassBll(IBaseDal<myclass> cd) : base(cd)
        {
            CurrentDal = cd;
        }
    }
}
