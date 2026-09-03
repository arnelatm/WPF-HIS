Imports AATM.Libraries.GlobalFuncNSub

Imports CrystalDecisions.ReportAppServer.DataDefModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportForm

        Public Sub New(ByVal fileName As String, ByVal ParamArray args() As Object)
            InitializeReport(fileName, Nothing, Nothing, Nothing, args)
        End Sub

        Private Sub New(ByVal fileName As String,
                        ByVal sortTableName As String,
                        ByVal sortFieldName As String,
                        ByVal args() As Object)
            InitializeReport(fileName, sortTableName, sortFieldName, Nothing, args)
        End Sub

        Private Sub New(ByVal fileName As String,
                        ByVal sortTableName As String,
                        ByVal sortFieldName As String,
                        ByVal reportData As System.Data.DataSet,
                        ByVal args() As Object)
            InitializeReport(fileName, sortTableName, sortFieldName, reportData, args)
        End Sub

        Public Shared Function CreateSorted(ByVal fileName As String,
                                            ByVal sortTableName As String,
                                            ByVal sortFieldName As String,
                                            ByVal ParamArray args() As Object) As ReportForm
            Return New ReportForm(fileName, sortTableName, sortFieldName, args)
        End Function

        Public Shared Function CreateSorted(ByVal fileName As String,
                                            ByVal sortTableName As String,
                                            ByVal sortFieldName As String,
                                            ByVal reportData As System.Data.DataSet,
                                            ByVal ParamArray args() As Object) As ReportForm
            Return New ReportForm(fileName, sortTableName, sortFieldName, reportData, args)
        End Function

        Private Sub InitializeReport(fileName As String,
                                     sortTableName As String,
                                     sortFieldName As String,
                                     reportData As System.Data.DataSet,
                                     args() As Object)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetReportProperties()
            If reportData IsNot Nothing Then
                ReportDocument.SetDataSource(reportData)
                UsesSuppliedReportData = True
            End If
            If Not String.IsNullOrWhiteSpace(sortFieldName) Then
                ' A report backed by an in-memory DataSet has already received
                ' its complete schema and rows.  VerifyDatabase() can remap
                ' those tables back to the report's saved database connection,
                ' which silently drops child rows that are present only in the
                ' supplied DataSet (for example the LAB rows in a medical
                ' fitness report).
                ApplyAscendingSort(sortTableName, sortFieldName, reportData Is Nothing)
            End If
            For i = 0 To args.Length - 1 Step 2
                Dim value = args(i)
                SetReportParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
            Next
            If reportData Is Nothing Then
                ReportDocument.DataSourceConnections.Clear()
            End If
            ProcessReport()
        End Sub

        Private Sub SetReportParameterValue(name As String, value As Object)
            Dim resolvedName = ResolveParameterName(name)
            If resolvedName Is Nothing Then
                ' SuppressLogo was added after older copies of this report
                ' were deployed. Keep those reports usable until they are
                ' updated in Crystal Reports.
                If String.Equals(name, "SuppressLogo", StringComparison.OrdinalIgnoreCase) Then
                    Return
                End If

                Throw New ArgumentException(
                    "Crystal report parameter '" & name & "' was not found. Available parameters: " &
                    GetAvailableParameterNames())
            End If

            ReportDocument.SetParameterValue(resolvedName, value)
        End Sub

        Private Function ResolveParameterName(name As String) As String
            If ReportDocument Is Nothing OrElse ReportDocument.DataDefinition Is Nothing Then
                Return name
            End If

            For Each parameterField As ParameterFieldDefinition In ReportDocument.DataDefinition.ParameterFields
                If String.Equals(parameterField.ParameterFieldName, name, StringComparison.OrdinalIgnoreCase) Then
                    Return parameterField.ParameterFieldName
                End If
            Next

            ' One deployed report was configured with this spelling. Accept
            ' it while the report can be corrected to the proper spelling.
            If String.Equals(name, "SuppressLogo", StringComparison.OrdinalIgnoreCase) Then
                For Each parameterField As ParameterFieldDefinition In ReportDocument.DataDefinition.ParameterFields
                    If String.Equals(parameterField.ParameterFieldName, "SupressLogo", StringComparison.OrdinalIgnoreCase) Then
                        Return parameterField.ParameterFieldName
                    End If
                Next
            End If

            Return Nothing
        End Function

        Private Function GetAvailableParameterNames() As String
            If ReportDocument Is Nothing OrElse ReportDocument.DataDefinition Is Nothing Then
                Return String.Empty
            End If

            Dim names As New System.Collections.Generic.List(Of String)
            For Each parameterField As ParameterFieldDefinition In ReportDocument.DataDefinition.ParameterFields
                names.Add(parameterField.ParameterFieldName)
            Next
            Return String.Join(", ", names)
        End Function

        Private Sub ApplyAscendingSort(tableName As String,
                                       fieldName As String,
                                       verifyDatabase As Boolean)
            If verifyDatabase Then
                ReportDocument.VerifyDatabase()
            End If

            Dim dataDefController = ReportDocument.ReportClientDocument.DataDefController
            Dim sortField = FindSortField(dataDefController, tableName, fieldName)

            ' Older copies of the .rpt know this value by its original database
            ' field name. Sequence is an alias of DisplayOrder, so both sort the
            ' report identically.
            If sortField Is Nothing AndAlso
               String.Equals(fieldName, "Sequence", StringComparison.OrdinalIgnoreCase) Then
                sortField = FindSortField(dataDefController, tableName, "DisplayOrder")
            End If

            If sortField Is Nothing Then
                Throw New InvalidOperationException(
                    "The Crystal Report field '" & tableName & "." & fieldName & "' was not found.")
            End If

            Dim sortController = dataDefController.SortController
            Dim existingSort = sortController.FindSort(sortField)
            If existingSort Is Nothing Then
                Dim newSort As New Sort With {
                    .SortField = sortField,
                    .Direction = CrSortDirectionEnum.crSortDirectionAscendingOrder}
                sortController.Add(0, newSort)
            Else
                sortController.ModifySortDirection(
                    existingSort,
                    CrSortDirectionEnum.crSortDirectionAscendingOrder)

                Dim existingIndex = dataDefController.DataDefinition.Sorts.FindIndexOf(existingSort)
                If existingIndex > 0 Then
                    sortController.Move(existingSort, 0)
                End If
            End If
        End Sub

        Private Shared Function FindSortField(dataDefController As Object,
                                              tableName As String,
                                              fieldName As String) As ISCRField
            Dim reportField As ISCRField = dataDefController.FindFieldByFormulaForm(
                "{" & tableName & "." & fieldName & "}")
            If reportField IsNot Nothing Then
                Return reportField
            End If

            For Each reportTable In dataDefController.Database.Tables
                If String.Equals(reportTable.Name, tableName, StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(reportTable.Alias, tableName, StringComparison.OrdinalIgnoreCase) Then
                    For Each dataField In reportTable.DataFields
                        If String.Equals(dataField.Name, fieldName, StringComparison.OrdinalIgnoreCase) Then
                            Return dataField
                        End If
                    Next
                End If
            Next

            ' The saved report may use a custom alias for the view. Search all
            ' report tables by field name as a final compatibility fallback.
            For Each reportTable In dataDefController.Database.Tables
                For Each dataField In reportTable.DataFields
                    If String.Equals(dataField.Name, fieldName, StringComparison.OrdinalIgnoreCase) Then
                        Return dataField
                    End If
                Next
            Next

            Return Nothing
        End Function

        Public Property MainTableName As String

    End Class

End Namespace
