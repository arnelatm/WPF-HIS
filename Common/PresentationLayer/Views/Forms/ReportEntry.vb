Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Common.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class ReportEntry
        Implements IReportView

        Private Const DefaultDatabaseName As String = "ISPDATA"

        Public Sub New()
            InitializeComponent()
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IReportView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobIdNo As Int16 Implements IReportView.PrintJobIdNo
            Get
                Return cboPrintJobIdNo.GetValue(Of Int16)()
            End Get
            Set
                cboPrintJobIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ReportName As String Implements IReportView.ReportName
            Get
                Return txtReportName.Text
            End Get
            Set
                txtReportName.Text = Value
            End Set
        End Property

        Public Property ReportCode As String Implements IReportView.ReportCode
            Get
                Return If(txtReportCode.Text, "").Trim()
            End Get
            Set
                txtReportCode.Text = If(Value, "").Trim()
            End Set
        End Property

        Public Property QueryForm As String Implements IReportView.QueryForm
            Get
                Return NormalizeQueryForm(cboQueryForm.Text)
            End Get
            Set
                Dim normalizedValue As String = NormalizeQueryForm(Value)
                AddComboValueIfMissing(cboQueryForm, normalizedValue)
                cboQueryForm.Text = normalizedValue
            End Set
        End Property

        Public Property QueryFormParameters As String Implements IReportView.QueryFormParameters
            Get
                Return If(txtQueryFormParameters.Text, "").Trim()
            End Get
            Set
                txtQueryFormParameters.Text = If(Value, "").Trim()
            End Set
        End Property

        Public Property QueryParameters As String Implements IReportView.QueryParameters
            Get
                Return If(txtQueryParameters.Text, "").Trim()
            End Get
            Set
                txtQueryParameters.Text = If(Value, "").Trim()
            End Set
        End Property

        Public Property PromptParameterNames As String Implements IReportView.PromptParameterNames
            Get
                Return NormalizePromptParameterNames(txtPromptParameterNames.Text)
            End Get
            Set
                txtPromptParameterNames.Text = NormalizePromptParameterNames(Value)
            End Set
        End Property

        Public Property RepeatPromptAfterClose As Boolean Implements IReportView.RepeatPromptAfterClose
            Get
                Return chkRepeatPromptAfterClose.Checked
            End Get
            Set
                chkRepeatPromptAfterClose.Checked = Value
            End Set
        End Property

        Public Property ReportFileName As String Implements IReportView.ReportFileName
            Get
                Return NormalizeReportFileName(txtReportFileName.Text)
            End Get
            Set
                txtReportFileName.Text = NormalizeReportFileName(Value)
            End Set
        End Property

        Public Property ReportGroupIdNo As Int16 Implements IReportView.ReportGroupIdNo
            Get
                Return cboReportGroupIdNo.GetValue(Of Int16)()
            End Get
            Set
                cboReportGroupIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ReportNameAra As String Implements IReportView.ReportNameAra
            Get
                Return txtReportNameAra.Text
            End Get
            Set
                txtReportNameAra.Text = Value
            End Set
        End Property

        Public Property ReportOrder As Int32 Implements IReportView.ReportOrder
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtReportOrder.Text)
            End Get
            Set
                txtReportOrder.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ReportTitle As String Implements IReportView.ReportTitle
            Get
                Return txtReportTitle.Text
            End Get
            Set
                txtReportTitle.Text = Value
            End Set
        End Property

        Public Property ReportTitleAra As String Implements IReportView.ReportTitleAra
            Get
                Return txtReportTitleAra.Text
            End Get
            Set
                txtReportTitleAra.Text = Value
            End Set
        End Property

        Public Property Active As Boolean Implements IReportView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property BranchIdNo As Int16 Implements IReportView.BranchIdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(txtBranchIdNo.Text)
            End Get
            Set
                txtBranchIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime Implements IReportView.DateCreated
            Get
                Dim parsedValue As DateTime
                If DateTime.TryParse(txtDateCreated.Text, parsedValue) Then
                    Return parsedValue
                End If
                Return DateTime.MinValue
            End Get
            Set
                txtDateCreated.Text = If(Value = DateTime.MinValue, "", Convert.ToString(Value))
            End Set
        End Property

        Public Property DatabaseName As String Implements IReportView.DatabaseName
            Get
                Return NormalizeDatabaseName(cboDatabaseName.Text)
            End Get
            Set
                Dim normalizedValue As String = NormalizeDatabaseName(Value)
                AddComboValueIfMissing(cboDatabaseName, normalizedValue)
                cboDatabaseName.Text = normalizedValue
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Active", chkActive},
                {"BranchIdNo", txtBranchIdNo},
                {"DatabaseName", cboDatabaseName},
                {"DateCreated", txtDateCreated},
                {"ReportGroupIdNo", cboReportGroupIdNo},
                {"IdNo", txtIdNo},
                {"PrintJobIdNo", cboPrintJobIdNo},
                {"QueryForm", cboQueryForm},
                {"QueryFormParameters", txtQueryFormParameters},
                {"QueryParameters", txtQueryParameters},
                {"PromptParameterNames", txtPromptParameterNames},
                {"RepeatPromptAfterClose", chkRepeatPromptAfterClose},
                {"ReportCode", txtReportCode},
                {"ReportFileName", txtReportFileName},
                {"ReportName", txtReportName},
                {"ReportNameAra", txtReportNameAra},
                {"ReportOrder", txtReportOrder},
                {"ReportTitle", txtReportTitle},
                {"ReportTitleAra", txtReportTitleAra}
                }
        End Sub

        Private Shared Function NormalizeDatabaseName(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then
                Return DefaultDatabaseName
            End If
            Return value.Trim().ToUpperInvariant()
        End Function

        Private Shared Function NormalizeQueryForm(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then
                Return ""
            End If

            Dim supportedQueryForms As String() = {
                "ContactDateRangeForm",
                "DateRangeForm",
                "DateTimeRangeForm"
            }
            Dim trimmedValue As String = value.Trim()
            Dim supportedValue As String = supportedQueryForms.FirstOrDefault(
                Function(item) String.Equals(item, trimmedValue, StringComparison.OrdinalIgnoreCase))
            Return If(supportedValue, trimmedValue)
        End Function

        Private Shared Function NormalizeReportFileName(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then
                Return ""
            End If

            Dim normalizedValue As String = value.Trim()
            If normalizedValue.EndsWith(".rpt", StringComparison.OrdinalIgnoreCase) Then
                normalizedValue = normalizedValue.Substring(0, normalizedValue.Length - 4)
            End If
            Return normalizedValue
        End Function

        Private Shared Function NormalizePromptParameterNames(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then
                Return ""
            End If

            Return String.Join(",",
                               value.Split(New Char() {","c, ";"c, ControlChars.Cr, ControlChars.Lf},
                                           StringSplitOptions.RemoveEmptyEntries).
                                     Select(Function(item) item.Trim()).
                                     Where(Function(item) item <> "").
                                     Distinct(StringComparer.OrdinalIgnoreCase))
        End Function

        Private Shared Sub AddComboValueIfMissing(comboBox As CComboBox, value As String)
            If value = "" OrElse comboBox.Items.Cast(Of Object)().Any(
                Function(item) String.Equals(Convert.ToString(item), value, StringComparison.OrdinalIgnoreCase)) Then
                Return
            End If

            ' Preserve legacy values so an invalid definition remains visible and
            ' can be corrected instead of being silently replaced by a blank item.
            comboBox.Items.Add(value)
        End Sub

    End Class

End Namespace
