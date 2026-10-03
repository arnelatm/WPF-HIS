using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

[assembly: AssemblyTitle("Clinic Information System Launcher")]
[assembly: AssemblyDescription("Redirects the legacy Accounts shortcut to the approved ClickOnce deployment.")]
[assembly: AssemblyCompany("AATM Software")]
[assembly: AssemblyProduct("Clinic Information System Launcher")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

internal static class AccountsClickOnceLauncher
{
    private const string DeploymentPath = @"\\IBN-SERVER\ISP\COAccounts\Accounts.application";
    private const string DeploymentProvider = "file://ibn-server/ISP/COAccounts/Accounts.application";
    private const string PublicKeyToken = "38a655a256ce2e97";

    [STAThread]
    private static int Main(string[] args)
    {
        bool verifyOnly = args.Length == 1 && args[0] == "--verify";
        if (args.Length > 0 && !verifyOnly)
        {
            return 2;
        }

        try
        {
            ValidateDeployment();
            if (!verifyOnly)
            {
                Process.Start(new ProcessStartInfo(DeploymentPath) { UseShellExecute = true });
            }
            return 0;
        }
        catch (Exception ex)
        {
            if (!verifyOnly)
            {
                MessageBox.Show(
                    "Clinic Information System could not open. Check your network connection and try again." +
                    Environment.NewLine + Environment.NewLine +
                    "تعذر فتح نظام معلومات العيادة. تحقق من اتصال الشبكة ثم حاول مرة أخرى." +
                    Environment.NewLine + Environment.NewLine + ex.Message,
                    "Clinic Information System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 1;
        }
    }

    private static void ValidateDeployment()
    {
        var settings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Prohibit,
            XmlResolver = null,
            MaxCharactersInDocument = 1024 * 1024
        };
        var document = new XmlDocument { XmlResolver = null };
        using (XmlReader reader = XmlReader.Create(DeploymentPath, settings))
        {
            document.Load(reader);
        }

        XmlElement identity = document.SelectSingleNode(
            "/*[local-name()='assembly']/*[local-name()='assemblyIdentity']") as XmlElement;
        XmlElement provider = document.SelectSingleNode(
            "/*[local-name()='assembly']/*[local-name()='deployment']/*[local-name()='deploymentProvider']") as XmlElement;
        Version version;
        if (identity == null || provider == null ||
            !String.Equals(identity.GetAttribute("name"), "Accounts.application", StringComparison.Ordinal) ||
            !String.Equals(identity.GetAttribute("publicKeyToken"), PublicKeyToken, StringComparison.OrdinalIgnoreCase) ||
            !Version.TryParse(identity.GetAttribute("version"), out version) ||
            !String.Equals(provider.GetAttribute("codebase"), DeploymentProvider, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("The approved Clinic Information System deployment is unavailable.");
        }
        // ClickOnce performs manifest signature, trust and payload verification on activation.
    }
}
