/* ----------------------------------------------------------------------------------
 * GetIpCommand.cs - This class represents an Cmdlet that checks what IP addresses
 * in a given Ip range are online or active. Simply call in the Windows PowerShell
 * get-ip 192.168.1.* or what ever range you'd like to test where "*" is the wild-
 * cat. In the example above, the Cmdlet checks from 192.168.1.1 to 192.168.1.254 every
 * single host if online or not.
 * ----------------------------------------------------------------------------------
 * Author:  Patrik Eigenmann
 * eMail:   p.eigenmann@gmx.net
 * ----------------------------------------------------------------------------------
 * Change Log:
 * Fri 2025-01-10 File created & basic implementation created.          Version 00.01
 * ---------------------------------------------------------------------------------- */
using System;
using System.Collections;
using System.Management.Automation;
using System.Net.NetworkInformation;

using Samael.ConsoleTools;

/// <summary>
/// This class represents an Cmdlet that checks what IP addresses
/// in a given Ip range are online or active. Simply call in the Windows PowerShell
/// get-ip 192.168.1.* or what ever range you'd like to test where "*" is the wild-
/// cat. In the example above, the Cmdlet checks from 192.168.1.1 to 192.168.1.254 every
/// single host if online or not.
/// </summary>
[Cmdlet(VerbsCommon.Get, "Ip")]
public class GetIpCommand : Cmdlet
{
    /// <summary>
    /// This is the IP Range with the wildcat.
    /// </summary>
    [Parameter(Position = 0, Mandatory = true)]
    public required string IPRange { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private ArrayList IPAddresses { get; set; } = new ArrayList();

    /// <summary>
    /// The method ProcessRecord() is called when the command get-ip
    /// was invoked in the Windows PowerShell.
    /// </summary>
    protected override void ProcessRecord()
    {
        ProgressBar progressBar = new ProgressBar("Pinging IP Addresses " + IPRange, 254, "=", "|", 50);
        var baseIp = IPRange.TrimEnd('*');
        for (int i = 1; i <= 254; i++)
        {
            string ipToPing = baseIp + i;
            PingHost(ipToPing);

            progressBar.Update();
        }

        foreach(var ip in IPAddresses)
        {
            WriteObject(ip + " is active.");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ipAddress"></param>
    private void PingHost(string ipAddress)
    {
        using (var ping = new Ping())
        {
            try
            {
                var reply = ping.Send(ipAddress);
                if (reply.Status == IPStatus.Success)
                {
                    //WriteObject($"{ipAddress} is active.");
                    IPAddresses.Add(ipAddress);
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "PingFailed", ErrorCategory.OperationStopped, ipAddress));
            }
        }
    }
}
