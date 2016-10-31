using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WebSaver
{
    public partial class Form1 : Form
    {
        HtmlToWord hw = new HtmlToWord();
        public Form1()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;

            string domainName = GetDomainName(url);


            string response = Http.GetHtml(url, 5000);
            
            Regex reg = new Regex("(?<=<a href=\")(.*?)(?=\" target=\"_blank\"><img)", RegexOptions.IgnoreCase);//[^(<td>))] 
            MatchCollection mc = reg.Matches(response);

            foreach (Group k in mc)
            {
                saveOneHtml( "http://" +domainName+k.Value);
            }

            //saveOneHtml(url);

            lbState.Text = "全部完毕";
        }
        void saveOneHtml(string url)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;//当前路径 X:\xxx\xxx\ (.exe文件所在的目录+"\")
            string response = Http.GetHtml(url, 5000);
            lbState.Text = "正在请求网页";
            tbResponse.Text = response;
            hw.SetHtml(response);
            lbState.Text = "正在保存word";

            hw.title = windowsFileNameEscape(hw.title);
            string filepath = path + hw.title;
            
            hw.SaveToFile(path + hw.title);
        }
        string windowsFileNameEscape(string fn)
        {
            // <>,/,\,|,:,"",*,?
            string r = fn.Replace("|", "丨");
            r = r.Replace("?", "？");
            r = r.Replace("\'", "’");
            r = r.Replace("\"", "“");
            r = r.Replace(":", "：");
            r = r.Replace("?", "？");
            return r;
        }
        public static string GetDomainName(string url)
        {
            if (url == null)
            {
                throw new Exception("输入的url为空");
            }
            Regex reg = new Regex(@"(?<=[://])([\w-]+\.)+[\w-]+/?", RegexOptions.IgnoreCase);
            return reg.Match(url, 0).Value.Replace("/", string.Empty);
        }
    }
}