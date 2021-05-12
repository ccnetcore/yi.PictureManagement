using CC.Jift.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CC.Jift.IBLL
{
    public interface IStudentAddOrDel
    {
       student Add(student mystudent);
        bool Delete(student mystudent);
    }
}
