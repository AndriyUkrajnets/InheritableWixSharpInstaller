using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstallerCommonBase;
using WixSharp;

namespace Installer
{
    public class Installer : InstallerBase
    {
        public Installer(string projectName, string projectOutFileName, Guid projectGuid)
            : base(projectName, projectOutFileName, projectGuid)
        {
            
        }

        public Installer(string projectName, string projectOutFileName)
            : this(projectName, projectOutFileName, Guid.NewGuid())
        {

        }
    }
}
