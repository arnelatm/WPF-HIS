Imports System.Windows.Forms

Friend Class SubFormLauncher
    Private ReadOnly _host As Form
    Private Shared ReadOnly _presenterPiLock As New Object()
    Private Shared ReadOnly _presenterPiCache As New Dictionary(Of Type, Reflection.PropertyInfo)()

    Public Sub New(host As Form)
        _host = host
    End Sub

    Private Sub AttachPresenter(Of TPresenter)(view As Form, ParamArray ctorArgs() As Object)
        Dim pType = GetType(TPresenter)
        Dim presenter = Activator.CreateInstance(pType, ctorArgs)
        Dim vt = view.GetType()
        Dim pi As Reflection.PropertyInfo
        SyncLock _presenterPiLock
            If Not _presenterPiCache.TryGetValue(vt, pi) Then
                pi = vt.GetProperty("Presenter")
                _presenterPiCache(vt) = pi
            End If
        End SyncLock
        pi?.SetValue(view, presenter, Nothing)
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter)()
        Dim child = DirectCast(Activator.CreateInstance(GetType(TView)), TView)
        AttachPresenter(Of TPresenter)(child, child)
        child.MdiParent = _host
        child.Show()
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(data As Object, mdiParent As Form)
        Dim child = DirectCast(Activator.CreateInstance(GetType(TView), data), TView)
        AttachPresenter(Of TPresenter)(child, child)
        child.MdiParent = mdiParent
        child.Show()
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(mdiParent As Form)
        Dim child = DirectCast(Activator.CreateInstance(GetType(TView)), TView)
        AttachPresenter(Of TPresenter)(child, child)
        child.MdiParent = mdiParent
        child.Show()
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter, TArg)(ByRef mdiParent As Form, param As TArg)
        Dim child = DirectCast(Activator.CreateInstance(GetType(TView), New Object() {param}), TView)
        AttachPresenter(Of TPresenter)(child, child, param)
        child.MdiParent = mdiParent
        child.Show()
    End Sub
End Class