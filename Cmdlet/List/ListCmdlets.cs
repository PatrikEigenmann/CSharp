using System.Management.Automation;

namespace List
{
    [Cmdlet(VerbsCommon.Get, "MyList")]
    public class ListCmdlets : Cmdlet
    {
        protected override void ProcessRecord()
        {
            // WriteObject($"                       | \n");
            WriteObject($"");
            WriteObject($" Cmdlet                 | Description");
            WriteObject($"---------------------------------------------------------------");
            WriteObject($" Get-Ip <192.168.1.*>   | Checks IP Addresses for online hosts");
            WriteObject($"                        | with * as a wildcat.");
            WriteObject($"---------------------------------------------------------------");
            WriteObject($" Get-MyList             | Will display this list");
            WriteObject($"---------------------------------------------------------------");
            WriteObject($" Get-Greetning          | The 'Hello Cmdlet World' Cmdlet");
            WriteObject($"---------------------------------------------------------------");

        }
    }
}
