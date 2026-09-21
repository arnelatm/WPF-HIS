Imports System.IO

Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public NotInheritable Class FormAbout

        Private Sub FormAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Set the title of the form.
            Dim applicationTitle As String
            If My.Application.Info.Title <> "" Then
                applicationTitle = My.Application.Info.Title
            Else
                applicationTitle = Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Text = String.Format("About {0}", applicationTitle)
            ' Initialize all of the text displayed on the About Box.
            ' TODO: Customize the application's assembly information in the "Application" pane of the project
            '    properties dialog (under the "Project" menu).
            LabelProductName.Text = My.Application.Info.ProductName
            Dim clickOnceVersion As String = "N/A (local run)"
            If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                clickOnceVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
            End If
            LabelVersion.MaximumSize = New System.Drawing.Size(0, 0)
            TableLayoutPanel.RowStyles(1).SizeType = System.Windows.Forms.SizeType.Absolute
            TableLayoutPanel.RowStyles(1).Height = 36
            LabelVersion.Text = String.Format("Assembly version: {0}{1}ClickOnce version: {2}",
                                              My.Application.Info.Version.ToString(),
                                              System.Environment.NewLine,
                                              clickOnceVersion)
            LabelCopyright.Text = My.Application.Info.Copyright
            LabelCompanyName.Text = GlobalVariables.GetEstablishmentName()
            TextBoxDescription.Text = My.Application.Info.Description
        End Sub

        Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
            Close()
        End Sub

    End Class

End Namespace
