/*=============================================================================
#     FileName: Program.cs
#         Desc: 
#       Author: WangHeng
#        Email: me@wangheng.org
#     HomePage: http://wangheng.org
#      Version: 0.0.1
#   LastChange: 2012-06-08 14:24:57
#      History:
=============================================================================*/
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace Cron
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Cron() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
