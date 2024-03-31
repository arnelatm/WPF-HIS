Imports System.Windows.Forms.VisualStyles
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class HolidayAvailmentPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IHolidayAvailmentView, TM)
        'Implements ISubscriber(Of EntryFormLoaded)

        Private _userHasAccess As Boolean = False
        Private _userIsASupervisor As Boolean = False

        Public Sub New(itemView As IHolidayAvailmentView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeave")
            TableBaseName = "EmployeeLeave"
            TableName = "EmployeeLeave_View"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EmployeeIdNo = Service.GetField(Of Int32, Int32)(GlobalVariables.UserIdNo, "User", "IdNo", "EmployeeIdNo")
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub

        Public Overrides Sub EntryFormLoaded()
            If UserHasAccess("HumanResources") Then
                _userHasAccess = True
            Else
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                If Not UserIsASupervisor() Then
                    _userIsASupervisor = False
                    Dim control As Control = Nothing
                    Dim x = MainFieldsDictionary
                    If MainFieldsDictionary.TryGetValue("EmployeeIdNo", control) Then
                        CallByName(control, "DisplayOnly", CallType.Set, True)
                    End If
                    DataFilter = "EmployeeIdNo = " & employeeIdNo.ToString()
                Else
                    DataFilter = "SupervisorIdNo = " & employeeIdNo.ToString() + " or EmployeeIdNo = " & employeeIdNo.ToString()
                End If
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            If UserHasAccess("HumanResources") Then
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
            ElseIf UserIsASupervisor() Then
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                Dim filter As String = "IdNo = " + employeeIdNo.ToString() + " or SupervisorIdNo = " + employeeIdNo.ToString()
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, filter}})
            Else
                Dim employeeIdNo As Int32 = Service.GetUserEmployeeIdNo()
                MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, "IdNo = " + employeeIdNo.ToString()}})
            End If
            MakeControlDataSources({New Object() {"User", "EnteredBy", "IdNo,UserName", Nothing},
                                    New Object() {"Holiday", "HolidayTransferIdNo", Nothing, Nothing}})
            CreateEnumDataSource(Of LeaveStatusSelection)("Status")
            CreateEnumData(Of LeaveStatusSelection)(View.HolidayStatusList)
            MakeVarDataSources({New Object() {"User", "Users", "IdNo,UserName", Nothing}})
            'CreateEnumDataSource(Of LeaveApprovalSelection)("Approval")
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If View.Status <> EnumToCode(LeaveStatusSelection.Submitted) Then
                Messaging.Show(True, "MsgHolidayAvailmentAlreadyActed", {"approvalAction", CodeToEnum(Of LeaveStatusSelection)(View.Status).ToString()})
                CancelEdit = True
            End If
        End Sub

    End Class

End Namespace