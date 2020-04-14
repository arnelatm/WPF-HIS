Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.EnumLocalization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Forms

    Public Class DepartmentEntryTv
        Implements IDepartmentView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Department"
            TvMainFieldName = "DepartmentName"
            TvSecondaryFieldName = "DepartmentCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtDepartmentCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DepartmentPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetDepartmentList()
            cacProfitCenterIDNo.DataSource = PresenterObj.GetProfitCenterList()
            cacCostCenterIDNo.DataSource = PresenterObj.GetCostCenterList()
        End Sub

#Region "Fields"

        Public Property IDNo As Integer Implements IDepartmentView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Integer? Implements IDepartmentView.ParentIdNo
            Get
                Return cacParentIdNo.GetValue()
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DepartmentCode As String Implements IDepartmentView.DepartmentCode
            Get
                Return txtDepartmentCode.Text
            End Get
            Set
                txtDepartmentCode.Text = Value
            End Set
        End Property

        Public Property DepartmentName As String Implements IDepartmentView.DepartmentName
            Get
                Return txtDepartmentName.Text
            End Get
            Set
                txtDepartmentName.Text = Value
            End Set
        End Property

        Public Property DepartmentNameAra As String Implements IDepartmentView.DepartmentNameAra
            Get
                Return txtDepartmentNameAra.Text
            End Get
            Set
                txtDepartmentNameAra.Text = Value
            End Set
        End Property

        Public Property ProfitCenterIdNo As Integer Implements IDepartmentView.ProfitCenterIdNo
            Get
                Return cacProfitCenterIDNo.GetValue()
            End Get
            Set
                cacProfitCenterIDNo.SetValue(Value)
            End Set
        End Property

        Public Property CostCenterIdNo As Integer Implements IDepartmentView.CostCenterIdNo
            Get
                Return cacCostCenterIDNo.GetValue()
            End Get
            Set
                cacProfitCenterIDNo.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IDepartmentView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property SortKey As String Implements IDepartmentView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DepartmentCode", txtDepartmentCode},
                {"DepartmentName", txtDepartmentName},
                {"DepartmentNameAra", txtDepartmentNameAra},
                {"IDNo", TxtIDNo},
                {"ParentIdNo", cacParentIdNo},
                {"CostCenterIdNo", cacCostCenterIDNo},
                {"ProfitCenterIdNo", cacProfitCenterIDNo},
                {"ParentId", TxtIDNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace