Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Dosage
    ' ** DAO Pattern

    Public Class DosagePrintingDao
        Inherits DosageDao


        'Public Function GetPatientDetails(idNo) As IgPatient
        '    Dim sql As String =
        '            "SELECT " & _fieldList &
        '            " FROM Dosage_View" &
        '            " WHERE IdNo = @IdNo"

        '    Dim params() As Object = {"@IdNo", idNo}
        '    Dim value As Dosage = _db.Read(sql, Make, params).FirstOrDefault()
        '    Return value
        'End Function

    End Class

End Namespace