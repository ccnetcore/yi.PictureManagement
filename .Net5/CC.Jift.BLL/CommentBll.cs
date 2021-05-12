using CC.Jift.IBLL;
using CC.Jift.IDAL;
using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CC.Jift.BLL
{
    public class CommentBll : BaseBll<comment>, ICommentBll
    {
        public CommentBll(IBaseDal<comment> cd) : base(cd)
        {
            CurrentDal = cd;
        }
    }
}
