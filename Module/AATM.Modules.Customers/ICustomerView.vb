Imports System.Collections.Generic

Public Interface ICustomerView
    Event LoadCustomers As EventHandler
    Event SaveCustomer(ByVal customer As CustomerDTO)

    Sub DisplayCustomers(ByVal customers As List(Of CustomerDTO))
    Sub EnableView(ByVal isEnabled As Boolean)
End Interface