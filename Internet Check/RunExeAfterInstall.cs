using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.Security.Permissions;
using System.IO;

namespace Internet_Check
{
    [RunInstaller(true)]
    public partial class RunExeAfterInstall : System.Configuration.Install.Installer
    {
        public RunExeAfterInstall()
        {
            InitializeComponent();
        }

        //Source: https://stackoverflow.com/questions/3172406/create-custom-action-to-start-application-and-exit-installer
        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
            System.Diagnostics.Process.Start(Context.Parameters["TARGETDIR"].ToString() + "Internet Check.exe");
            //move temp files
            base.Dispose();
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Internet Check.InstallState");
            base.Dispose();
            //base.Uninstall(savedState);
        }
    }
}
