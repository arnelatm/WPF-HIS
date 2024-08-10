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
        Implements IDao(Of Basic), IDaoAutoCode

        Private ReadOnly Db As New Db()
        Private ReadOnly _tableOrViewName As String
        Private _table As String
        Private Property WithNotes As Boolean
        Private Property LimitToBranch As Boolean

        Public Sub New(ByVal tableName As Object)
            _tableOrViewName = tableName.ToString()
            WithNotes = IIf(Accounts.AccountHelpers.BasicWithNotes(tableName), True, False)
            LimitToBranch = IIf(Accounts.AccountHelpers.LimitToBranch(tableName), True, False)
        End Sub

        Public Function GetRecordByIdNo(idNo) As Basic Implements IDao(Of Basic).GetRecordByIdNo
            Dim fields As String
            If _tableOrViewName.Length > 4 AndAlso _tableOrViewName.Right(5) = "_View" Then
                _table = Strings.Left(_tableOrViewName, _tableOrViewName.Length - 5)
            Else
                _table = _tableOrViewName
            End If
            fields = "IdNo," + _table + "Code," + _table + "Name," + _table + "NameAra"
            If WithNotes Then
                fields += ",Notes"
            End If
            If LimitToBranch Then
                fields += ",BranchIdNo"
            End If
            Dim sql As String = "SELECT " & fields &
                    " FROM " & _tableOrViewName &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            If LimitToBranch Then
                If WithNotes Then
                    Return Db.Read(sql, MakeBranchNotes, params).FirstOrDefault()
                Else
                    Return Db.Read(sql, MakeBranch, params).FirstOrDefault()
                End If
            Else
                If WithNotes Then
                    Return Db.Read(sql, MakeNotes, params).FirstOrDefault()
                Else
                    Return Db.Read(sql, Make, params).FirstOrDefault()
                End If
            End If
        End Function

        Public Function UpdateRecord(ByRef Basic As Basic) As Integer Implements IDao(Of Basic).UpdateRecord
            Dim withNotes As Boolean = IIf(Accounts.AccountHelpers.BasicWithNotes(_tableOrViewName), True, False)
            Dim fields As String = _table + "Code = @Code," &
                                   _table + "Name = @Name," &
                                   _table + "NameAra = @NameAra" &
                                   IIf(withNotes, ",Notes = @Notes", "") &
                                   IIf(LimitToBranch, ",BranchIdNo = @BranchIdNo", "")
            Dim sql As String = " UPDATE " & _tableOrViewName & " SET " + fields + "  WHERE IdNo = @IdNo"
            If LimitToBranch Then
                Return Db.Update(sql, TakeBranch(Basic))
            Else
                Return Db.Update(sql, Take(Basic))
            End If
        End Function

        Public Function AddRecord(ByRef Basic As Basic) As Integer Implements IDao(Of Basic).AddRecord
            Dim fields As String = _tableOrViewName + "Code," + _tableOrViewName + "Name," + _tableOrViewName + "NameAra"
            Dim values As String = "@Code,@Name,@NameAra"
            If WithNotes Then
                fields += ",Notes"
                values += ",@BranchIdNo"
            End If
            If LimitToBranch Then
                fields += ",BranchIdNo"
                values += ",@BranchIdNo"
            End If
            Dim sql As String =
                    " INSERT INTO " & _tableOrViewName &
                    " (" & fields & ")" &
                    " VALUES (" & values & ")"
            If LimitToBranch Then
                Return Db.Insert(sql, TakeBranch(Basic))
            Else
                Return Db.Insert(sql, Take(Basic))
            End If
        End Function

        Private ReadOnly Make As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Code = Extensions.AsString(reader(_table + "Code")),
            .Name = Extensions.AsString(reader(_table + "Name")),
            .NameAra = Extensions.AsString(reader(_table + "NameAra"))
            }

        Private ReadOnly MakeNotes As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Code = Extensions.AsString(reader(_table + "Code")),
            .Name = Extensions.AsString(reader(_table + "Name")),
            .NameAra = Extensions.AsString(reader(_table + "NameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private ReadOnly MakeBranch As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .Code = Extensions.AsString(reader(_table + "Code")),
            .Name = Extensions.AsString(reader(_table + "Name")),
            .NameAra = Extensions.AsString(reader(_table + "NameAra"))
            }

        Private ReadOnly MakeBranchNotes As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .Code = Extensions.AsString(reader(_table + "Code")),
            .Name = Extensions.AsString(reader(_table + "Name")),
            .NameAra = Extensions.AsString(reader(_table + "NameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Basic As Basic) As Object()
            If WithNotes Then
                Return New Object() {
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra,
                                    "@Notes", Basic.Notes
                                }
            Else
                Return New Object() {
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra
                                }
            End If
        End Function

        Private Function TakeBranch(Basic As Basic) As Object()
            If WithNotes Then
                Return New Object() {
                                    "@BranchIdNo", Basic.BranchIdNo,
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra,
                                    "@Notes", Basic.Notes
                                }
            Else
                Return New Object() {
                                    "@BranchIdNo", Basic.BranchIdNo,
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra
                                }

            End If
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode(_tableOrViewName, _tableOrViewName + "Code", "IdNo", idNo)
        End Function

    End Class

End Namespace