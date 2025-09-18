Imports AATM.Contracts
Imports AATM.Core.Logging

Module LoggingTest
    Sub Main()
        ' The key here is that we are using the ILogger interface.
        ' We can easily switch the implementation here without changing
        ' any other code in the application.

        ' Option 1: Use the FileLogger
        Dim logger As ILogger = New FileLogger("log.txt")

        ' Option 2: Use the ConsoleLogger
        'Dim logger As ILogger = New ConsoleLogger()

        ' Log some messages using the selected logger implementation.
        logger.LogInfo("Application started.")
        logger.LogWarning("Potential issue found in data processing.")
        logger.LogError("Failed to connect to the database.")

        ' Demonstrate logging an exception
        Try
            Dim x As Integer = 0
            Dim y As Integer = 10 \ x ' This will cause a divide-by-zero exception
        Catch ex As Exception
            logger.LogException(ex)
        End Try

        Console.WriteLine("Logging complete. Press any key to exit.")
        Console.ReadKey()
    End Sub
End Module