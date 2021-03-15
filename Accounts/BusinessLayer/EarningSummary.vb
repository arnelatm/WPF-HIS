' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports System.ComponentModel
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EarningSummary
        Inherits AATM.BusinessLayer.BusinessObject
        'Implements IDataErrorInfo

        'Private _multiplier As Decimal

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateContent("FactorValue", 0, ValidationOperator.NotEqual, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property EarningSummaryIdNo As Int16
        Public Property EarningIdNo As Int16
        Public Property IdNo As Int16
        Public Property FactorValue As Decimal
        '    Get
        '        Return _multiplier
        '    End Get
        '    Set(value As Decimal)
        '        If value = 0 Then
        '            MessageBox.Show("Value cannot be zero")
        '        End If
        '    End Set
        'End Property

        Public Property FactorType As Char

        Public Property Sequence As Int16

        'Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        '    Get
        '        Throw New NotImplementedException()
        '    End Get
        'End Property

        'Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        '    Get
        '        Throw New NotImplementedException()
        '    End Get
        'End Property
    End Class

End Namespace