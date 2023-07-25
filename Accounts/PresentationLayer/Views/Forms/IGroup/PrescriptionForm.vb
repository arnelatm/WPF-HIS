Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PrescriptionForm
        Implements IPrescriptionView

        Public Event PrintLabels() Implements IPrescriptionView.PrintLabels
        Public Event ItemCodeChanged(itemCode As String, bs As BindingSource) Implements IPrescriptionView.ItemCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements IPrescriptionView.GTinScanned

        Private _prescriptionDetails As New List(Of PrescriptionItemView)

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            dgvPrintLabel.AlwaysEditable = True
            DisallowSaves = True
        End Sub

        Public ReadOnly Property SeriesDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
            Get
                Return SeriesDataGridViewTextBoxColumn
            End Get
        End Property

        Public Property Series As String Implements IPrescriptionView.Series
            Get
                Return txtSeries.Text
                'Return cboSeries.GetValue()
            End Get
            Set(value As String)
                txtSeries.Text = value
                'cboSeries.SetValue(value)
            End Set
        End Property

        Public Property PatientName As String Implements IPrescriptionView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set(value As String)
                txtPatientName.Text = value
            End Set
        End Property

        Public Property Gender As String Implements IPrescriptionView.Gender
            Get
                Return txtGender.Text
                'Return cboGender.GetValue()
            End Get
            Set(value As String)
                txtGender.Text = value
                'cboGender.SetValue(value)
            End Set
        End Property

        Public Property Age As String Implements IPrescriptionView.Age
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property AgeYMD As String Implements IPrescriptionView.AgeYmd
            Get
                Return txtAgeYMD.Text
            End Get
            Set(value As String)
                txtAgeYMD.Text = value
            End Set
        End Property

        Public Property Dob As String Implements IPrescriptionView.Dob

        Public Property FileNo As Integer Implements IPrescriptionView.FileNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtFileNo.Text)
            End Get
            Set
                txtFileNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DoctorName As String Implements IPrescriptionView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set(value As String)
                txtDoctorName.Text = value
            End Set
        End Property

        Public Property TransKey As Integer Implements IPrescriptionView.TransKey
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtTransKey.Text)
            End Get
            Set(value As Integer)
                txtTransKey.Text = value
            End Set
        End Property

        Public Property PrescriptionDetails As List(Of PrescriptionItemView) Implements IPrescriptionView.PrescriptionDetails
            Get
                Return _prescriptionDetails
            End Get
            Set
                _prescriptionDetails = Value
                BindPrescriptionDetails()
            End Set
        End Property

        Public Property DoctorCode As String Implements IPrescriptionView.DoctorCode

        Public Property TransDate As String Implements IPrescriptionView.TransDate
            Get
                Return dtpTransDate.Value
            End Get
            Set(value As String)
                dtpTransDate.Value = value
            End Set
        End Property

        Private Sub BindPrescriptionDetails()
            SuspendLayout()
            bsPrescriptionDetails.DataSource = Nothing
            DataGridViewPrescriptionItems.Refresh()
            bsPrescriptionDetails.DataSource = PrescriptionDetails
            bsPrescriptionDetails.AllowNew = True
            With DataGridViewPrescriptionItems
                .AutoGenerateColumns = False
                .DataSource = bsPrescriptionDetails
            End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Age", txtAge},
                {"AgeYmd", txtAgeYMD},
                {"Dob", txtDob},
                {"DoctorCode", txtDoctorCode},
                {"DoctorName", txtDoctorName},
                {"FileNo", txtFileNo},
                {"Gender", txtGender},
                {"PatientName", txtPatientName},
                {"Series", txtSeries},
                {"TransDate", dtpTransDate},
                {"TransKey", txtTransKey}
                }
        End Sub

        Private Sub btnPrintDosageLabels_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintDosageLabels.ClickButtonArea
            RaiseEvent PrintLabels()
        End Sub

        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewPrescriptionItems.CellValidating
            If DataGridViewPrescriptionItems.IsCurrentCellDirty() Then
                With DataGridViewPrescriptionItems
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvItemCode" Then
                        ValidateItemCode(DataGridViewPrescriptionItems, e)
                    ElseIf cColumnName = $"dgvItemName" Then
                        ValidateItemName(DataGridViewPrescriptionItems, e)
                    End If
                End With
            End If
        End Sub

        Private Sub ValidateItemCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim code As String = dgv.CurrentRow.Cells("dgvItemCode").EditedFormattedValue
            RaiseEvent ItemCodeChanged(code, bsPrescriptionDetails)
            Dim cItemName = dgv.CurrentRow().Cells("dgvItemName").Value
            If Not String.IsNullOrEmpty(cItemName) Then
                SendKeys.Send("{Tab}")
            Else
                If Not String.IsNullOrEmpty(code) Then
                    e.Cancel = True
                    Messaging.ShowPmMessage(True, "MsgInvalidValue", {"fieldValue", code, "fieldDescription", "Item Code"})
                End If
            End If
        End Sub

        Private Sub ValidateItemName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim findText = dgv.CurrentRow.Cells("dgvItemName").EditedFormattedValue
            If findText.Contains("<GS>") Then
                Dim scannedProduct As Object = New ExpandoObject
                scannedProduct = Accounts.AccountHelpers.GetScannedData(findText)
                Dim productCode As String = ""
                RaiseEvent GTinScanned(scannedProduct.GTin, bsPrescriptionDetails, productCode)
                If productCode IsNot Nothing Then
                    RaiseEvent ItemCodeChanged(productCode, bsPrescriptionDetails)
                    bsPrescriptionDetails.ResetBindings(False)
                End If
            Else
                Dim form As New ItemDetailsFinder(findText, dgv)
                If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim item As ItemDetailsModel = form.ItemDetails
                    If item Is Nothing Then
                        Dim msg = Messaging.GetParametrizedMessage(True, "MsgInvalidValue", {"fieldValue", findText, "fieldDescription", "Medicine Name"})
                        Messaging.Show(msg)
                        e.Cancel = True
                        dgv.Rows(e.RowIndex).ErrorText = msg
                    Else
                        RaiseEvent ItemCodeChanged(item.ItemDetailsCode, bsPrescriptionDetails)
                        bsPrescriptionDetails.ResetBindings(False)
                        'bsPrescriptionDetails.Current.ItemDetailsCode = item.ItemDetailsCode
                        'bsPrescriptionDetails.Current.ItemDetailsCode = item.ItemDetailsCode

                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

    End Class

End Namespace