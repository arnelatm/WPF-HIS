Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class AppSettingEntry
        Implements IAppSettingView

        Private _lockGroup As Boolean = False
        Private _groupIdNo As Int16
        Private _shownInitialized As Boolean
        Public Event AppSettingGroupValueChanged(sender As Object) Implements IAppSettingView.AppSettingGroupValueChanged
        Public Property Selector1Data As Object Implements IAppSettingView.Selector1Data
        Public Property Selector2Data As Object Implements IAppSettingView.Selector2Data

        Public WriteOnly Property Selector1Text As String Implements IAppSettingView.Selector1Text
            Set(value As String)
                lblSelector1IdNo.Text = value
            End Set
        End Property

        Public WriteOnly Property Selector2Text As String Implements IAppSettingView.Selector2Text
            Set(value As String)
                lblSelector2IdNo.Text = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboAppSettingGroupSelector
            LockGroup = False
            btnLockGroup.Enabled = True
        End Sub

        Public Sub New(appSettingGroupIdNo As Int16)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboAppSettingGroupSelector
            LockGroup = False
            btnLockGroup.Enabled = True
            DataFilter = "AppSettingGroupIdNo = " + appSettingGroupIdNo.ToString()
        End Sub

#Region "Field Items"

        Public Property IdNo As Int32 Implements IAppSettingView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt32(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Selector1IdNo As Integer Implements IAppSettingView.Selector1IdNo
            Get
                Return cboSelector1IdNo.GetValue(Of Int32)
            End Get
            Set
                cboSelector1IdNo.SetValue(Value)
            End Set
        End Property

        Public Property Selector2IdNo As Integer Implements IAppSettingView.Selector2IdNo
            Get
                Return cboSelector2IdNo.GetValue(Of Int32)
            End Get
            Set
                cboSelector2IdNo.SetValue(Value)
            End Set
        End Property

        Public Property LockGroup As Boolean Implements IAppSettingView.LockGroup
            Get
                Return _lockGroup
            End Get
            Set(value As Boolean)
                _lockGroup = value
                If value Then
                    btnLockGroup.BackgroundImage = My.Resources.Unlock
                    cboAppSettingGroupSelector.EditingMode = False
                Else
                    btnLockGroup.BackgroundImage = My.Resources.Lock
                    cboAppSettingGroupSelector.EditingMode = True
                End If
            End Set
        End Property

        Public Property SavedGroupIdNo As Short Implements IAppSettingView.SavedGroupIdNo
        Public Event LockGroupClicked() Implements IAppSettingView.LockGroupClicked
        Public Event FilterRecords() Implements IAppSettingView.FilterRecords

        Public Property AppSettingGroupSelector As Short Implements IAppSettingView.AppSettingGroupSelector
            Get
                Return cboAppSettingGroupSelector.GetValue(Of Int16)
            End Get
            Set
                cboAppSettingGroupSelector.SetValue(Value)
            End Set
        End Property

        Public Property AppSettingGroupIdNo As Short Implements IAppSettingView.AppSettingGroupIdNo
            Get
                Return txtAppSettingGroupIdNo.GetValue(Of Short)
            End Get
            Set(value As Short)
                txtAppSettingGroupIdNo.Text = value
            End Set
        End Property

        Public Property SettingValue As String Implements IAppSettingView.SettingValue

        Public Property SelectorCount As Short Implements IAppSettingView.SelectorCount




#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AppSettingGroupIdNo", txtAppSettingGroupIdNo},
                {"IdNo", TxtIdNo},
                {"AppSettingGroupSelector", cboAppSettingGroupSelector},
                {"Selector1IdNo", cboSelector1IdNo},
                {"Selector2IdNo", cboSelector2IdNo}
                }
        End Sub


        Private Sub btnLockGroup_Click(sender As Object, e As EventArgs) Handles btnLockGroup.Click
            LockGroup = Not LockGroup
            If cboAppSettingGroupSelector.SelectedValue <> 0 Then
                If Not LockGroup Then
                    cboAppSettingGroupSelector.EditingMode = True
                Else
                    SavedGroupIdNo = AppSettingGroupIdNo
                    cboAppSettingGroupSelector.EditingMode = False
                End If
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
            cboAppSettingGroupSelector.Refresh()
        End Sub

        Private Sub OnFormLoad() Handles MyBase.Load
            DataFilter = "AppSettingGroupIdNo = 0"
            RaiseEvent FilterRecords()
            cboAppSettingGroupSelector.SelectedValue = 0
            cboAppSettingGroupSelector.DisplayOnly = False
            cboAppSettingGroupSelector.EditingMode = True
            RaiseEvent AppSettingGroupValueChanged(cboAppSettingGroupSelector)
        End Sub

        Protected Overrides Sub AfterEdit()
            EnableSelector1Selection()
        End Sub

        Protected Sub AppSettingAfterUpdateView() Handles MyBase.AfterUpdateView
            EnableSelector1Selection()
        End Sub

        Private Sub EnableSelector1Selection()
            cboAppSettingGroupSelector.EditingMode = True
        End Sub

        Protected Overrides Sub BeforeAdd()
            _groupIdNo = AppSettingGroupIdNo
            MyBase.BeforeAdd()
        End Sub

        Protected Overrides Sub AfterAdd()
            MyBase.AfterAdd()
            AppSettingGroupIdNo = _groupIdNo
        End Sub

        Private Sub AppSettingEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            If _shownInitialized Then Return
            _shownInitialized = True
        End Sub

        Private Sub cboSelector1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAppSettingGroupSelector.SelectionChangeCommitted
            RaiseEvent AppSettingGroupValueChanged(sender)
            Refresh()
        End Sub

        Public Overloads Sub Inputs(onOff As Boolean)
            ' need to override because default method is to set 'EditingMode' to desired value
            ' but in this case cboAppSettingCodeSelector is not databound but just a selector
            ' and we always need to set its 'EditingMode' based on 'LockGroup' Value
            MyBase.Inputs(onOff)
            If LockGroup Then
                cboAppSettingGroupSelector.EditingMode = False
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
        End Sub

        Private Sub OnAfterChangeRecord() Handles MyBase.AfterChangeRecord
            If LockGroup Then
                cboAppSettingGroupSelector.EditingMode = False
            Else
                cboAppSettingGroupSelector.EditingMode = True
            End If
        End Sub

        Private Sub cboAppSettingGroupSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAppSettingGroupSelector.SelectedIndexChanged
            txtAppSettingGroupIdNo.Text = cboAppSettingGroupSelector.SelectedValue
        End Sub
    End Class

End Namespace