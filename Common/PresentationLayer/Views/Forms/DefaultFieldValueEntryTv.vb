Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class DefaultFieldValueEntryTv
        Implements IDefaultFieldValueView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboSystemViewIdNo
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDefaultFieldValueView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property SystemViewIdNo As Int16 Implements IDefaultFieldValueView.SystemViewIdNo
            Get
                Return cboSystemViewIdNo.GetValue()
            End Get
            Set
                cboSystemViewIdNo.SetValue(Value)
                txtSystemViewName.Text = cboSystemViewIdNo.Text
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

        Public Property SystemViewName As String Implements IDefaultFieldValueView.SystemViewName
            Get
                Return txtSystemViewName.Text
            End Get
            Set
                txtSystemViewName.Text = Value
            End Set
        End Property

        Public Property SystemViewNameAra As String Implements IDefaultFieldValueView.SystemViewNameAra
            Get
                Return txtSystemViewNameAra.Text
            End Get
            Set
                txtSystemViewNameAra.Text = Value
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
                        Dim variables = {"FieldName", originalValue.name}
                        Messaging.ShowPmMessage(True, "MsgOnlyNumbersAllowed", variables)
                        Return originalValue.Text
                    End If
                    Select Case x.Name
                        Case "Byte"
                            If num < 0 OrElse num > 255 Then
                                Dim variables = {"FieldName", originalValue.Name}
                                Messaging.ShowPmMessage(True, "MsgNumeric0to255Only", variables)
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

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"FieldName", txtFieldName},
                {"SystemViewIdNo", cboSystemViewIdNo},
                {"SystemViewName", txtSystemViewName},
                {"SystemViewNameAra", txtSystemViewNameAra},
                {"DataType", cboDataType},
                {"IdNo", TxtIdNo},
                {"Length", txtLength},
                {"DecimalPart", lblDecimalPart},
                {"LinkedTable", txtLinkedTable},
                {"LinkedField", txtLinkedField}
                }
        End Sub

        Private Sub CboSystemViewIdNo_Changed(sender As Object, e As EventArgs) Handles cboSystemViewIdNo.Validated, cboSystemViewIdNo.SelectionChangeCommitted
            txtSystemViewName.Text = cboSystemViewIdNo.Text
            txtSystemViewNameAra.Text = cboSystemViewIdNo.Text
        End Sub


    End Class

End Namespace

'ApJournal
'ArJournal
'CdJournal
'CashReceiptJournal
'CkJournal
'Customer
'Employee
'ErJournal
'GeneralJournal
'Patient
'PayCycle
'PayGroup
'Payroll
'PcJournal
'Category
'SalesJournal
'SecurityGroup
'Supplier
'User