Imports Microsoft.VisualBasic

Public Class Class1

    Private OrigCombobox As CBFormCtrl
    Dim cboConrol As New CtComboBox
    origComboBox = cboControl
    OrigCombobox = ControlFactory.CopyToObject(cboContactIdNo)

    ' do some things to change the control (cboControl)
    ' 
    '
    ' finish the changes

    Dim currentComboBox As CBFormCtrl = ControlFactory.CopyToObject(cboConrol)
    Dim compareLogic As CompareLogic = New CompareLogic()
    compareLogic.Config.MaxDifferences = 1000
    Dim result As ComparisonResult = compareLogic.Compare(currentComboBox, OrigCombobox)
    If Not result.AreEqual Then
        MessageBox.Show(result.DifferencesString)
    End If

End Class
