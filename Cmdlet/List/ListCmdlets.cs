/* ----------------------------------------------------------------------------------
 * ListCmdlet.cs - This class represents an Cmdlet that checks what IP addresses
 * in a given Ip range are online or active. Simply call in the Windows PowerShell
 * get-ip 192.168.1.* or what ever range you'd like to test where "*" is the wild-
 * cat. In the example above, the Cmdlet checks from 192.168.1.1 to 192.168.1.254 every
 * single host if online or not.
 * ----------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann
 * eMail:   p.eigenmann@gmx.net
 * GitHub:  www.github.com/PatrikEigenmann/CSharp
 * ----------------------------------------------------------------------------------
 * Change Log:
 * Fri 2025-01-10 File created & basic implementation created.          Version 00.01
 * ---------------------------------------------------------------------------------- */
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
