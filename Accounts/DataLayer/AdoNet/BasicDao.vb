Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for Basic
    ' ** DAO Pattern

    Public Class BasicDao
        Inherits CommonDao
        Implements IDao(Of Basic)

        Private ReadOnly Db As New Db()
        Private ReadOnly _tableOrViewName As String

        Public Sub New(ByVal tableName As Object)
            _tableOrViewName = tableName.ToString()
        End Sub

        Public Function GetRecordByIdNo(idNo) As Basic Implements IDao(Of Basic).GetRecordByIdNo
            Dim fields As String = "IdNo," + _tableOrViewName + "Code," + _tableOrViewName + "Name," + _tableOrViewName + "NameAra"
            If GlobalFunctions.LimitToBranch(_tableOrViewName) Then
                fields += ",BranchIdNo"
            End If
            Dim sql As String = "SELECT " & fields &
                    " FROM " & _tableOrViewName &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            If GlobalFunctions.LimitToBranch(_tableOrViewName) Then
                Return Db.Read(sql, MakeBranch, params).FirstOrDefault()
            Else
                Return Db.Read(sql, Make, params).FirstOrDefault()
            End If
        End Function

        Public Function UpdateRecord(ByRef Basic As Basic) As Integer Implements IDao(Of Basic).UpdateRecord
            Dim fields As String = _tableOrViewName + "Code = @Code," &
                                   _tableOrViewName + "Name = @Name," &
                                   _tableOrViewName + "NameAra = @NameAra" &
                                   IIf(GlobalFunctions.LimitToBranch(_tableOrViewName), ",BranchIdNo = @BranchIdNo", "")
            Dim sql As String = " UPDATE " & _tableOrViewName & " SET " + fields + "  WHERE IdNo = @IdNo"
            If GlobalFunctions.LimitToBranch(_tableOrViewName) Then
                Return Db.Update(sql, TakeBranch(Basic))
            Else
                Return Db.Update(sql, Take(Basic))
            End If
        End Function

        Public Function AddRecord(ByRef Basic As Basic) As Integer Implements IDao(Of Basic).AddRecord
            Dim fields As String = _tableOrViewName + "Code," + _tableOrViewName + "Name," + _tableOrViewName + "NameAra"
            Dim values As String = "@Code,@Name,@NameAra" + IIf(LimitToBranch(_tableOrViewName), ",@BranchIdNo", "")
            If GlobalFunctions.LimitToBranch(_tableOrViewName) Then
                fields += ",BranchIdNo"
            End If
            Dim sql As String =
                    " INSERT INTO " & _tableOrViewName &
                    " (" & fields & ")" &
                    " VALUES (" & values & ")"
            If GlobalFunctions.LimitToBranch(_tableOrViewName) Then
                Return Db.Insert(sql, TakeBranch(Basic))
            Else
                Return Db.Insert(sql, Take(Basic))
            End If
        End Function

        Private ReadOnly Make As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Code = Extensions.AsString(reader(_tableOrViewName + "Code")),
            .Name = Extensions.AsString(reader(_tableOrViewName + "Name")),
            .NameAra = Extensions.AsString(reader(_tableOrViewName + "NameAra"))
            }

        Private ReadOnly MakeBranch As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .Code = Extensions.AsString(reader(_tableOrViewName + "Code")),
            .Name = Extensions.AsString(reader(_tableOrViewName + "Name")),
            .NameAra = Extensions.AsString(reader(_tableOrViewName + "NameAra"))
            }

        Private Function Take(Basic As Basic) As Object()
            Return New Object() {
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra
                                }
        End Function

        Private Function TakeBranch(Basic As Basic) As Object()
            Return New Object() {
                                    "@BranchIdNo", Basic.BranchIdNo,
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra
                                }
        End Function

    End Class

End Namespace