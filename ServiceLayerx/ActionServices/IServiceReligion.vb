Imports AATM.Businesslayer


Public Interface IServiceReligion

    Function GetReligions(ByVal sortExpression As String) As List(Of Religion)
    Function GetReligion(ByVal idNo As Integer) As Religion
    Function InsertReligion(ByVal religion As Religion) As Integer
    Function UpdateReligion(ByVal religion As Religion) As Integer


End Interface


