using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Timers;
namespace ConsoleOrayDnsServer
{
    class Program
    {

        static void Main(string[] args)
        {
            //args[0]格式为"花生壳用户名|密码|域名|绑定的IP地址（不填默认绑定本机公网IP地址）"
            string[] userInfo ;
            UserInfo user = new UserInfo("用户名", "密码", "域名", "绑定的IP地址");
            string url = "http://ddns.oray.com/ph/update?hostname=" + user.DomainName + "&myip=" + user.IP;
            try
            {
                Console.WriteLine(args[0]);
                userInfo = args[0].Split("|");
                if (userInfo.Length == 3)
                {
                    user.UserName = userInfo[0];
                    user.UserPwd = userInfo[1];
                    user.DomainName = userInfo[2];
                    url = "http://ddns.oray.com/ph/update?hostname=" + user.DomainName;
                }
                else if(userInfo.Length == 4)
                {
                    user.UserName = userInfo[0];
                    user.UserPwd = userInfo[1];
                    user.DomainName = userInfo[2];
                    user.IP = userInfo[3];
                    url = "http://ddns.oray.com/ph/update?hostname=" + user.DomainName + "&myip=" + user.IP;
                }
                else
                {
                    Console.WriteLine("启动参数有误，将按默认配置解析！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("启动参数有误，将按默认配置解析！");
            }
            while (true)
            {
                try
                {
                    Console.WriteLine(url);
                    Console.WriteLine("正在进行Dns解析...");
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                    webRequest.Method = "GET";
                    webRequest.UserAgent = "oray";
                    NetworkCredential nc = new NetworkCredential(user.UserName, user.UserPwd);
                    webRequest.Credentials = nc;
                    using (WebResponse wr = webRequest.GetResponse())
                    {
                        var stream = wr.GetResponseStream();

                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string result = reader.ReadLine();
                            Console.WriteLine(result);
                        }
                    }
                    Thread.Sleep(600000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public class UserInfo
        {

            public UserInfo(string userName, string userPwd, string domainName, string ip)
            {
                UserName = userName;
                UserPwd = userPwd;
                DomainName = domainName;
                IP = ip;
            }
            public string UserName { get; set; }
            public string UserPwd { get; set; }
            public string DomainName { get; set; }
            public string IP { get; set; }

        }
    }
}
