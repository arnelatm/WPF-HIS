Public Function PostData(idNo As Integer) As Boolean Implements IDaoPosting.PostData
	Dim retVal As Boolean = True
	Dim commands As New List(Of DaoCommand)
	Dim invTransDetails As List(Of InvTransactionDetail)
	Dim itDao = New InvTransactionDetailDao
	invTransDetails = itDao.GetRecordsWithGroupIdNo(idNo)
	Dim InvTrans As InvTransaction = GetRecordByIdNo(idNo)
	Dim InventoryAction As String
	Dim sqls As New List(Of String)
	InventoryAction = GetField(Of String, Int16)(InvTrans.InvTransTypeIdNo, "InvTransType", "IdNo", "InventoryAction")
	If InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
		Dim connection As New Db
		Using transactionObj As New TransactionObject()
			transactionObj.CreateConnection("InvTransactionPosting", Db.GetConnectionString)
			For Each item As InvTransactionDetail In invTransDetails
				Dim sql As String
				sql = "Update Inventory set qtyonhand = qtyonhand - " &
					  "(select IIf(c.UnitQTy = 0,0,(cast(a.Quantity as Decimal(12,2)) * c.BaseQty / c.UnitQty)) " &
					  "From InvTransactionDetail a " &
					  "Left Join InvTransaction b " &
					  "On a.InvTransactionIdNo = b.IdNo " &
					  "Left Join ProductUnit_View c " &
					  "On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo " &
					  "where a.IdNo = @InvTransactionDetailIdNo) " &
					  "where idNo = @InventoryIdNo "
				transactionObj.Command.Parameters.Clear()
				If Db.ExecuteSqlInTransaction(transactionObj, sql, {"@InvTransactionDetailIdNo", item.IdNo, "@InventoryIdNo", item.InventoryIdNo}) <> 0 Then
					retVal = False
				End If
			Next
			Db.CloseTransaction(transactionObj)
		End Using
	End If
	Return retVal
End Function