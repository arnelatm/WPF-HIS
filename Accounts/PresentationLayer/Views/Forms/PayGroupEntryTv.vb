Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PayGroupEntryTv
        Implements IPayGroupView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPayGroupCode
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPayGroupView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IPayGroupView.ParentIdNo
            Get
                Return cboParentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayGroupCode As String Implements IPayGroupView.PayGroupCode
            Get
                Return txtPayGroupCode.Text
            End Get
            Set
                txtPayGroupCode.Text = Value
            End Set
        End Property

        Public Property PayGroupName As String Implements IPayGroupView.PayGroupName
            Get
                Return txtPayGroupName.Text
            End Get
            Set
                txtPayGroupName.Text = Value
            End Set
        End Property

        Public Property PayGroupNameAra As String Implements IPayGroupView.PayGroupNameAra
            Get
                Return txtPayGroupNameAra.Text
            End Get
            Set
                txtPayGroupNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IPayGroupView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property LevelNumber As Int16 Implements IPayGroupView.LevelNumber
            Get
                Return NumParser(Of Int16)(txtLevelNumber.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("PayGroup", cboParentIdNo)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"PayGroupCode", txtPayGroupCode},
                {"PayGroupName", txtPayGroupName},
                {"PayGroupNameAra", txtPayGroupNameAra},
                {"ParentIdNo", cboParentIdNo},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace