/* ----------------------------------------------------------------------------------
 * GetIpCommand.cs - This class represents an Cmdlet that checks what IP addresses
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
using System;
using System.Collections;
using System.Management.Automation;
using System.Net.NetworkInformation;
using Samael;
using Samael.ConsoleTools;

/// <summary>
/// This class represents an Cmdlet that checks what IP addresses
/// in a given Ip range are online or active. Simply call in the Windows PowerShell
/// get-ip 192.168.1.* or what ever range you'd like to test where "*" is the wild-
/// cat. In the example above, the Cmdlet checks from 192.168.1.1 to 192.168.1.254 every
/// single host if online or not.
/// </summary>
[Cmdlet(VerbsCommon.Get, "Ip")]
public class GetIpCommand : Cmdlet, IVersionable, IDisposable
{
    private bool disposedValue;

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
    /// The GetVersion method is a vital feature for any class implementing the IVersionable interface.
    /// It provides a standardized way to retrieve version information, ensuring that every component
    /// can clearly communicate its version. This method is essential for maintaining consistency and
    /// reliability across the system, making it easier to manage updates and track changes. By
    /// implementing GetVersion, we ensure that our software remains robust, up-to-date, and easy to
    /// maintain, ultimately enhancing the overall user experience.
    /// </summary>
    /// <returns>
    /// A formatted string where the name of the component is the class or object name, 
    /// and the version number consists of a major and a minor number, each formatted to two digits.
    /// </returns>
    public static string GetVersion()
    {
        return VersionManager.GetInstance("GetIpCommand", 0, 1).ToString();
    }

    /// <summary>
    /// The method ProcessRecord() is called when the command get-ip
    /// was invoked in the Windows PowerShell.
    /// </summary>
    protected override void ProcessRecord()
    {
        // Create a new progress bar
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
    /// PingHost() is a helper method that pings a given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP Address</param>
    private void PingHost(string ipAddress)
    {
        using (var ping = new Ping())
        {
            try
            {
                var reply = ping.Send(ipAddress);
                if (reply.Status == IPStatus.Success)
                {
                    IPAddresses.Add(ipAddress);
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "PingFailed", ErrorCategory.OperationStopped, ipAddress));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~GetIpCommand()
    {
         // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
         Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
