using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CC.Jift.Common
{
    public static class SendMail
    {
        public static bool Mail(string Mail_To, string Mail_Body)//发送邮件
        {
            string Mail_From = "Q454313500@163.com";
            string Mail_Subject = "18软件本科1班青年大学习截图上交提醒";
            //try
            //{
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Mail_From);
                mailMessage.To.Add(new MailAddress(Mail_To));
                mailMessage.Subject = Mail_Subject;
                mailMessage.Body = Mail_Body;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.163.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Mail_From, "FYRLHWPUQUCGGGJN");
                client.Send(mailMessage);
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public static string GetRandomString(int length = 4, string custom = "")//得到随机数
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            str += "0123456789";
            str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
}
