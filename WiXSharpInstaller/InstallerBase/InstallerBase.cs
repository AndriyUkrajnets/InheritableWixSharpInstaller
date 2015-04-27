using System;
using WixSharp;

namespace InstallerCommonBase
{
    public class InstallerBase
    {
        public Project InstallerProject { get; set; }

        public virtual string ActiveConfigurationName
        {
            get
            {
                #if(DEBUG)
                    return "Debug";
                #else
                    reutrn "Release";
                #endif
            }
        }

        /// <summary>
        /// Returns 
        /// </summary>
        public virtual string ActivePlatformName
        {
            get
            {
                return Environment.Is64BitProcess ? "x64" : "x86";
            }
        }

        protected InstallerBase(string projectName, string projectOutFileName, Guid projectGuid)
        {
            InstallerProject = new Project
            {
                Name = projectName,
                OutFileName = projectOutFileName,
                GUID = projectGuid,
                UI = WUI.WixUI_InstallDir,
                ControlPanelInfo = {Manufacturer = "DreamTeam Company"}
            };
        }

        protected InstallerBase(string projectName, string projectOutFileName)
            : this(projectName, projectOutFileName, Guid.NewGuid())
        {
        }
    }
}