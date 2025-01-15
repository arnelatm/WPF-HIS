Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class IbLabSampleDetailDao
        Inherits AccountsDao

        Private ReadOnly _db As New Db()

        Public Sub New(connectionName As String)
            _db = New Db(connectionName)
        End Sub

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

        Public Function AddRecord(invoiceNo As Int32, urine As Boolean?, stool As Boolean?, rbs As Decimal?, labNo As String, takenBy As String, takenDate As String, takenTime As String)
            Dim sql As String = " Insert Into [IbLabSampleTaken] " &
                    " (Trans_key, Urine, Stool, Rbs, LabReportNo, TakenBy, TakenDate, TakenTime) " &
                    " Values " &
                    " (@InvoiceNo, @Urine, @Stool, @Rbs, @LabNo, @TakenBy, @TakenDate, @TakenTime)"
            Return _db.Insert(sql, {"@InvoiceNo", invoiceNo, "@Urine", urine, "@Stool", stool, "@Rbs", rbs, "@LabNo", labNo, "@TakenBy", takenBy, "@TakenDate", takenDate, "@TakenTime", takenTime})

        End Function

    End Class

    Public Class IbLabResultDetailDao
        Inherits AccountsDao

        Private ReadOnly _db As New Db()
        Private ReadOnly _connection As String
        Private ReadOnly _testType As String

        Public Sub New(parameter As Object)
            _connection = parameter(0)
            _testType = parameter(1)
            _db = New Db(_connection)
        End Sub
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