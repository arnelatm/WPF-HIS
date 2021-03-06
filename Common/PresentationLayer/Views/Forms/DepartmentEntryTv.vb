Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DepartmentEntryTv
        Implements IDepartmentView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "Department_View"
            TvMainFieldName = "DepartmentName"
            TvSecondaryFieldName = "DepartmentCode"
            SortOrderKey = "DepartmentName"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtDepartmentCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DepartmentPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetLookup("Department")
            cacRevCostCenterIdNo.DataSource = PresenterObj.GetLookup("RevCostCenter")
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDepartmentView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IDepartmentView.ParentIdNo
            Get
                Return cacParentIdNo.GetNullableValue(Of Int16)
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

        Public Property RevCostCenterIdNo As Int16 Implements IDepartmentView.RevCostCenterIdNo
            Get
                Return cacRevCostCenterIdNo.GetValue()
            End Get
            Set
                cacRevCostCenterIdNo.SetValue(Value)
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

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DepartmentCode", txtDepartmentCode},
                {"DepartmentName", txtDepartmentName},
                {"DepartmentNameAra", txtDepartmentNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"RevCostCenterIdNo", cacRevCostCenterIdNo},
                {"ParentId", cacParentIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace