Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class BackgroundWorkerForm

#Region "Fields"

    Private ReadOnly _onDoWork As DoWorkEventHandler
    Private ReadOnly _onProgressChanged As ProgressChangedEventHandler
    Private ReadOnly _onRunWorkerCompleted As RunWorkerCompletedEventHandler

#End Region 'Fields

#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm"/> class.
    ''' </summary>
    ''' <remarks>
    ''' Parameter less constructor is private to ensure handlers are provided for <see cref="BackgroundWorker"/>.
    ''' </remarks>
    Private Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler)
        Me.New()

        _onDoWork = onDoWork

        'AddHandler is used for local event handlers so that remote event handlers can be registered first and thus executed first.

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork

        'Local event handlers
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onProgressChanged">
    ''' Handler for the <see cref="BackgroundWorker.ProgressChanged">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onProgressChanged As ProgressChangedEventHandler)
        Me.New()

        _onDoWork = onDoWork
        _onProgressChanged = onProgressChanged

        'AddHandler is used for local event handlers so that remote event handlers can be registered first and thus executed first.

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.ProgressChanged, onProgressChanged

        'Local event handlers
        AddHandler BackgroundWorker1.ProgressChanged, AddressOf BackgroundWorker1_ProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted

        'A ProgressChanged handler has been provided so the ProgressBar will be updated explicitly based on the BackgroundWorker.
        BackgroundWorker1.WorkerReportsProgress = True
        ProgressBar1.Style = ProgressBarStyle.Continuous
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onRunWorkerCompleted">
    ''' Handler for the <see cref="BackgroundWorker.RunWorkerCompleted">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onRunWorkerCompleted As RunWorkerCompletedEventHandler)
        Me.New()

        _onDoWork = onDoWork
        _onRunWorkerCompleted = onRunWorkerCompleted

        'AddHandler is used for local event handlers so that remote event handlers can be registered first and thus executed first.

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.RunWorkerCompleted, onRunWorkerCompleted

        'Local event handlers
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

    ''' <summary>
    ''' Creates a new instance of the <see cref="BackgroundWorkerForm" /> class.
    ''' </summary>
    ''' <param name="onDoWork">
    ''' Handler for the <see cref="BackgroundWorker.DoWork">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onProgressChanged">
    ''' Handler for the <see cref="BackgroundWorker.ProgressChanged">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    ''' <param name="onRunWorkerCompleted">
    ''' Handler for the <see cref="BackgroundWorker.RunWorkerCompleted">RunWorkerCompleted</see> event of a <see cref="BackgroundWorker"/>.
    ''' </param>
    Public Sub New(onDoWork As DoWorkEventHandler,
                   onProgressChanged As ProgressChangedEventHandler,
                   onRunWorkerCompleted As RunWorkerCompletedEventHandler)
        Me.New()

        _onDoWork = onDoWork
        _onProgressChanged = onProgressChanged
        _onRunWorkerCompleted = onRunWorkerCompleted

        'AddHandler is used for local event handlers so that remote event handlers can be registered first and thus executed first.

        'Remote event handlers
        AddHandler BackgroundWorker1.DoWork, onDoWork
        AddHandler BackgroundWorker1.ProgressChanged, onProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, onRunWorkerCompleted

        'Local event handlers
        AddHandler BackgroundWorker1.ProgressChanged, AddressOf BackgroundWorker1_ProgressChanged
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted

        'A ProgressChanged handler has been provided so the ProgressBar will be updated explicitly based on the BackgroundWorker.
        BackgroundWorker1.WorkerReportsProgress = True
        ProgressBar1.Style = ProgressBarStyle.Continuous
    End Sub

#End Region 'Constructors

#Region "Properties"

    Public WriteOnly Property SupportsCancellation As Boolean
        Set
            BackgroundWorker1.WorkerSupportsCancellation = Value

            'If the worker can be cancelled, show the Cancel button and make the form big enough to see it.
            cancelWorkButton.Visible = Value
            ClientSize = New Size(284,
                                  If(Value, 76, 47))
        End Set
    End Property

#End Region 'Properties

#Region "Methods"

    Private Sub BackgroundWorkerForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Start the background work when the form is displayed.
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub cancelWorkButton_Click(sender As Object, e As EventArgs) Handles cancelWorkButton.Click
        'Disable the button to prevent another click.
        cancelWorkButton.Enabled = False

        'Cancel the background work.
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        'Update the ProgressBar.
        ProgressBar1.Value = e.ProgressPercentage
        lblPercent.Text = e.ProgressPercentage.ToString()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'Close the form when the work is done.
        Close()
    End Sub

    Private Sub BackgroundWorkerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Remote event handlers.

        If _onDoWork IsNot Nothing Then
            RemoveHandler BackgroundWorker1.DoWork, _onDoWork
        End If

        If _onProgressChanged IsNot Nothing Then
            RemoveHandler BackgroundWorker1.ProgressChanged, _onProgressChanged
        End If

        If _onRunWorkerCompleted IsNot Nothing Then
            RemoveHandler BackgroundWorker1.RunWorkerCompleted, _onRunWorkerCompleted
        End If

        'Local event handlers
        RemoveHandler BackgroundWorker1.ProgressChanged, AddressOf BackgroundWorker1_ProgressChanged
        RemoveHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

#End Region 'Methods

End Class