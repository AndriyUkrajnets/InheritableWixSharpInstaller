using System;
using WixSharp;

namespace InstallerCommonBase
{
    public class InstallerBase
    {
        public Project InstallerProject { get; set; }

        protected InstallerBase(string projectName, string projectOutFileName, Guid projectGuid)
        {
            InstallerProject = new Project()
            {
                Name = projectName,
                OutFileName = projectOutFileName,
                GUID = projectGuid,
                UI = WUI.WixUI_InstallDir,
                //Codepage = "Windows-1252",
                //Language = "en-US",
            };

            InstallerProject.Manufacturer = "DreamTeam Company";
            //InstallerProject.ControlPanelInfo.Manufacturer = "DreamTeam Company";

        }

        protected InstallerBase(string projectName, string projectOutFileName)
            : this(projectName, projectOutFileName, Guid.NewGuid())
        {
        }
    }
}