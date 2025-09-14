Imports System.Collections.Generic
Imports System.Linq

''' <summary>
''' The repository for customer data.
''' This class is responsible for all data access operations.
''' In a real-world application, this would interact with a database.
''' </summary>
Public Class CustomerRepository

    ' Simulates a database table for customers.
    Private Shared ReadOnly _customers As New List(Of CustomerDTO)()
    Private Shared _nextId As Integer = 1

    ''' <summary>
    ''' Retrieves a list of all customers from the data store.
    ''' </summary>
    ''' <returns>A list of CustomerDTO objects.</returns>
    Public Function GetCustomers() As List(Of CustomerDTO)
        Return _customers.ToList()
    End Function

    ''' <summary>
    ''' Adds a new customer to the data store.
    ''' </summary>
    ''' <param name="customer">The customer DTO to be added.</param>
    Public Sub AddCustomer(customer As CustomerDTO)
        customer.CustomerID = System.Threading.Interlocked.Increment(_nextId)
        _customers.Add(customer)
    End Sub

    ''' <summary>
    ''' Updates an existing customer in the data store.
    ''' </summary>
    ''' <param name="customer">The customer DTO with updated information.</param>
    Public Sub UpdateCustomer(customer As CustomerDTO)
        Dim existingCustomer As CustomerDTO = _customers.FirstOrDefault(Function(c) c.CustomerID = customer.CustomerID)
        If existingCustomer IsNot Nothing Then
            existingCustomer.FirstName = customer.FirstName
            existingCustomer.LastName = customer.LastName
            existingCustomer.Email = customer.Email
        End If
    End Sub

    ''' <summary>
    ''' Deletes a customer from the data store.
    ''' </summary>
    ''' <param name="customerID">The ID of the customer to delete.</param>
    Public Sub DeleteCustomer(customerID As Integer)
        Dim customerToRemove As CustomerDTO = _customers.FirstOrDefault(Function(c) c.CustomerID = customerID)
        If customerToRemove IsNot Nothing Then
            _customers.Remove(customerToRemove)
        End If
    End Sub

End Class



'Imports System.Collections.Generic

'''' <summary>
'''' A mock repository for managing customer data.
'''' In a real application, this would connect to a database.
'''' </summary>
'Public Class CustomerRepository

'    Private Shared ReadOnly _customers As New List(Of CustomerDTO) From {
'            New CustomerDTO With {.CustomerID = 1, .FirstName = "John", .LastName = "Doe", .Email = "john.doe@email.com", .DateAdded = New Date(2023, 1, 1)},
'            New CustomerDTO With {.CustomerID = 2, .FirstName = "Jane", .LastName = "Smith", .Email = "jane.smith@email.com", .DateAdded = New Date(2023, 2, 15)}
'        }
'    Private Shared _nextID As Integer = _customers.Max(Function(c) c.CustomerID) + 1

'    ''' <summary>
'    ''' Retrieves a list of all customers.
'    ''' </summary>
'    Public Function GetCustomers() As List(Of CustomerDTO)
'        Return _customers.OrderBy(Function(c) c.LastName).ToList()
'    End Function

'    ''' <summary>
'    ''' Saves a customer to the data store.
'    ''' </summary>
'    ''' <param name="customer">The customer DTO to save.</param>
'    Public Function SaveCustomer(customer As CustomerDTO) As ValidationResult
'        ' This is a simple mock save. In a real app, this would save to a database.
'        Try
'            If customer.CustomerID = 0 Then
'                ' This is a new customer.
'                customer.CustomerID = System.Threading.Interlocked.Increment(_nextID)
'                customer.DateAdded = Date.Now
'                _customers.Add(customer)
'            Else
'                ' This is an existing customer to update.
'                Dim existingCustomer = _customers.FirstOrDefault(Function(c) c.CustomerID = customer.CustomerID)
'                If existingCustomer IsNot Nothing Then
'                    existingCustomer.FirstName = customer.FirstName
'                    existingCustomer.LastName = customer.LastName
'                    existingCustomer.Email = customer.Email
'                Else
'                    Return ValidationResult.Fail("Customer not found for update.")
'                End If
'            End If
'            Return ValidationResult.Success()
'        Catch ex As Exception
'            Return ValidationResult.Fail($"An error occurred while saving: {ex.Message}")
'        End Try
'    End Function

'End Class