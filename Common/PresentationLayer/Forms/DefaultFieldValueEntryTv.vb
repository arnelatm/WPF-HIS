Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class DefaultFieldValueEntryTv
        Implements IDefaultFieldValueView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FormTitleCaption = "Default Field Values Maintenance Form"
            MainTableName = "DefaultFieldValue"
            TvMainFieldName = "TableName"
            TvSecondaryFieldName = "FieldName"
            SortOrderKey = "TableName, FieldName"
            FirstControl = txtTableName
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DefaultFieldValuePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IDefaultFieldValueView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property FieldName As String Implements IDefaultFieldValueView.FieldName
            Get
                Return txtFieldName.Text
            End Get
            Set
                txtFieldName.Text = Value
            End Set
        End Property

        Public Property TableName As String Implements IDefaultFieldValueView.TableName
            Get
                Return txtTableName.Text
            End Get
            Set
                txtTableName.Text = Value
            End Set
        End Property

        Public Property DataType As Byte Implements IDefaultFieldValueView.DataType
            Get
                Return txtDataType.Text
            End Get
            Set
                txtDataType.Text = Value
            End Set
        End Property

        Public Property Length As UShort Implements IDefaultFieldValueView.Length
            Get
                Return txtLength.Text
            End Get
            Set
                txtLength.Text = Value
            End Set
        End Property

        Public Property DecimalPart As Byte Implements IDefaultFieldValueView.DecimalPart
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Byte)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LinkedTableName As String Implements IDefaultFieldValueView.LinkedTableName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LinkedFieldName As String Implements IDefaultFieldValueView.LinkedFieldName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property DefaultValue As String Implements IDefaultFieldValueView.DefaultValue
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Private Property IDefaultFieldValueView_Length As UShort Implements IDefaultFieldValueView.Length
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As UShort)
                Throw New NotImplementedException()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"FieldName", txtFieldName},
                {"TableName", txtTableName},
                {"DataType", txtDataType},
                {"IdNo", TxtIdNo},
                {"Length", txtLength}
                }
        End Sub

    End Class

End Namespace