
Imports System.Configuration
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ApOpenInvoiceService
        Inherits ServiceAccounts
        Implements IApOpenInvoiceService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ApOpenInvoiceDao As IApOpenInvoiceDao = Factory.ApOpenInvoiceDao

        Public Overrides Function GetServiceDao()
            Return ApOpenInvoiceDao
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IApOpenInvoiceService.AddInvoicePayment
            Return ApOpenInvoiceDao.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IApOpenInvoiceService.RemoveInvoicePayment
            Return ApOpenInvoiceDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

    End Class

    Friend Interface IApOpenInvoiceService

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

    End Interface

End Namespace