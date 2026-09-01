Imports System.Windows.Forms
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms

    ''' <summary>
    ''' Common base for medical-fitness master forms. It keeps the standard
    ''' language buttons from CFormBase while leaving CRUD actions to the
    ''' purpose-built maintenance form.
    ''' </summary>
    Public MustInherit Class MedicalFitnessMaintenanceFormBase
        Inherits CFormBase

        Private ReadOnly _maintenanceContent As Panel
        Private _positioningMaintenanceContent As Boolean

        Protected Overrides ReadOnly Property LanguageLayoutMode As LanguageLayoutPolicy
            Get
                Return LanguageLayoutPolicy.AlwaysFull
            End Get
        End Property

        Protected Sub New()
            MyBase.New()
            ConfigureLanguageOnlyToolbar()

            ' CFormBase already owns the toolbar and title banner. Keep the
            ' maintenance screen content in a separate fill panel so those
            ' inherited controls cannot overlap code-created controls.
            _maintenanceContent = New Panel With {
                .Dock = DockStyle.None,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right,
                .Name = "MedicalFitnessMaintenanceContent",
                .Padding = New Padding(8)}
            Controls.Add(_maintenanceContent)
            PositionMaintenanceContent()
        End Sub

        Protected ReadOnly Property MaintenanceContent As Panel
            Get
                Return _maintenanceContent
            End Get
        End Property

        Protected Function CreateMaintenanceLayout(actionPanel As Control,
                                                    contentControl As Control) As TableLayoutPanel
            Dim layout = New TableLayoutPanel With {
                .ColumnCount = 1,
                .Dock = DockStyle.Fill,
                .Margin = New Padding(0),
                .RowCount = 2}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 42.0!))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            layout.Controls.Add(actionPanel, 0, 0)
            layout.Controls.Add(contentControl, 0, 1)
            Return layout
        End Function

        Protected Overrides Function ShouldManageLanguageSwitchRendering(context As LanguageSwitchContext) As Boolean
            ' These dialogs are small code-created forms. Avoid the base
            ' opacity/visibility transition because changing RightToLeftLayout
            ' can otherwise leave the modal dialog visually hidden.
            Return False
        End Function

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            MyBase.OnLayout(levent)
            PositionMaintenanceContent()
        End Sub

        Private Sub PositionMaintenanceContent()
            If _maintenanceContent Is Nothing OrElse _positioningMaintenanceContent OrElse IsDisposed Then
                Return
            End If

            _positioningMaintenanceContent = True
            Try
                Dim topOffset = If(FormToolStrip Is Nothing, 0, FormToolStrip.Bottom)
                Dim titleBanner = Controls("lblFormDescription")
                If titleBanner IsNot Nothing Then
                    topOffset = Math.Max(topOffset, titleBanner.Bottom)
                End If

                Dim contentBounds = New Rectangle(
                    0,
                    topOffset,
                    ClientSize.Width,
                    Math.Max(0, ClientSize.Height - topOffset))
                If _maintenanceContent.Bounds <> contentBounds Then
                    _maintenanceContent.Bounds = contentBounds
                End If
            Finally
                _positioningMaintenanceContent = False
            End Try
        End Sub

        Protected Overrides Sub OnLoad(e As EventArgs)
            ' The maintenance forms create their controls in code. Give unnamed
            ' controls stable names before CFormBase stores their captions so
            ' the existing translation service can translate them.
            AssignMissingControlNames(Me, 0)
            MyBase.OnLoad(e)
        End Sub

        Private Sub ConfigureLanguageOnlyToolbar()
            For Each item As ToolStripItem In FormToolStrip.Items
                item.Visible = (item Is btnArabic OrElse item Is btnOriginal)
            Next
        End Sub

        Private Shared Sub AssignMissingControlNames(parent As Control, ByRef sequence As Int32)
            For Each child As Control In parent.Controls
                If String.IsNullOrWhiteSpace(child.Name) Then
                    sequence += 1
                    child.Name = "MedicalFitness" & child.GetType().Name & sequence.ToString()
                End If
                If child.HasChildren Then
                    AssignMissingControlNames(child, sequence)
                End If
            Next
        End Sub

    End Class

End Namespace
