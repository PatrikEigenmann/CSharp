
using System.Management.Automation;

namespace MyCmdlet
{
    [Cmdlet(VerbsCommon.Get, "Greeting")]
    public class MyCmdlet : Cmdlet
    {

        protected override void ProcessRecord()
        {
            WriteObject($"Hello Cmdlet World!");
        }
    }
}