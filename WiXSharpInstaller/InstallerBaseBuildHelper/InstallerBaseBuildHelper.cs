using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Build.Framework;
using Task = Microsoft.Build.Utilities.Task;

public class InstallerBaseBuildHelper : Task
{
    [Required]
    public string Values { get; set; }

    public override bool Execute()
    {
        if (string.IsNullOrEmpty(Values))
        {
            MessageBox.Show("EMPTY!!!");
        }
        else
        {
            MessageBox.Show(Values);
        }
        
        string str1 = this.Values.Replace(";;", "$(separator)");

        foreach (string str2 in str1.Split(new[] { "$(separator)" }, StringSplitOptions.RemoveEmptyEntries))
        {
            try
            {
                string[] strArray = str2.Split('=');
                Environment.SetEnvironmentVariable(strArray[0].Trim(), strArray[1].Trim());
            }
            catch
            {
            }
        }
        return true;
    }

}

