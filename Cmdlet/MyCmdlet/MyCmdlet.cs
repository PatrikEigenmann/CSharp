
using System.Management.Automation;

namespace MyCustomCmdlet
{
    [Cmdlet(VerbsCommon.Get, "CustomData")]
    public class MyCmdlet : Cmdlet
    {

        protected override void ProcessRecord()
        {
            WriteObject($"Hello Cmdlet World!");
        }
    }
}
