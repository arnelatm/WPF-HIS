Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PayElement
    ' ** DAO Pattern

    Public Class PayElementDao
        Implements IDao(Of PayElement), IDaoAll(Of PayElement), IDaoGetRecords(Of PayElement), IDaoGetRecord(Of PayElement)

        Private Const FieldList = "AccountIdNo," &
                                  "BasePaymentIdNo," &
                                  "CalculationType," &
                                  "DefaultQuantity," &
                                  "FactorType," &
                                  "FactorValue," &
                                  "Frequency," &
                                  "IdNo," &
                                  "IncludeInEOS," &
                                  "Notes," &
                                  "PayElementCode," &
                                  "PayElementKind," &
                                  "PayElementName," &
                                  "PayElementNameAra," &
                                  "PayElementType," &
                                  "QuantityType," &
                                  "Rate," &
                                  "ReportGroupIdNo," &
                                  "Summary," &
                                  "Taxable," &
                                  "Unit," &
                                  "UsePayGroups"

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As PayElement Implements IDao(Of PayElement).GetRecordByIdNo
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayElement]" &
                                " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim peaDao = New PayElementAccountDao()
            data.PayElementAccounts = peaDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Dim esDao = New PayElementItemDao()
            data.PayElementItems = esDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Return data
        End Function

        Public Function UpdateRecord(ByRef PayElement As PayElement) As Integer Implements IDao(Of PayElement).UpdateRecord
            Dim sql As String = " UPDATE [PayElement] Set" &
                    " AccountIdNo = @AccountIdNo," &
                    " BasePaymentIdNo = @BasePaymentIdNo," &
                    " CalculationType = @CalculationType," &
                    " DefaultQuantity = @DefaultQuantity," &
                    " FactorType = @FactorType," &
                    " FactorValue = @FactorValue," &
                    " Frequency = @Frequency," &
                    " IncludeInEos = @IncludeInEos," &
                    " Notes = @Notes," &
                    " PayElementCode = @PayElementCode," &
                    " PayElementKind = @PayElementKind," &
                    " PayElementName = @PayElementName," &
                    " PayElementNameAra = @PayElementNameAra," &
                    " PayElementType = @PayElementType," &
                    " QuantityType = @QuantityType," &
                    " Rate = @Rate," &
                    " ReportGroupIdNo = @ReportGroupIdNo," &
                    " Summary = @Summary," &
                    " Taxable = @Taxable," &
                    " Unit = @Unit," &
                    " UsePayGroups = @UsePayGroups" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(PayElement))
        End Function

        Public Function AddRecord(ByRef PayElement As PayElement) As Integer Implements IDao(Of PayElement).AddRecord
            Dim sql As String =
                    " INSERT INTO [PayElement] " &
                    "        (AccountIdNo ,BasePaymentIdNo ,CalculationType ,DefaultQuantity ,PayElementCode ,PayElementKind ,Summary ,PayElementName ,PayElementNameAra ,PayElementType ,Frequency ,IncludeInEos ,FactorValue,FactorType  ,QuantityType ,ReportGroupIdNo, Notes ,Rate ,Taxable ,Unit ,UsePayGroups) " &
                    " VALUES (@AccountIdNo,@BasePaymentIdNo,@CalculationType,@DefaultQuantity,@PayElementCode,@PayElementKind,@Summary,@PayElementName,@PayElementNameAra,@PayElementType,@Frequency,@IncludeInEos,@FactorValue,@FactorType,@QuantityType,@ReportGroupIdNo,@Notes,@Rate,@Taxable,@Unit,@UsePayGroups) "
            Return _db.Insert(sql, Take(PayElement))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PayElement) =
                                    Function(reader) _
            New PayElement() With {
            .AccountIdNo = Extensions.AsId(Of Int16)(reader("AccountIdNo")),
            .BasePaymentIdNo = Extensions.AsId(Of Int16)(reader("BasePaymentIdNo")),
            .CalculationType = Extensions.AsChar(reader("CalculationType")),
            .DefaultQuantity = Extensions.AsDecimal(reader("DefaultQuantity")),
            .FactorType = Extensions.AsString(reader("FactorType")),
            .FactorValue = Extensions.AsDecimal(reader("FactorValue")),
            .Frequency = Extensions.AsChar(reader("Frequency")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .IncludeInEos = Extensions.AsBool(reader("IncludeInEos")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PayElementCode = Extensions.AsString(reader("PayElementCode")),
            .PayElementKind = Extensions.AsString(reader("PayElementKind")),
            .PayElementName = Extensions.AsString(reader("PayElementName")),
            .PayElementNameAra = Extensions.AsString(reader("PayElementNameAra")),
            .PayElementType = Extensions.AsChar(reader("PayElementType")),
            .QuantityType = Extensions.AsChar(reader("QuantityType")),
            .Rate = Extensions.AsDouble(reader("Rate")),
            .ReportGroupIdNo = Extensions.AsId(Of Int16)(reader("ReportGroupIdNo")),
            .Summary = Extensions.AsBool(reader("Summary")),
            .Taxable = Extensions.AsBool(reader("Taxable")),
            .Unit = Extensions.AsChar(reader("Unit")),
            .UsePayGroups = Extensions.AsBool(reader("UsePayGroups"))
            }

        Private Function Take(PayElement As PayElement) As Object()
            Return New Object() {
                                    "@AccountIdNo", PayElement.AccountIdNo,
                                    "@BasePaymentIdNo", PayElement.BasePaymentIdNo,
                                    "@CalculationType", PayElement.CalculationType,
                                    "@DefaultQuantity", PayElement.DefaultQuantity,
                                    "@FactorType", PayElement.FactorType,
                                    "@FactorValue", PayElement.FactorValue,
                                    "@Frequency", PayElement.Frequency,
                                    "@IdNo", PayElement.IdNo,
                                    "@IncludeInEos", PayElement.IncludeInEos,
                                    "@Notes", PayElement.Notes,
                                    "@PayElementCode", PayElement.PayElementCode,
                                    "@PayElementKind", PayElement.PayElementKind,
                                    "@PayElementName", PayElement.PayElementName,
                                    "@PayElementNameAra", PayElement.PayElementNameAra,
                                    "@PayElementType", PayElement.PayElementType,
                                    "@QuantityType", PayElement.QuantityType,
                                    "@ReportGroupIdNo", PayElement.ReportGroupIdNo,
                                    "@Rate", PayElement.Rate,
                                    "@Summary", PayElement.Summary,
                                    "@Taxable", PayElement.Taxable,
                                    "@Unit", PayElement.Unit,
                                    "@UsePayGroups", PayElement.UsePayGroups
                                }
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PayElement) Implements IDaoAll(Of PayElement).GetAll
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM [PayElement]"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of PayElement) Implements IDaoGetRecords(Of PayElement).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PayElement]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As PayElement Implements IDaoGetRecord(Of PayElement).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [PayElement]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).FirstOrDefault()
        End Function

    End Class

End Namespace