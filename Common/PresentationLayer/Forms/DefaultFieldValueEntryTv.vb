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
                Return txtDecimalPart.Text
            End Get
            Set
                txtDecimalPart.Text = Value
            End Set
        End Property

        Public Property LinkedTable As String Implements IDefaultFieldValueView.LinkedTable
            Get
                Return txtLinkedTable.Text
            End Get
            Set
                txtLinkedTable.Text = Value
            End Set
        End Property

        Public Property LinkedField As String Implements IDefaultFieldValueView.LinkedField
            Get
                Return txtLinkedField.Text
            End Get
            Set
                txtLinkedField.Text = Value
            End Set
        End Property

        Public Property DefaultValue As String Implements IDefaultFieldValueView.DefaultValue
            Get
                Return txtDefaultValue.Text
            End Get
            Set
                txtDefaultValue.Text = Value
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