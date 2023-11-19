Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class ClinicLabSampleDetailDao
        Inherits AccountsDao

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function UpdateRecord(idNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
            Dim sql As String =
                    " UPDATE [ClinicLabSampleTaken] Set" &
                    " Urine = @Urine," &
                    " Stool = @Stool," &
                    " Rbs = @Rbs" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs, "@IdNo", idNo})
        End Function

    End Class

End Namespace