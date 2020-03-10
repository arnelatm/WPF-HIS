Imports AATM.BusinessLayer.BusinessObjects

Public Interface IDaoChild(Of TBiz)
    ' gets a specific record data

    Function GetRecordById(idNo As Integer) As TBiz
    Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Integer) As Integer
    Function InsertTvp(ByRef tvpTable As DataTable) As Integer 
    
End Interface
