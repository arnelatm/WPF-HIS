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
            FirstControl = cboTableName
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
                Return cboTableName.Text
            End Get
            Set
                cboTableName.Text = Value
            End Set
        End Property

        Public Property DataType As Byte Implements IDefaultFieldValueView.DataType
            Get
                Return cboDataType.GetValue()
            End Get
            Set
                cboDataType.SetValue(Value)
            End Set
        End Property

        Public Property Length As Byte Implements IDefaultFieldValueView.Length
            Get
                Return txtLength.Text.ToInt16Number()
            End Get
            Set
                txtLength.Text = Value
            End Set
        End Property

        Public Function ValidateValue(Of TM)(ByRef originalValue As Object, ByVal targetValue As Object)
            If targetValue.Equals(DBNull.Value) Or targetValue Is Nothing Then
                Return Nothing
            End If
            Dim x As Type = GetType(TM)
            Dim u As Type = Nullable.GetUnderlyingType(x)

            If x IsNot Nothing Then
                If targetValue Is Nothing Then
                    Return Nothing
                Else
                    Dim num As Decimal
                    Dim isNumeric As Boolean = Decimal.TryParse(targetValue, num)
                    If Not isNumeric Then
                        MessageBox.Show($"The entered value for " & originalValue.Name & $" must be a number! Reverting to previous Value.")
                        Return originalValue.Text
                    End If
                    Select Case x.Name
                        Case "Byte"
                            If num < 0 OrElse num > 255 Then
                                MessageBox.Show($"The entered value for " & originalValue.Name & $" must be between 0-255. Reverting to previous Value.")
                                Return originalValue.Text
                            End If
                            Return num.ToString()
                            'Return CType(Convert.ChangeType(targetValue, u), TM).ToString()
                        Case Else
                            Return 0
                    End Select
                End If
            Else
                Return CType(Convert.ChangeType(targetValue, x), TM)
            End If
        End Function

        Public Property DecimalPart As Byte Implements IDefaultFieldValueView.DecimalPart
            Get
                Return NumParser(Of Byte)(txtDecimalPart.Text)
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

        Protected Overrides Sub CreateDataSources()
            cboDataType.DataSource = PresenterObj.MakeEnumComboList(Of DataTypeSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"FieldName", txtFieldName},
                {"TableName", cboTableName},
                {"DataType", cboDataType},
                {"IdNo", TxtIdNo},
                {"Length", txtLength},
                {"DecimalPart", lblDecimalPart},
                {"LinkedTable", txtLinkedTable},
                {"LinkedField", txtLinkedField}
                }
        End Sub

    End Class

End Namespace