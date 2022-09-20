Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ItemDetailsModel
        'Implements IModelNew

        Public Property BranchID As String
        Public Property DosageForm As String
        Public Property GenericName As String
        Public Property GTin As String
        Public Property IdNo As Int32
        Public Property ItemDetailsCode As String
        Public Property ItemDetailsName As String
        Public Property ItemGroup As String
        Public Property Pack1 As Int16
        Public Property Pack2 As Int16
        Public Property Pack3 As Int16
        Public Property PackageSize As Double?
        Public Property PackageType As String
        Public Property Price_Cash As Decimal?
        Public Property RegistrationNo As String
        Public Property SaleStrip As String
        Public Property StrengthValue As String
        Public Property UnitOfStrength As String
        Public Property UnitOfVolume As String
        Public Property UserId As String
        Public Property Volume As Double?
        Public Property PrescriptionDrug As Boolean
        Public Property RouteOfAdministration As String
        Public Property QtyOnHand As Decimal?
    End Class

End Namespace