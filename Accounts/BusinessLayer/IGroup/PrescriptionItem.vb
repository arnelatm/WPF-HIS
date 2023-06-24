' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.BusinessLayer

Namespace BusinessLayer

    Public Class PrescriptionItem
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
        End Sub

        Property RowNbr As Int32
        Property ItemName As String
        Property Dosage As String
        Property Duration As String
        Property GenericName As String
        Property ItemCode As String
        Property LabelPrinted As Boolean
        Property PrescriptionItemIdNo As Int32
        Property PrintLabel As Boolean
        Property TransKey As Int32

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