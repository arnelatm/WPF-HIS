' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CbcRetrieval
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("CbcRetrievalName"))
                AddRule(New ValidateIfRequired("GenericName", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("DosageForm", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("PackageType", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("PackageSize", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("RouteOfAdministration", "PrescriptionDrug", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                'AddRule(New ValidateRequired("CbcRetrievalCode"))
            End If

        End Sub

        Property InvoiceNo As String
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property Age As Int16
        Property AgeYMD As String
        Property Sex As String
        Property WbcR As String
        Property NeR As String
        Property LyR As String
        Property MoR As String
        Property EoR As String
        Property BaR As String
        Property RbcR As String
        Property HgbR As String
        Property HctR As String
        Property McvR As String
        Property MchR As String
        Property MchcR As String
        Property RdwcvR As String
        Property RdwcdR As String
        Property PltR As String
        Property PctR As String
        Property MpvR As String
        Property PdwR As String


    End Class

    Public Class Lab_InvoiceGroup
        Property InvoiceNo As String
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property Age As Int16
        Property AgeYMD As String
        Property Sex As String
    End Class

    Public Class Lab_InvoiceDetails
        Property Group_Key As Decimal
        Property SlNo As Decimal
        Property InvestigationID As String
        Property Diagnosis1 As String
        Property Result1 As String
        Property Suffix1 As String
    End Class
End Namespace