Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Presenters

    Public Class RecurringPayElementPresenter(Of TM As New)
        Inherits CommonPresenter(Of IRecurringPayElementView, TM)

        Public Sub New(itemView As IRecurringPayElementView)
            MyBase.New(itemView)
            Service = New AccountsService("RecurringPayElement")
            TableName = "RecurringPayElement"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of RecurTypeSelection)("RecurType")
            MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing},
                                    New Object() {"PayElement", "PayElementIdNo", Nothing, Nothing}})
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
                            MessagingService.ShowPmMessage(True, "MsgRequiredField", {"fieldName", MessagingService.TranslateCaption("End Date")})
                        ElseIf View.EndDate < View.StartDate Then
                            MessagingService.ShowPmMessage(True, "MsgMustBeGreaterThan", {"fieldName1", MessagingService.TranslateCaption("End Date"), "fieldName2", MessagingService.TranslateCaption("Start Date")})
                        Else
                            retValue = True
                        End If
                    Case EnumToCode(RecurTypeSelection.UpToLimitAmount)
                        If View.LimitAmount = 0 Then
                            MessagingService.ShowPmMessage(True, "MsgRequiredField", {"fieldName", MessagingService.TranslateCaption("Limit Amount")})
                        ElseIf View.LimitAmount < View.PeriodicAmount Then
                            MessagingService.ShowPmMessage(True, "MsgMustBeGreaterThan", {"fieldName1", MessagingService.TranslateCaption("Limit Amount"), "fieldName2", MessagingService.TranslateCaption("Periodic Amount")})
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