Imports System.Collections.Generic
Imports AATM.Modules.Customers

''' <summary>
''' Defines a contract for a service that provides customer-related business logic.
''' This interface decouples the presenter from the specific business logic implementation.
''' </summary>
Public Interface ICustomerService
    ''' <summary>
    ''' Retrieves a list of all customers.
    ''' </summary>
    Function GetCustomers() As List(Of CustomerDTO)

    ''' <summary>
    ''' Saves a customer record, either updating an existing one or adding a new one.
    ''' </summary>
    ''' <param name="customer">The customer data transfer object to save.</param>
    Function SaveCustomer(customer As CustomerDTO) As ValidationResult
End Interface
