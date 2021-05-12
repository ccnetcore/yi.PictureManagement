using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.IDAL
{
    public interface IDbSession
    {
        int SaveChanges();
    }
}
