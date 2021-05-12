using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CC.Jift.IBLL
{
    public interface IMyFileBll : IBaseBll<myfile>
    {
        int UpdataList(List<myfile> myfiles);
    }
}
