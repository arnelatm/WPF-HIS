Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class RecurringPayElementPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IRecurringPayElementView, TM)

        Public Sub New(itemView As IRecurringPayElementView)
            MyBase.New(itemView)
            Service = New AccountsService("RecurringPayElement")
            TableName = "RecurringPayElement"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of RecurTypeSelection)("RecurType")
            CreateDataSource("Employee", "EmployeeIdNo")
            CreateDataSource("PayElement", "PayElementIdNo")
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "PayrollPayElement", "RecurringPayElementIdNo") Then
                Return True
            End If
            Return False
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Select Case View.RecurType
                    Case EnumToCode(RecurTypeSelection.UpToEndDate)
                        If View.EndDate Is Nothing Then
                            Messaging.ShowPmMessage(True, "MsgRequiredField", {"fieldName", Messaging.TranslateCaption("End Date")})
                        ElseIf View.EndDate < View.StartDate Then
                            Messaging.ShowPmMessage(True, "MsgMustBeGreaterThan", {"fieldName1", Messaging.TranslateCaption("End Date"), "fieldName2", Messaging.TranslateCaption("Start Date")})
                        Else
                            retValue = True
                        End If
                    Case EnumToCode(RecurTypeSelection.UpToLimitAmount)
                        If View.LimitAmount = 0 Then
                            Messaging.ShowPmMessage(True, "MsgRequiredField", {"fieldName", Messaging.TranslateCaption("Limit Amount")})
                        ElseIf View.LimitAmount < View.PeriodicAmount Then
                            Messaging.ShowPmMessage(True, "MsgMustBeGreaterThan", {"fieldName1", Messaging.TranslateCaption("Limit Amount"), "fieldName2", Messaging.TranslateCaption("Periodic Amount")})
                        Else
                            retValue = True
                        End If
                    Case Else
                        retValue = True
                End Select
            End If
            Return retValue
        End Function

        Protected Function BeforeEditing()


        End Function


    End Class

End Namespace