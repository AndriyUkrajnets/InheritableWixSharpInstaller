using System;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using WixSharp;

namespace Installer
{
    public class Script
    {
        static public void Main(string[] args)
        {
            var installer = new Installer("DesktopApplication", "DesktopApplication installer", new Guid("5A151BE2-2AEE-40CB-9552-CF5DD00E1BCA"));

            installer.InstallerProject.SourceBaseDir = @"..\..\..\..\DesktopApplication";
            
            //Environment.SetEnvironmentVariable("bin", @"bin\$(var.Platform)\$(var.Configuration)");

            Environment.SetEnvironmentVariable("bin", string.Format(@"bin\{0}\{1}", installer.ActivePlatformName, installer.ActiveConfigurationName));

            var dirPath = string.Format(@"{0}\{1}\{2}", "%ProgramFiles%", installer.InstallerProject.ControlPanelInfo.Manufacturer, installer.InstallerProject.Name);

            installer.InstallerProject.Dirs = new[] { new Dir(dirPath, new Files(@"%bin%\*")) };

            Compiler.PreserveTempFiles = true;

            var str = Compiler.BuildWxs(installer.InstallerProject);
            Console.WriteLine(str);

            str = Compiler.BuildMsi(installer.InstallerProject);
            Console.WriteLine(str);
        }
    }
}