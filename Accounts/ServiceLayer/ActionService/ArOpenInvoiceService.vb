
Imports AATM.Accounts.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ArOpenInvoiceService
        Inherits ServiceAccounts
        Implements IArOpenInvoiceService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared ReadOnly ArOpenInvoiceDao As IArOpenInvoiceDao = Factory.ArOpenInvoiceDao

        Public Overrides Function GetServiceDao()
            Return ArOpenInvoiceDao
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IArOpenInvoiceService.AddInvoicePayment
            Return ArOpenInvoiceDao.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IArOpenInvoiceService.RemoveInvoicePayment
            Return ArOpenInvoiceDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

    End Class

    Friend Interface IArOpenInvoiceService

        Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

        Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal)

    End Interface

End Namespace