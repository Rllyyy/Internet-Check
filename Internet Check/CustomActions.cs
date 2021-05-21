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
using Microsoft.Win32.TaskScheduler;
using System.Windows.Forms;

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
            removeTaskScheduler();
            //Remove temp files
            base.Dispose();
        }

        //Close the (old) Application on install if it hasn't been closed by the user. (Happens when updating from the app). 
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            closeProcessIfActive();
            //Remove temp files
            base.Dispose();
        }

        //Delete the file Internet Check.InstallState (created when using custom actions in setup)
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete(Context.Parameters["TARGETDIR"].ToString() + "Internet Check.InstallState");
            try
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\4PointsInteractive\Internet-Check\Updates", true);
            }
            catch
            {
            }
            
            //Remove temp files
            base.Dispose();
        }

        //Close process for the rare case that the uninstaller doesn't catch the open process
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            closeProcessIfActive();
            //Remove temp files
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
                catch
                {}                
            }
        }

        private void removeTaskScheduler()
        {
            if (isRegistered())
            {
                //TaskSceduler by https://github.com/dahall/TaskScheduler
                using (TaskService ts = new TaskService())
                {
                    try
                    {
                        ts.RootFolder.DeleteTask("Internet-Check", false);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private bool isRegistered()
        {
            using (TaskService service = new TaskService())
            {
                if (service.RootFolder.AllTasks.Any(t => t.Name == "Internet-Check")) return true;
                else return false;
            }
        }
    }
}
