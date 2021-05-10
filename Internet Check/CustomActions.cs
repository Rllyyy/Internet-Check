using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.Security.Permissions;
using System.IO;
using System.Windows;

namespace Internet_Check
{
    [RunInstaller(true)]
    public partial class CustomActions : System.Configuration.Install.Installer
    {
        public CustomActions()
        {
            InitializeComponent();
        }

        //Source: https://stackoverflow.com/questions/3172406/create-custom-action-to-start-application-and-exit-installer
        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
            System.Diagnostics.Process.Start(Context.Parameters["TARGETDIR"].ToString() + "Internet Check.exe");
            //remove temp files
            base.Dispose();
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete(Context.Parameters["TARGETDIR"].ToString() + "Internet Check.InstallState");
            base.Dispose();
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            closeProcessIfActive();
            base.Dispose();
        }

        private void closeProcessIfActive()
        {
            foreach (var process in Process.GetProcessesByName("Internet Check"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }               
                   
            }
        }
    }
}
