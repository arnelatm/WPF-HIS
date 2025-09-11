Imports System.Collections.Generic


''' <summary>
''' A concrete implementation of ICustomerService that contains the core
''' business logic for customer management.
''' </summary>
Public Class CustomerService
    Implements ICustomerService

    Private ReadOnly _customerRepository As CustomerRepository

    ''' <summary>
    ''' Initializes a new instance of the CustomerService class.
    ''' </summary>
    ''' <param name="customerRepository">The data repository to use for customer data access.</param>
    Public Sub New(customerRepository As CustomerRepository)
        _customerRepository = customerRepository
    End Sub

    ''' <summary>
    ''' Retrieves all customers from the repository.
    ''' </summary>
    Public Function GetCustomers() As List(Of CustomerDTO) Implements ICustomerService.GetCustomers
        Return _customerRepository.GetCustomers()
    End Function

    ''' <summary>
    ''' Saves a customer after performing validation.
    ''' </summary>
    Public Function SaveCustomer(customer As CustomerDTO) As ValidationResult Implements ICustomerService.SaveCustomer
        ' Step 1: Perform validation
        If String.IsNullOrWhiteSpace(customer.FirstName) Then
            Return ValidationResult.Fail("First Name cannot be empty.")
        End If

        ' Step 2: Use the repository to save the customer
        Dim result As ValidationResult = _customerRepository.SaveCustomer(customer)
        Return result
    End Function

End Class


