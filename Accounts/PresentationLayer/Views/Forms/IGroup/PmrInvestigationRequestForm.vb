Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.PresentationLayer.Views.Interfaces.IGroup
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.IGroup

    Public Class PmrInvestigationRequestForm
        Implements IPmrInvestigationView

        Private _nfi As NumberFormatInfo

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = dtpTransactionDate

        End Sub

        Public Property RegistrationNo As Integer Implements IPmrInvestigationView.RegistrationNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Series As String Implements IPmrInvestigationView.Series
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PatientName As String Implements IPmrInvestigationView.PatientName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Gender As String Implements IPmrInvestigationView.Gender
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"TransactionDate", dtpTransactonDate},
                {"GenericName", txtGenericName},
                {"IdNo", TxtIdNo},
                {"ItemDetailsCode", TxtItemDetailsCode},
                {"ItemDetailsName", TxtItemDetailsName},
                {"PackageSize", txtPackageSize},
                {"PackageType", cboPackageType},
                {"PrescriptionDrug", chkPrescriptionDrug},
                {"RegistrationNo", txtRegistrationNo},
                {"RouteOfAdministration", cboRouteOfAdministration},
                {"StrengthValue", txtStrengthValue},
                {"UnitOfStrength", cboUnitOfStrength},
                {"UnitOfVolume", cboUnitOfVolume},
                {"Volume", txtVolume}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            If Strings.Left(RegistrationNo, 1) <> "X" Then
                SetDisplayOnly(True)
            Else
                SetDisplayOnly(False)
            End If
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            cboDosageForm.DisplayOnly = value
            txtGenericName.DisplayOnly = value
            txtPackageSize.DisplayOnly = value
            cboPackageType.DisplayOnly = value
            txtRegistrationNo.DisplayOnly = value
            cboRouteOfAdministration.DisplayOnly = value
            txtStrengthValue.DisplayOnly = value
            cboUnitOfStrength.DisplayOnly = value
            cboUnitOfVolume.DisplayOnly = value
            txtVolume.DisplayOnly = value
        End Sub


    End Class

End Namespace