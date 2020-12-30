' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryCommon
        Inherits IDaoFactory

    End Interface

End Namespace