Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PensionSchemePresenter(Of TM As New)
        Inherits CommonPresenter(Of IPensionSchemeView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _pensionRateService As New AccountsService("PensionRate")

        Public Sub New(view As IPensionSchemeView)
            MyBase.New(view)
            Service = New AccountsService("PensionScheme")
            TableName = "PensionScheme"
            TreeViewMainField = "PensionSchemeName"
            'TreeViewSecondaryField = "PensionSchemeCode"
            SortOrderKey = "PensionSchemeName"

            DtInsertTable.Columns.Add("EmployeeShare", GetType(Decimal))
            DtInsertTable.Columns.Add("EmployerShare", GetType(Decimal))
            DtInsertTable.Columns.Add("HighRange", GetType(Decimal))
            DtInsertTable.Columns.Add("LowRange", GetType(Decimal))
            DtInsertTable.Columns.Add("MaxAmount", GetType(Decimal))
            DtInsertTable.Columns.Add("PensionSchemeIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("EmployeeShare", GetType(Decimal))
            DtUpdateTable.Columns.Add("EmployerShare", GetType(Decimal))
            DtUpdateTable.Columns.Add("HighRange", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("LowRange", GetType(Decimal))
            DtUpdateTable.Columns.Add("MaxAmount", GetType(Decimal))
            DtUpdateTable.Columns.Add("PensionSchemeIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
        End Sub

        
        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"PensionProvider", "PensionProviderIdNo", Nothing, Nothing},
                                    New String() {"Account", "AccountIdNo", Nothing, "DetailAccount=1"}})
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.PensionRates, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PensionRateFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("EmployeeShare") = itemDataView.EmployeeShare
            workRow("EmployerShare") = itemDataView.EmployerShare
            workRow("LowRange") = itemDataView.LowRange
            workRow("HighRange") = itemDataView.HighRange
            workRow("MaxAmount") = itemDataView.MaxAmount
            workRow("PensionSchemeIdNo") = View.IdNo
        End Sub

        Public Function PensionRateFilter(ByVal obj As Object) As Boolean
            If (obj.LowRange = 0 And obj.HighRange = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_pensionRateService, DtUpdateTable, DtInsertTable, passedValue, "PensionSchemeIdNo")
        End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        retValue = True
        '        If Not UsePayGroups() Then
        '            If View.AccountIdNo <= 0 Then
        '                Messaging.Show(True, "MsgPostingAccountMustNotBeBlank")
        '                retValue = False
        '            End If
        '        End If
        '    End If
        '    Return retValue
        'End Function

        'Public Function GetPensionRates(pensionSchemeIdNo As Int32) As List(Of PensionRateModel)
        '    Return _pensionRateModel.GetRecordsWithGroupIdNo(Of PensionRateModel)(pensionSchemeIdNo, "Sequence")
        'End Function

        'Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
        '    If View.PensionRates IsNot Nothing Then
        '        View.PensionRates.Clear()
        '    Else
        '        View.PensionRates = New List(Of PensionRateView)
        '    End If
        '    Dim item As New PensionRateView With {
        '            .PensionSchemeIdNo = View.IdNo,
        '            .Sequence = 1,
        '            .EmployeeShare = 0,
        '            .EmployerShare = 0,
        '            .LowRange = 0,
        '            .HighRange = 0,
        '            .MaxAmount = 0
        '            }
        '    View.PensionRates.Add(item)
        'End Sub

    End Class

End Namespace