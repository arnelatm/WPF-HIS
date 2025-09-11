Imports AATM.Libraries
Imports AATM.Libraries.Messaging  ' for Dac

Namespace Core
    Public Module TranslatorAccessor
        ' Global accessor (thread-safe read/write not strictly necessary if set once at startup).
        Private _translatorDacV As Dac

        Public Property TranslatorDACV As Dac
            Get
                Return _translatorDacV
            End Get
            Set(value As Dac)
                _translatorDacV = value
            End Set
        End Property

        ' Optional convenience initializer.
        Public Sub InitializeTranslator(dac As Dac)
            _translatorDacV = dac
        End Sub
    End Module
End Namespace