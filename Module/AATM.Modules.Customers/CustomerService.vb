Imports AATM.Core.Logging
Imports AATM.Core.Messaging
Imports AATM.Core.Utilities
Imports System.Collections.Generic

''' <summary>
''' The service that contains the core business logic for customer management.
''' This class is responsible for data validation and interacting with the repository.
''' </summary>
Public Class CustomerService
    Implements ICustomerService

    Private ReadOnly _customerRepository As CustomerRepository
    Private ReadOnly _logger As ILogger
    Private ReadOnly _messagingService As IMessagingService

    ''' <summary>
    ''' Initializes a new instance of the CustomerService class with its dependencies.
    ''' </summary>
    Public Sub New(customerRepository As CustomerRepository, logger As ILogger, messagingService As IMessagingService)
        _customerRepository = customerRepository
        _logger = logger
        _messagingService = messagingService
    End Sub

    ''' <summary>
    ''' Retrieves all customers from the repository.
    ''' </summary>
    Public Function GetCustomers() As List(Of CustomerDTO) Implements ICustomerService.GetCustomers
        Try
            Return _customerRepository.GetCustomers()
        Catch ex As Exception
            _logger.LogException(ex)
            _messagingService.ShowError("An error occurred while fetching customer data.")
            Return New List(Of CustomerDTO)()
        End Try
    End Function

    ''' <summary>
    ''' Validates and saves a customer. Handles both creation and updates.
    ''' </summary>
    Public Function SaveCustomer(customer As CustomerDTO) As ValidationResult Implements ICustomerService.SaveCustomer
        ' Basic validation for required fields
        If Not ValidationUtils.IsNotNullOrEmpty(customer.FirstName) Then
            Return ValidationResult.Fail("First Name is required.")
        End If
        If Not ValidationUtils.IsNotNullOrEmpty(customer.LastName) Then
            Return ValidationResult.Fail("Last Name is required.")
        End If
        If Not ValidationUtils.IsValidEmail(customer.Email) Then
            Return ValidationResult.Fail("A valid email is required.")
        End If

        ' Determine if this is an update or a new customer.
        If customer.CustomerID > 0 Then
            _logger.LogInfo($"Attempting to update customer with ID: {customer.CustomerID}")
            Try
                _customerRepository.UpdateCustomer(customer)
                Return ValidationResult.Success()
            Catch ex As Exception
                _logger.LogException(ex)
                Return ValidationResult.Fail("An error occurred while updating the customer.")
            End Try
        Else
            _logger.LogInfo("Attempting to save a new customer.")
            Try
                _customerRepository.AddCustomer(customer)
                Return ValidationResult.Success()
            Catch ex As Exception
                _logger.LogException(ex)
                Return ValidationResult.Fail("An error occurred while adding the new customer.")
            End Try
        End If
    End Function

    ''' <summary>
    ''' Deletes a customer from the data store.
    ''' </summary>
    Public Function DeleteCustomer(customerID As Integer) As ValidationResult Implements ICustomerService.DeleteCustomer
        If customerID <= 0 Then
            Return ValidationResult.Fail("Invalid customer ID for deletion.")
        End If

        _logger.LogWarning($"Attempting to delete customer with ID: {customerID}")
        Try
            _customerRepository.DeleteCustomer(customerID)
            Return ValidationResult.Success()
        Catch ex As Exception
            _logger.LogException(ex)
            Return ValidationResult.Fail("An error occurred while deleting the customer.")
        End Try
    End Function

End Class


'Imports AATM.Core.Logging
'Imports AATM.Core.Messaging
'Imports AATM.Core.Utilities

'Public Class CustomerService
'    Implements ICustomerService

'    Private ReadOnly _customerRepository As CustomerRepository
'    Private ReadOnly _logger As ILogger
'    Private ReadOnly _messagingService As IMessagingService

'    ''' <summary>
'    ''' Initializes a new instance of the CustomerService.
'    ''' </summary>
'    ''' <param name="customerRepository">The repository for data access.</param>
'    ''' <param name="logger">The logging service for recording events and errors.</param>
'    ''' <param name="messagingService">The messaging service for user feedback.</param>
'    Public Sub New(customerRepository As CustomerRepository, logger As ILogger, messagingService As IMessagingService)
'        _customerRepository = customerRepository
'        _logger = logger
'        _messagingService = messagingService
'    End Sub

'    ''' <summary>
'    ''' Gets a list of all customers from the repository.
'    ''' </summary>
'    ''' <returns>A list of CustomerDTO objects.</returns>
'    Public Function GetCustomers() As List(Of CustomerDTO) Implements ICustomerService.GetCustomers
'        Try
'            _logger.LogInfo("Attempting to retrieve customer data.")
'            Dim customers As List(Of CustomerDTO) = _customerRepository.GetCustomers()
'            _logger.LogInfo("Customer data retrieved successfully.")
'            Return customers
'        Catch ex As Exception
'            _logger.LogException(ex)
'            _messagingService.ShowError("Failed to retrieve customer data.")
'            Return New List(Of CustomerDTO)()
'        End Try
'    End Function

'    ''' <summary>
'    ''' Saves a customer to the database after validating their data.
'    ''' </summary>
'    ''' <param name="customer">The CustomerDTO to save.</param>
'    ''' <returns>A ValidationResult object indicating success or failure.</returns>
'    Public Function SaveCustomer(customer As CustomerDTO) As ValidationResult Implements ICustomerService.SaveCustomer
'        _logger.LogInfo($"Attempting to save customer: {customer.FirstName} {customer.LastName}.")

'        ' Perform comprehensive validation using the shared ValidationUtils.
'        If Not ValidationUtils.IsNotNullOrEmpty(customer.FirstName) OrElse Not ValidationUtils.HasMaximumLength(customer.FirstName, 50) Then
'            _logger.LogError("Validation failed: First name is required and must be under 50 characters.")
'            _messagingService.ShowError("First name is required.")
'            Return ValidationResult.Fail("First name is required and must be under 50 characters.")
'        End If

'        If Not ValidationUtils.IsNotNullOrEmpty(customer.LastName) OrElse Not ValidationUtils.HasMaximumLength(customer.LastName, 50) Then
'            _logger.LogError("Validation failed: Last name is required and must be under 50 characters.")
'            _messagingService.ShowError("Last name is required.")
'            Return ValidationResult.Fail("Last name is required and must be under 50 characters.")
'        End If

'        If Not ValidationUtils.IsValidEmail(customer.Email) OrElse Not ValidationUtils.HasMaximumLength(customer.Email, 100) Then
'            _logger.LogError("Validation failed: Invalid email address.")
'            _messagingService.ShowError("Please enter a valid email address.")
'            Return ValidationResult.Fail("Please enter a valid email address.")
'        End If

'        Try
'            _customerRepository.SaveCustomer(customer)
'            _logger.LogInfo("Customer saved successfully.")
'            _messagingService.ShowSuccess("Customer saved successfully.")
'            Return ValidationResult.Success()
'        Catch ex As Exception
'            _logger.LogException(ex)
'            _messagingService.ShowError("An error occurred while saving the customer.")
'            Return ValidationResult.Fail("An error occurred while saving the customer.")
'        End Try
'    End Function
'End Class
