using CC.Jift.IBLL;
using CC.Jift.IDAL;
using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CC.Jift.BLL
{
    public class MailBll : BaseBll<mail>,IMailBll
    {
        public MailBll(IBaseDal<mail> cd) : base(cd)
        {
            CurrentDal = cd;
        }
    }
}
