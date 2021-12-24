Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class AccountsService
        Inherits CommonService
        Implements IServiceAccounts

        Protected Shared ReadOnly DaoFactoryAccounts As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)

        Protected Service As Object

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Protected Overrides Sub CreateBusinessObject(objectName As String, Optional bizParam As Object = Nothing)
            Dim bizObjectName As String
            bizObjectName = $"AATM.Accounts.BusinessLayer." + objectName
            If bizParam IsNot Nothing AndAlso bizParam.Length > 0 Then
                DataBo = Activator.CreateInstance(Type.GetType(bizObjectName), bizParam)
            Else
                DataBo = Activator.CreateInstance(Type.GetType(bizObjectName))
            End If
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObjectName)
                Debugger.Break()
            End If
        End Sub

        Protected Overrides Sub CreateDao(objectName As String, Optional daoParam As Object = Nothing)
            If daoParam IsNot Nothing AndAlso daoParam.Length > 0 Then
                DataDao = DaoFactoryAccounts.CreateDao(objectName, daoParam)
            Else
                DataDao = DaoFactoryAccounts.CreateDao(objectName)
            End If
            If DataDao IsNot Nothing Then
                If objectName = "Basic" Then
                    If daoParam Is Nothing AndAlso daoParam.Length > 0 Then
                        MessageBox.Show("Please provide BasicDao table or itemView name.")
                        Debugger.Break()
                    End If
                End If
            Else
                MessageBox.Show("Missing Data Access Object " + objectName.Trim() + "dao")
                Debugger.Break()
            End If
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Function GetEmployeeIdList()
            Dim model As New List(Of EmployeeIdModel)
            Dim records As List(Of EmployeeId) = DataDao.GetEmployeeIdList()
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetEmployeeLeaveList()
            Dim model As New List(Of EmployeeLeaveModel)
            Dim records As List(Of EmployeeLeave) = DataDao.GetEmployeeLeaveList()
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetAcctReconItems(Of TM)(accountIdNo As Int16, reconciliationDate As Date,
                                                  Optional sortOrder As String = Nothing) As List(Of TM) _
            Implements IServiceAccounts.GetAcctReconItems
            Dim records = DataDao.GetAcctReconItems(accountIdNo, reconciliationDate, sortOrder)
            Dim model As New List(Of TM)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) _
            Implements IServiceAccounts.GetOpenInvoices
            Dim records = DataDao.GetOpenInvoices(idNo)
            Dim model As New List(Of TM)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetReconciledRecordsWithIdNo(Of TM)(reconciled As Boolean, idNo As Int32,
                                                             Optional sortOrder As String = Nothing) As List(Of TM) _
            Implements IServiceAccounts.GetReconciledRecordsWithIdNo
            Return DataDao.GetReconciledRecordsWithIdNo(Of TM)(reconciled, idNo, sortOrder)
        End Function

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer _
                                    Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

        Public Function UpdateOpeningBalance(Of TM)(ByRef model As TM) As Integer _
            Implements IServiceAccounts.UpdateOpeningBalance
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateOpeningBalance(DataBo)
        End Function

        Public Function GenerateCode(ByVal idNo As Integer) As String Implements IServiceAccounts.GenerateCode
            Return DataDao.GenerateCode(idNo)
        End Function

        Public Function UpdateVatNumber(vatNumber As String, idNo As Integer) As Integer Implements IServiceAccounts.UpdateVatNumber
            Return DataDao.UpdateVatNumber(vatNumber, idNo)
        End Function

        Public Function GetAccountBalance(endDate As Date, accountIdNo As Int16) As Decimal Implements IServiceAccounts.GetAccountBalance
            Dim accountDao = New AccountDao
            Return DataDao.GetAccountBalance(endDate, accountIdNo)
        End Function

        Public Function GetOpenPettyCash() Implements IServiceAccounts.GetOpenPettyCash
            Dim records = DataDao.GetOpenPettyCash()
            Dim model As New List(Of PcClosingJournalModel)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetSupplierOpenInvoices(Of TM)(idNo As Integer) As List(Of TM) Implements IServiceAccounts.GetSupplierOpenInvoices
            Dim records = DataDao.GetSupplierOpenInvoices(idNo)
            Dim model As New List(Of TM)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Friend Function GetEmployeeHolidayLeaves(idNo As Integer, holidayIdNo As Short) As List(Of EmployeeLeaveModel)
            Dim records = DataDao.GetEmployeeHolidayLeaves(idNo, holidayIdNo)
            Dim model As New List(Of EmployeeLeaveModel)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetEmployeeLeaves(idNo As Integer, leaveIdNo As Short, Optional filterSelection As String = "") As List(Of EmployeeLeaveModel)
            Dim records = DataDao.GetEmployeeLeaves(idNo, leaveIdNo, filterSelection)
            Dim model As New List(Of EmployeeLeaveModel)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetOverlappingLeave(employeeIdNo As Int32, beginningDate As Date, endingDate As Date) As EmployeeLeaveModel
            Dim records = DataDao.GetOverlappingLeave(employeeIdNo, beginningDate, endingDate)
            Dim model As New EmployeeLeaveModel
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Private Function ComputeFixedRateEarning(payFrequency As Char, amount As Decimal, payRateUnit As Char) As Decimal
            Dim factor As Decimal
            Dim payFrequencySel = CodeToEnum(Of PayFrequencySelection)(payFrequency)
            Dim unitEnum = CodeToEnum(Of PayRateUnitSelection)(payRateUnit)
            Select Case payFrequencySel
                Case PayFrequencySelection.Monthly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 2D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 12D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D / 6D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 1D / 3D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 13D / 2D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 30D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 13D / 6D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 13D / 4D
                    End If
                Case PayFrequencySelection.Yearly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 12D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 24D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 2D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 4D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 52D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 365D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 6D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 12D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 2D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 2D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 26D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 365D / 2D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 3D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 6D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 4D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D / 2D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 13D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 365D / 4D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 1D / 2D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 24D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D / 12D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 1D / 6D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 13D / 4D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 15D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 12D / 52D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 24D / 52D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 52D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D / 26D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 1D / 13D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 7D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If unitEnum = PayRateUnitSelection.Month Then
                        factor = 1D / 30D
                    ElseIf unitEnum = PayRateUnitSelection.SemiMonth Then
                        factor = 1D / 15D
                    ElseIf unitEnum = PayRateUnitSelection.Year Then
                        factor = 1D / 360D
                    ElseIf unitEnum = PayRateUnitSelection.SemiYear Then
                        factor = 1D / 180D
                    ElseIf unitEnum = PayRateUnitSelection.Quarter Then
                        factor = 1D / 90D
                    ElseIf unitEnum = PayRateUnitSelection.Week Then
                        factor = 1D / 7D
                    ElseIf unitEnum = PayRateUnitSelection.Day Then
                        factor = 1D
                    ElseIf unitEnum = PayRateUnitSelection.BiWeek Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

        Public Function GetLastSeriesNumber(seriesName As String) As Integer Implements IServiceAccounts.GetLastSeriesNumber
            Return DataDao.GetLastSeriesNumber(seriesName)
        End Function

        Public Function EmployeeIdInsertTvp(ByVal tvpTable As DataTable) As Integer Implements IServiceAccounts.EmployeeIdInsertTvp
            Return DataDao.EmployeeIdInsertTvp(tvpTable)
        End Function

        Public Function GetUserEmployeeIdNo()
            Dim employeeIdNo As Int32 = GetField(Of Integer, Integer)(GlobalVariables.UserIdNo, "User", "IdNo", "EmployeeIdNo")
            Return employeeIdNo
        End Function

        Public Function GetHolidayTransferItems(ByVal employeeIdNo As Int32, ByVal holidayIdNo As Int16)
            Return DataDao.GetHolidayTransferItems(employeeIdNo, holidayIdNo)
        End Function

        Public Function GetLeaveCredit(ByVal employeeIdNo As Int32, ByVal leaveIdNo As Int16)
            Return DataDao.GetLeaveCredit(employeeIdNo, leaveIdNo)
        End Function

        'Public Function GetCustomerOpenInvoices(Of TM)(idNo As Int32) As List(Of TM)
        '    Return GetOpenInvoices(Of TM)(idNo)
        'End Function

        'Public Function AddInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.AddInvoicePayment
        '    Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
        'End Function

        'Public Function GetCustomerOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) Implements IServiceAccounts.GetCustomerOpenInvoices
        '    Dim records = DataDao.GetCustomerOpenInvoices(idNo)
        '    Dim model As New List(Of TM)
        '    GlobalVariables.Mapper.Map(records, model)
        '    Return model
        'End Function

        'Public Function RemoveInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.RemoveInvoicePayment
        '    Return DataDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        'End Function
    End Class

End Namespace