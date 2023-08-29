Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class InvTransTypeEntryTv
        Implements IInvTransTypeView

        Public Sub New()

            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtInvTransTypeCode
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IInvTransTypeView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property InvTransTypeCode As String Implements IInvTransTypeView.InvTransTypeCode
            Get
                Return txtInvTransTypeCode.Text
            End Get
            Set
                txtInvTransTypeCode.Text = Value
            End Set
        End Property

        Public Property InvTransTypeName As String Implements IInvTransTypeView.InvTransTypeName
            Get
                Return txtInvTransTypeName.Text
            End Get
            Set
                txtInvTransTypeName.Text = Value
            End Set
        End Property

        Public Property InvTransTypeNameAra As String Implements IInvTransTypeView.InvTransTypeNameAra
            Get
                Return txtInvTransTypeNameAra.Text
            End Get
            Set
                txtInvTransTypeNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IInvTransTypeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property AccountIdNo As Int16? Implements IInvTransTypeView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Active As Boolean Implements IInvTransTypeView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property InventoryAction As String Implements IInvTransTypeView.InventoryAction
            Get
                Return cboInventoryAction.GetValue()
            End Get
            Set
                cboInventoryAction.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Active", chkActive},
                {"InventoryAction", cboInventoryAction},
                {"InvTransTypeCode", txtInvTransTypeCode},
                {"InvTransTypeName", txtInvTransTypeName},
                {"InvTransTypeNameAra", txtInvTransTypeNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace