using System;
using WixSharp;

namespace Installer
{
    public class Script
    {
        static public void Main(string[] args)
        {
            var installer = new Installer("DesktopApplication", "DesktopApplication installer", new Guid("5A151BE2-2AEE-40CB-9552-CF5DD00E1BCA"));
            
            var dirPath = string.Format(@"{0}\{1}\{2}", "%ProgramFiles%", installer.InstallerProject.Manufacturer, installer.InstallerProject.Name);
            
            installer.InstallerProject.Dirs = new[] { new Dir(dirPath, new Files("*")) };
            installer.InstallerProject.SourceBaseDir = @"..\..\..\..\DesktopApplication\bin\x86\Debug";

            var str = Compiler.BuildWxs(installer.InstallerProject);
            Console.WriteLine(str);

            str = Compiler.BuildMsi(installer.InstallerProject);
            Console.WriteLine(str);
        }
    }
}