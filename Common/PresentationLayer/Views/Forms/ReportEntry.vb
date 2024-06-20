Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Common.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class ReportEntry
        Implements IReportView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IReportView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobIdNo As Int16 Implements IReportView.PrintJobIdNo
            Get
                Return cboPrintJobIdNo.GetValue(Of Int16)()
            End Get
            Set
                cboPrintJobIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ReportName As String Implements IReportView.ReportName
            Get
                Return txtReportName.Text
            End Get
            Set
                txtReportName.Text = Value
            End Set
        End Property

        Public Property ReportCode As String Implements IReportView.ReportCode
            Get
                Return txtReportCode.Text
            End Get
            Set
                txtReportCode.Text = Value
            End Set
        End Property

        Public Property QueryForm As String Implements IReportView.QueryForm
            Get
                Return txtQueryForm.Text
            End Get
            Set
                txtQueryForm.Text = Value
            End Set
        End Property

        Public Property QueryFormParameters As String Implements IReportView.QueryFormParameters
            Get
                Return txtQueryFormParameters.Text
            End Get
            Set
                txtQueryFormParameters.Text = Value
            End Set
        End Property

        Public Property QueryParameters As String Implements IReportView.QueryParameters
            Get
                Return txtQueryParameters.Text
            End Get
            Set
                txtQueryParameters.Text = Value
            End Set
        End Property

        Public Property ReportFileName As String Implements IReportView.ReportFileName
            Get
                Return txtReportFileName.Text
            End Get
            Set
                txtReportFileName.Text = Value
            End Set
        End Property

        Public Property ReportGroupIdNo As Int16 Implements IReportView.ReportGroupIdNo
            Get
                Return cboReportGroupIdNo.GetValue(Of Int32)
            End Get
            Set(value As Int16)
                cboReportGroupIdNo.SetValue(value)
            End Set
        End Property

        Public Property ReportNameAra As String Implements IReportView.ReportNameAra
            Get
                Return txtReportNameAra.Text
            End Get
            Set
                txtReportNameAra.Text = Value
            End Set
        End Property

        Public Property ReportTitle As String Implements IReportView.ReportTitle
            Get
                Return txtReportTitle.Text
            End Get
            Set
                txtReportTitle.Text = Value
            End Set
        End Property

        Public Property ReportTitleAra As String Implements IReportView.ReportTitleAra
            Get
                Return txtReportTitleAra.Text
            End Get
            Set
                txtReportTitleAra.Text = Value
            End Set
        End Property

        Public Property Active As Boolean Implements IReportView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property BranchIdNo As Short Implements IReportView.BranchIdNo
            Get
                Return txtBranchIdNo.Text
            End Get
            Set
                txtBranchIdNo.Text = Value
            End Set
        End Property

        Public Property DateCreated As Date Implements IReportView.DateCreated
            Get
                Return txtDateCreated.Text
            End Get
            Set
                txtDateCreated.Text = Value
            End Set
        End Property

        Private _databaseName As String

        Public Property DatabaseName As String Implements IReportView.DatabaseName
            Get
                Return txtDataBaseName.Text
            End Get
            Set(value As String)
                If value Is Nothing OrElse value = "" Then
                    txtDataBaseName.Text = $"ISPDATA"
                Else
                    txtDataBaseName.Text = value
                End If
            End Set
        End Property

        Public Property ReportOrder As Short Implements IReportView.ReportOrder
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtReportOrder.Text)
            End Get
            Set
                txtReportOrder.Text = Convert.ToString(Value)
            End Set
        End Property


#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Active", chkActive},
                {"BranchIdNo", txtBranchIdNo},
                {"DataBaseName", txtDataBaseName},
                {"DateCreated", txtDateCreated},
                {"ReportGroupIdNo", cboReportGroupIdNo},
                {"IdNo", txtIdNo},
                {"PrintJobIdNo", cboPrintJobIdNo},
                {"QueryForm", txtQueryForm},
                {"QueryFormParameters", txtQueryFormParameters},
                {"ReportCode", txtReportCode},
                {"ReportFileName", txtReportFileName},
                {"ReportName", txtReportName},
                {"ReportOrder", txtReportName},
                {"ReportNameAra", txtReportNameAra},
                {"ReportTitle", txtReportTitle},
                {"ReportTitleAra", txtReportTitleAra}
                }
        End Sub

    End Class

End Namespace