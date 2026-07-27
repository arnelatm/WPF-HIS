













 CREATE View [dbo].[AgentsAndDriverTests2_View]
 as 
 sELECT d.[Id] as dId
      ,[NumberingSettingId] as dNumberingSettingId
      ,d.[SourceId] as ASourceId
      ,d.[Prefix] 
      ,d.[PrefixDate] 
      ,d.[FullNumberLength]
      ,[BatchNumber]
      ,[Number]
      ,[FullNumber]
	  ,a.[Id] as aID
      ,a.[CreatedDateTime]
      ,a.[CreatedUserId]
      ,[LastEditedDateTime]
      ,[LastEditedUserId]
      ,a.[Type] as aType
      ,a.ReferenceID as FileNumber
      ,[Values]
      ,[Status]
      ,[DoctorId]
	  ,b.[ID] as bId
	  ,CAST(b.Date aS Date) as Date
      ,b.[CustID]
      ,b.[CustName]
      ,b.[Type]
      ,b.[Total]
      ,[Mdfo3]
      ,[Bake]
      ,[Comment]
      ,b.[Time]
      ,b.[UserName]
      ,[UserID]
      ,[GeneralCust]
      ,[Store]
      ,[Box]
      ,[DrName]
      ,[DrID]
      ,[SourceType]
      ,b.[SourceID]
      ,[MailPayDate]
      ,[MailPayData]
      ,[MailPayNote]
      ,[AssignedTo]
      ,b.[OrderID]
      ,[IsSchedule]
      ,[scheduleValue]
      ,[MeritDate]
      ,b.[IsInsurance]
      ,[InsuranceCompany]
      ,[InsurancePolicy]
      ,b.[InsuranceClass]
      ,[InsuranceMemberNo]
      ,[InsuranceApprovalNo]
      ,[InsuranceLimitCustDay]
      ,[InsuranceUpToPer]
      ,[InsuranceUpToMoney]
      ,[InsuranceSeparateMedicineService]
      ,[CustIdentity]
      ,b.[CustNat]
      ,[Clinic]
      ,[Glass]
      ,[SpecialtieID]
      ,[LimitCustVisit]
      ,[IsFavorite]
      ,[FavoriteNote]
      ,b.[IsESignature]
      ,[EligrefNo]
      ,[IsReturn]
      ,b.[ParentId]
      ,b.[InvoiceSourceID]
      ,[PaymentMethodId]
      ,[CouponCode]
      ,b.[GeneralDiscount]
      ,b.[CouponDiscount]
      ,b.[PointsDiscount]
      ,[ENumber]
      ,[EId]
      ,[RequestedLabUserName]
      ,[RequestedLabDateTime]
      ,[RequestedERUserName]
      ,[RequestedERDateTime]
      ,[RequestedXRayUserName]
      ,[RequestedXRayDateTime]
	  ,c.[ID] as cId
      ,c.[OrderID] as cOrderId
      ,[Category]
      ,[Name]
      ,[Price]
      ,[Count]
      ,c.[Total] as cTotal
      ,[Disc]
      ,[DiscType]
      ,[DiscNet]
      ,[Net]
      ,[Note]
      ,c.[UserName] as cUserName
      ,c.[Date] as cDate
      ,c.[Time] as cTime
      ,[Unit]
      ,[WorkID]
      ,[QuotationWorkID]
      ,[MaxPrice]
      ,[MinPrice]
      ,[IsService]
      ,[PrushID]
      ,[Cost]
      ,[TotalCost]
      ,[SourceBarCode]
      ,[InsuranceTahamal]
      ,[PatientTahamalPer]
      ,c.[IsInsurance] as cIsInsurance
      ,[InuranceCode]
      ,[InuranceName]
      ,[InsuranceTahamalStatic]
      ,[InsuranceTahamalChangedCause]
      ,[InternalNotes]
      ,[VATPer]
      ,[VatValue]
      ,[TotalNoVAT]
      ,[VatExemption]
      ,[InsuranceTahamalVATPer]
      ,[InsuranceTahamalVATValue]
      ,[InsuranceTahamalAfterVAT]
      ,[ICD10]
      ,[DrugDose]
      ,[DrugInfo]
      ,[DrugScientificName]
      ,c.[Type] as cType
      ,[OfferID]
      ,[InsuranceApprovalType]
      ,[InsuranceApprovalID]
      ,[ExpiredDate]
      ,[MedDose]
      ,[MedDuration]
      ,[MedUnit]
      ,[MedFrequency]
      ,[Teeth]
      ,[GTIN]
      ,[SN]
      ,[BN]
      ,[Rsd_NotificationID]
      ,[Rsd_RC]
      ,[ItemLimitID]
      ,[ItemLimitAmount]
      ,[CCHICode]
      ,[CCHIName]
      ,c.[InvoiceSourceID] as cInvoiceSourceID
      ,[PurchaseAVG]
      ,c.[GeneralDiscount] as cGeneralDiscount
      ,c.[CouponDiscount] as cCouponDiscount
      ,c.[PointsDiscount] as cPointsDiscount
      ,[TotalDiscount]
      ,c.[ParentId] as cParentId
      ,[StoreExpensePause]
      ,[StoreExpenseUserID]
      ,[StoreExpenseUserName]
      ,[StoreExpenseDateTime]
      ,[InsuranceApprovedAmountWithVat]
      ,[ToothSurface]
      ,[ScientificCode]
      ,[IsSessionWork]
      ,[DrugSelectionReason]
      ,[Priority]
 FROM  kizenClinic.dbo.JC_TOL_NumberingLog d
 left join kizenClinic.dbo.JC_ED_Document a
 on d.SourceId = a.Id
 left JOIN kizenClinic.dbo.A1_OrderWorks c
 left JOIN kizenClinic.dbo.A1_Invoces b
 on b.Id = c.OrderId
 ON a.ReferenceID = b.CustID
 left JOIN kizenClinic.dbo.Customers e
 ON a.ReferenceId = e.CustId
 left Join kizenClinic.dbo.RefundedItem_View f
 on b.Id = f.ParentId
 left join kizenClinic.dbo.Customers g
 on b.CustID = g.CustId
 WHERE  b.IsReturn=0 and IsNull(d.FullNumber,'') <> '' and f.ParentId Is Null and
     ( (c.WorkID = N'T1' AND d.NumberingSettingId=2 AND a.Type=2) or (c.WorkID = N'T4' AND d.NumberingSettingId=1 AND a.Type=14))