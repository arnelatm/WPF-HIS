Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class IbLabSampleDetailDao
        Inherits AccountsDao

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function UpdateRecord(idNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
            Dim sql As String =
                    " UPDATE [IbLabSampleTaken] Set" &
                    " Urine = @Urine," &
                    " Stool = @Stool," &
                    " Rbs = @Rbs" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs, "@IdNo", idNo})
        End Function

    End Class

    Public Class IbLabResultDetailDao
        Inherits AccountsDao

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function UpdateRecord(IdNo As Int32, passportNumber As String, clinical As Boolean, Xray As Boolean, TBSputum As Boolean,
                                                hivEliza As Boolean, hovEliza As Boolean, hbsagEliza As Boolean, malaria As Boolean, vdrl As Boolean,
                                                Widal As Boolean, pregnancy As Boolean, bilharziasisUrine As Boolean,
                                                bilharziasisStool As Boolean, shigella As Boolean, cholera As Boolean)
            Dim sql As String =
                    " UPDATE [IbLabResult] Set" &
                    " PassportNumber = @PassportNumber," &
                    " Clinical = @Clinical," &
                    " Xray = @Xray," &
                    " TBSputum = @TBSputum," &
                    " HIVEliza = @HIVEliza," &
                    " HOVEliza = @HOVEliza," &
                    " HBSAgEliza = @HBSAgEliza," &
                    " Malaria = @Malaria," &
                    " VDRL = @VDRL," &
                    " Widal = @Widal," &
                    " Pregnancy = @Pregnancy," &
                    " BilharziasisUrine = @BilharziasisUrine," &
                    " BilharziasisStool = @BilharziasisStool," &
                    " Shigella = @Shigella," &
                    " Cholera = @Cholera" &
                    " WHERE IdNo = @IdNo "
            Return _db.Update(sql, {"@PassportNumber", passportNumber, "@Clinical", clinical, "@Xray", Xray, "@TBSputum", TBSputum, "@HIVEliza", hivEliza,
                    "@HOVEliza", hovEliza, "@HBSAgEliza", hbsagEliza, "@Malaria", malaria, "@VDRL", vdrl, "@Widal", Widal, "@Pregnancy", pregnancy,
                    "@BilharziasisUrine", bilharziasisUrine, "@BilharziasisStool", bilharziasisStool, "@Shigella", shigella, "@Cholera", cholera, "@IdNo", IdNo})
        End Function

    End Class
End Namespace