Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ProductBaseUnitChanger
        Implements IUtilityView

        Private _productIdNo As Int32
        Private _baseUnitIdNo As Int16
        Public Event UtilityButtonClicked(utilityName As String, parameters As Object) Implements IUtilityView.UtilityButtonClicked

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(productIdNo As Int32, productName As String, unitIdNo As Int16, unitName As String, unitList As Object)

            ' This call is required by the designer.
            InitializeComponent()
            _productIdNo = productIdNo
            _baseUnitIdNo = unitIdNo
            txtProductName.Text = productName
            txtOldUnitIdNo.Text = unitName
            cboNewUnitIdNo.EditingMode = True
            cboNewUnitIdNo.DataSource = unitList

        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        'Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '    RaiseEvent FormLoad()
        '    'If UserIsASuperAdministrator() Then
        '    '    btnChangeUnit.Enabled = True
        '    'End If
        '    'RaiseEvent DataSourceCreator("Unit", "UnitLists", Nothing, Nothing)
        'End Sub

        Private Sub btnChangeUnit_Click(sender As Object, e As EventArgs) Handles btnChangeUnit.Click
            If _baseUnitIdNo <> cboNewUnitIdNo.SelectedValue Then
                Dim parameters As Object = {"productIdNo", _productIdNo, "oldUnitIdNo", _baseUnitIdNo, "newUnitIdNo", cboNewUnitIdNo.SelectedValue}
                RaiseEvent UtilityButtonClicked("ProductBaseUnitChanger", parameters)
                Close()
            End If
        End Sub


    End Class

End Namespace