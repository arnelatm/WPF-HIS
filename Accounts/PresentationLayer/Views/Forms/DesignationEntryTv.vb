Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DesignationEntryTv
        Implements IDesignationView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Designation"
            TvMainFieldName = "DesignationName"
            TvSecondaryFieldName = "DesignationCode"
            SortOrderKey = "DesignationName"
            FirstControl = txtDesignationCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DesignationPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDesignationView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DesignationCode As String Implements IDesignationView.DesignationCode
            Get
                Return txtDesignationCode.Text
            End Get
            Set
                txtDesignationCode.Text = Value
            End Set
        End Property

        Public Property DesignationName As String Implements IDesignationView.DesignationName
            Get
                Return txtDesignationName.Text
            End Get
            Set
                txtDesignationName.Text = Value
            End Set
        End Property

        Public Property DesignationNameAra As String Implements IDesignationView.DesignationNameAra
            Get
                Return txtDesignationNameAra.Text
            End Get
            Set
                txtDesignationNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IDesignationView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

    End Class

End Namespace