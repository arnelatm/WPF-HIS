Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DepartmentEntryTv
        Implements IDepartmentView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            ParentFieldName = "ParentIdNo"
            FirstControl = txtDepartmentCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDepartmentView.IdNo
            Get
                Return txtIdNo.GetValue(Of Int16) 
            End Get
            Set
                TxtIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IDepartmentView.ParentIdNo
            Get
                Return cacParentIdNo.GetValue(Of Int16)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DepartmentCode As String Implements IDepartmentView.DepartmentCode
            Get
                Return txtDepartmentCode.GetValue(Of String)
            End Get
            Set
                txtDepartmentCode.SetValue(Value)
            End Set
        End Property

        Public Property DepartmentName As String Implements IDepartmentView.DepartmentName
            Get
                Return txtDepartmentName.GetValue(Of String)
            End Get
            Set
                txtDepartmentName.SetValue(Value)
            End Set
        End Property

        Public Property DepartmentNameAra As String Implements IDepartmentView.DepartmentNameAra
            Get
                Return txtDepartmentNameAra.GetValue(Of String)
            End Get
            Set
                txtDepartmentNameAra.SetValue(Value)
            End Set
        End Property

        Public Property RevCostCenterIdNo As Int16 Implements IDepartmentView.RevCostCenterIdNo
            Get
                Return cacRevCostCenterIdNo.GetValue(Of Int16)
            End Get
            Set
                cacRevCostCenterIdNo.SetValue(value)
            End Set
        End Property

        Public Property Notes As String Implements IDepartmentView.Notes
            Get
                Return txtNotes.GetValue(Of String)
            End Get
            Set
                txtNotes.SetValue(Value)
            End Set
        End Property

        Public Property SortKey As String Implements IDepartmentView.SortKey
            Get
                Return txtSortKey.GetValue(Of String)
            End Get
            Set
                txtSortKey.SetValue(Value)
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