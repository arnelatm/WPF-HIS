Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeMedicalReportView
        Inherits IViewNew

        Property EmployeeIdNoData As DataTable
        Property EmployeeIdNo As Int32
        Event MakeDataRequested1(tableName As String, variableName As DataTable)

    End Interface


End Namespace