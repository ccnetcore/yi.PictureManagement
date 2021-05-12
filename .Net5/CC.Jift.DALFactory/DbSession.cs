using CC.Jift.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.DALFactory
{
    public class DbSession : IDbSession
    {
        public int SaveChanges()
        {
            return DbContentFactory.GetCurrentDbContent().SaveChanges();
        }
    }
}
