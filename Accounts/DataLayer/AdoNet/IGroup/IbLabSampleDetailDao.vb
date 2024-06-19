Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
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

        Public Function UpdateRecord(IdNo As Int32, passportNumber As String, clinical As Boolean?, Xray As Boolean?, TBSputum As Boolean?,
                                                hivEliza As Boolean?, HCVEliza As Boolean?, hbsagEliza As Boolean?, malaria As Boolean?, vdrl As Boolean?,
                                                Widal As Boolean?, pregnancy As Boolean?, bilharziasisUrine As Boolean?,
                                                bilharziasisStool As Boolean?, shigella As Boolean?, cholera As Boolean?)
            Dim sql As String =
                    " UPDATE [IbLabResult] Set" &
                    " PassportNumber = @PassportNumber," &
                    " Clinical = @Clinical," &
                    " Xray = @Xray," &
                    " TBSputum = @TBSputum," &
                    " HIVEliza = @HIVEliza," &
                    " HCVEliza = @HCVEliza," &
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
                    "@HCVEliza", HCVEliza, "@HBSAgEliza", hbsagEliza, "@Malaria", malaria, "@VDRL", vdrl, "@Widal", Widal, "@Pregnancy", pregnancy,
                    "@BilharziasisUrine", bilharziasisUrine, "@BilharziasisStool", bilharziasisStool, "@Shigella", shigella, "@Cholera", cholera, "@IdNo", IdNo})
        End Function

        Public Function UpdateGender(transKey As Int32, gender As String)
            Dim sql As String =
                    " UPDATE IbInvoiceGroup Set" &
                    " Sex = @Gender" &
                    " WHERE Trans_key = @TransKey"
            Return _db.Update(sql, {"@TransKey", transKey, "@Gender", gender})
        End Function

        Public Function UpdatePatientName(transKey As Int32, patientName As String)
            Dim sql As String =
                    " UPDATE IbInvoiceGroup Set" &
                    " PatientName = @PatientName" &
                    " WHERE Trans_key = @TransKey"
            Return _db.Update(sql, {"@TransKey", transKey, "@PatientName", patientName})
        End Function

        Public Function UpdateNationality(transKey As Int32, nationality As String)
            Dim sql As String =
                    " UPDATE IbInvoiceGroup Set" &
                    " CountryIOTA = @Nationality" &
                    " WHERE Trans_key = @TransKey"
            Return _db.Update(sql, {"@TransKey", transKey, "@Nationality", nationality})
        End Function

        Public Function UpdateIqamaNo(transKey As Int32, iqamaNo As String)
            Dim sql As String =
                    " UPDATE IbInvoiceGroup Set" &
                    " Border_Iqama = @IqamaNo" &
                    " WHERE Trans_key = @TransKey"
            Return _db.Update(sql, {"@TransKey", transKey, "@IqamaNo", iqamaNo})
        End Function

        Public Function UpdateProfession(transKey As Int32, profession As String)
            Dim sql As String =
                    " UPDATE IbInvoiceGroup Set" &
                    " Profession = @Profession" &
                    " WHERE Trans_key = @TransKey"
            Return _db.Update(sql, {"@TransKey", transKey, "@Profession", profession})
        End Function

        Public Function AddRecord(primaryKey As Int32, passportNumber As String, clinical As Boolean?, Xray As Boolean?, TBSputum As Boolean?,
                                  hivEliza As Boolean?, HCVEliza As Boolean?, hbsagEliza As Boolean?, malaria As Boolean?, vdrl As Boolean?,
                                  Widal As Boolean?, pregnancy As Boolean?, bilharziasisUrine As Boolean?,
                                  bilharziasisStool As Boolean?, shigella As Boolean?, cholera As Boolean?)
            Dim sql As String = " Insert Into [IbLabResult] " &
                    " (Trans_Key, PassportNumber, Clinical, Xray, TBSputum, HIVEliza, HCVEliza, HBSAgEliza, Malaria, VDRL, Widal, Pregnancy, BilharziasisUrine, BilharziasisStool, Shigella, Cholera) " &
                    " Values " &
                    " (@PrimaryKey, @PassportNumber, @Clinical, @Xray, @TBSputum, @HIVEliza, @HCVEliza, @HBSAgEliza, @Malaria, @VDRL, @Widal, @Pregnancy, @BilharziasisUrine, @BilharziasisStool, @Shigella, @Cholera)"
            Return _db.Insert(sql, {"@PrimaryKey", primaryKey, "@PassportNumber", passportNumber, "@Clinical", clinical, "@Xray", Xray, "@TBSputum", TBSputum, "@HIVEliza", hivEliza,
                    "@HCVEliza", HCVEliza, "@HBSAgEliza", hbsagEliza, "@Malaria", malaria, "@VDRL", vdrl, "@Widal", Widal, "@Pregnancy", pregnancy,
                    "@BilharziasisUrine", bilharziasisUrine, "@BilharziasisStool", bilharziasisStool, "@Shigella", shigella, "@Cholera", cholera})

        End Function

    End Class
End Namespace