/*================================================
#     FileName: Cron.cs
#         Desc: 
#       Author: WangHeng
#        Email: me@wangheng.org
#     HomePage: http://wangheng.org
#      Version: 0.0.1
#   LastChange: 2012-06-09 14:24:38
#      History:
=================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Cron
{
    public partial class Cron : ServiceBase
    {
        public Cron()
        {
            InitializeComponent();
        }
        //规则文件以及log的默认路径和大小
        private const string logPath = @"c:\Cron\cron.log";
        private const string crontabPath = @"c:\Cron\crontab";
        private const double Max_logSize = 1024 * 1024;
        private List<string> Rules
        {
            get
            {
                List<string> rules = new List<string>();
                StreamReader sr = new StreamReader(crontabPath);
                string rule;
                do
                {
                    rule = sr.ReadLine();
                    if (!string.IsNullOrEmpty(rule))
                    {
                        rules.Add(rule);
                    }
                } while (!string.IsNullOrEmpty(rule));
                return rules;
            }
        }
        /// <summary>
        /// 服务启动
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            LogWritter(string.Format(@"Cron for Windows by http://wangheng.org : Service Started at [{0}]", DateTime.Now.ToString()));
            Timer timer;
            TimeSpan interval = TimeSpan.FromMinutes(1);
            timer = new Timer(new TimerCallback(obj => RefreshTask()), null, interval, interval);
            RefreshTask();
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop()
        {
            LogWritter(string.Format(@"Cron for Windows by http://wangheng.org : Service Stoped at [{0}]", DateTime.Now.ToString()));
        }

        /// <summary>
        /// 刷新并判断是否有要运行的规则
        /// </summary>
        private void RefreshTask()
        {
            foreach (var rule in Rules)
            {
                if (BingoToRun(rule))
                {
                    //System.Diagnostics.Process.Start(@"c:\ftp\ftp_backup.bat");
                    System.Diagnostics.Process.Start(rule.Split(' ')[5].ToString());
                    LogWritter(string.Format("Program or Command \"{0}\" Started at [{1}].", rule.Split(' ')[5], DateTime.Now.ToString()));
                }
                else
                {
                    LogWritter("Nothing to do...");
                }
            }
        }

        /// <summary>
        /// 判断是否满足运行条件，JianQu是DateTime的扩展方法
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        private bool BingoToRun(string rule)
        {
            string[] args = Regex.Split(rule, " ");
            if (DateTime.Now.JianQu(args[0], args[1], args[2], args[3], args[4]))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 写log文件
        /// </summary>
        /// <param name="text"></param>
        private static void LogWritter(string text)
        {
            if (File.Exists(logPath))
            {
                FileInfo fileinfo = new FileInfo(logPath);
                if (fileinfo.Length > Max_logSize)
                {
                    File.Delete(logPath);
                }
            }
            FileStream fs = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(text);
            m_streamWriter.Flush();
            m_streamWriter.Close();
            fs.Close();
        }
    }
}
