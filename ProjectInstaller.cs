/*=============================================================================
#     FileName: ProjectInstaller.cs
#         Desc: 
#       Author: WangHeng
#        Email: me@wangheng.org
#     HomePage: http://wangheng.org
#      Version: 0.0.1
#   LastChange: 2012-06-08 14:25:04
#      History:
=============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Cron
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
