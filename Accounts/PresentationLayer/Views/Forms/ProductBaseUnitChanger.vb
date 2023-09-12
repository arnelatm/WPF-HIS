Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ProductBaseUnitChanger
        Implements IUtilityView

        Private _productIdNo As Int32
        Private _baseUnitIdNo As Int16
        Public Event UtilityButtonClicked(parameters As Object) Implements IUtilityView.UtilityButtonClicked

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

        Public ReadOnly Property UtilityName As String Implements IUtilityView.UtilityName
            Get
                Return "ProductBaseUnitChanger"
            End Get
        End Property

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
            Dim parameters As Object = {"IdNo", _productIdNo, "BaseUnitIdNo", _baseUnitIdNo, "NewUnitIdNo", cboNewUnitIdNo.SelectedValue}
            RaiseEvent UtilityButtonClicked(parameters)
        End Sub


    End Class

End Namespace