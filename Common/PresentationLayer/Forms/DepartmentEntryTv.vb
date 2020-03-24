Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms

    Public Class DepartmentEntryTv
        Implements IDepartmentView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Department"
            IdFieldName = "IdNo"
            TvMainFieldName = "DepartmentName"
            TvSecondaryFieldName = "DepartmentCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtDepartmentCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DepartmentPresenter(Me)

            AddHandler MyBase.TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            CreateDataSources()
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("DepartmentTypeSelection", GetType(DepartmentTypeSelection))

        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("DepartmentTypeSelection", GetType(DepartmentTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            UpdateParentIdData()
            cacProfitCenterIDNo.DataSource = PresenterObj.GetProfitCenterList()
            cacCostCenterIDNo.DataSource = PresenterObj.GetCostCenterList()
        End Sub

        Private Shadows Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

        Private Sub UpdateParentIdData()
            cacParentIdNo.DataSource = PresenterObj.GetDepartmentList()
        End Sub

        Public Property IDNo As Integer Implements IDepartmentView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
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

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If EditMode And cacParentIdNo.Text = TxtIDNo.Text Then
                Messaging.DisplayLocal(Languages.Messages.SorryAMemberCannotBeAParentToItself)
                CancelSave = True
                Exit Sub
            End If
            'If EditMode then
            '    Dim cOldParentId As String = PresenterObj.GetOriginalValue(tcbParentIdNo)
            '    If cOldParentId <> tcbParentIdNo.Text Then
            '        ' ParentID is changed by the user so
            '        ' check for records which have this record as parent.
            '        ' check for matching children entries
            '        If CommonDaoOld.CountRecordWithKey(TxtIDNo.Text, MainTableName, "ParentIdNo") > 0 Then
            '            _MBParentWithChildrenChangedDisallowed.Show(Me)
            '            CancelSave = True
            '            Exit Sub
            '        End If
            '    End If
            'End If
        End Sub

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

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            UpdateParentIdData()
            cacParentIdNo.Refresh()
        End Sub

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtDepartmentCode, "Department Code")
            MyErrorProvider.Controls.AddMandatory(txtDepartmentName, "Department Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

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