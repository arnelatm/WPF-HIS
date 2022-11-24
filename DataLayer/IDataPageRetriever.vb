Public Interface IDataPageRetriever

    Function SupplyPageOfData(ByVal lowerPageBoundary As Integer, ByVal rowsPerPage As Integer) As DataTable

End Interface