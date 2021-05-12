using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Common
{
    public static class SaveFile
    {
        public static bool CreateZip(int classid)
        {
            string file_path = @"./wwwroot/StudentFile" + classid.ToString() + ".zip";
            string file_path2 = @"./wwwroot/StudentFile" + classid.ToString() + "/";
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
            }

            ZipFile.CreateFromDirectory(file_path2, file_path);
            return true;
        }
        public static bool DeleteAll(int classid)
        {
            string file_path = @"./wwwroot/StudentFile" + classid.ToString() + "/";
            if (Directory.Exists(file_path))
            {
                DelectDir(file_path);
                return true;
            }
            else
                return false;
        }
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
