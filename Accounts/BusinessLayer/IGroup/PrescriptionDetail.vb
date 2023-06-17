' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.BusinessLayer

Namespace BusinessLayer

    Public Class PrescriptionDetail
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
        End Sub

        Property RowNbr As Int16
        Property ItemNameEnglish As String
        Property DosageEnglish As String
        Property Duration As String
        Property Item_Code As String
        Property Trans_Key As Int32

        ',[Age]
        ',[AgeYMD]
        ',[DosageEnglish]
        ',[Duration]
        ',[Item_Code]
        ',[ItemNameEnglish]
        ',[PatientNameEnglish]
        ',[Qty]
        ',[RegistrationNo]
        ',[Series]
        ',[Sex]
        ',[Trans_Key]
        ',[TransDateEnglish]
        ',[Unit]

    End Class

End Namespace