Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfLeave
        Implements IHrReportsView

        Public Event PrintButtonClicked() Implements IHrReportsView.PrintButtonClicked
        Public Event FormLoaded() Implements IHrReportsView.FormLoaded
        Protected SortOrderKey As String

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Employee"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)
            EmployeeSelectorControl = cboEmployeeIdNo
        End Sub

        Public Property MainTableName As String

        Public Property EmployeeSelectorControl As Control Implements IHrReportsView.EmployeeSelectorControl


        Public ReadOnly Property BeginningDate As Date? Implements IHrReportsView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
        End Property

        Public ReadOnly Property EndingDate As Date? Implements IHrReportsView.EndingDate
            Get
                Return dtpBeginningDate.Value
            End Get
        End Property

        Public ReadOnly Property Language As String Implements IHrReportsView.Language
            Get
                Dim curCulture = CultureInfo.CurrentCulture
                Return Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            End Get
        End Property

        Public Property EmployeeIdNo As Integer Implements IHrReportsView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboEmployeeIdNo.SetValue(value)
            End Set
        End Property

        Public Property UserHasHrAccess As Boolean Implements IHrReportsView.UserHasHrAccess

        Public ReadOnly Property ReportName As String Implements IHrReportsView.ReportName
            Get
                Return "Statement of Employee Leaves"
            End Get
        End Property

        Public ReadOnly Property ReportFileName As String Implements IHrReportsView.ReportFileName
            Get
                Return "Statement of Employee Leaves.Rpt"
            End Get
        End Property



        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                RaiseEvent PrintButtonClicked()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub StatementOfLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboEmployeeIdNo.EditingMode = False
            Ea.PublishEvent(New GetControlDataSource("Employee", cboEmployeeIdNo))
            RaiseEvent FormLoaded()
            cboEmployeeIdNo.EditingMode = True
        End Sub



    End Class

End Namespace