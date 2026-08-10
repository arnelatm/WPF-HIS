Imports AATM.Libraries.GlobalFuncNSub

Imports CrystalDecisions.ReportAppServer.DataDefModel

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportForm

        Public Sub New(ByVal fileName As String, ByVal ParamArray args() As Object)
            InitializeReport(fileName, Nothing, Nothing, args)
        End Sub

        Private Sub New(ByVal fileName As String,
                        ByVal sortTableName As String,
                        ByVal sortFieldName As String,
                        ByVal args() As Object)
            InitializeReport(fileName, sortTableName, sortFieldName, args)
        End Sub

        Public Shared Function CreateSorted(ByVal fileName As String,
                                            ByVal sortTableName As String,
                                            ByVal sortFieldName As String,
                                            ByVal ParamArray args() As Object) As ReportForm
            Return New ReportForm(fileName, sortTableName, sortFieldName, args)
        End Function

        Private Sub InitializeReport(fileName As String,
                                     sortTableName As String,
                                     sortFieldName As String,
                                     args() As Object)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetReportProperties()
            If Not String.IsNullOrWhiteSpace(sortFieldName) Then
                ApplyAscendingSort(sortTableName, sortFieldName)
            End If
            For i = 0 To args.Length - 1 Step 2
                Dim value = args(i)
                ReportDocument.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
            Next
            ReportDocument.DataSourceConnections.Clear()
            ProcessReport()
        End Sub

        Private Sub ApplyAscendingSort(tableName As String, fieldName As String)
            ReportDocument.VerifyDatabase()

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
