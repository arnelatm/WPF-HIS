








CREATE VIEW [dbo].[InvoiceClinicHeader_View]
  AS
With cte as (Select a.Group_key,
		sum(a.ItemGrossPrice) as 'InvGrossPrice'
		from InvoiceClinicItem_View a
		left join InvoiceClinicItem_View b
		on a.Group_key = b.Group_key and a.Seq = b.Seq
		group by a.Group_key)
Select	Inv.TransNbr,
		cte.Group_key,
		Inv.TransDateEnglish,
		Inv.InsuranceID as 'CustomerId',
		e.CostCentre as 'RevCostCenter',
		Cast(IIf(Inv.BillType = 'CA',1,0) as Bit) as 'Cash',
		cte.InvGrossPrice,
		inv.ExtraDiscountAmt-Inv.RoundOffAmt as 'InvExtraDiscount',
		inv.BillAmt,
		Cast(IIF(inv.VATExemption=0,0,1) as Bit) as 'CitizenSale',
		inv.Reject as 'Rejected'
		from ClinicInvoiceGroup Inv
		left join cte
		on cte.Group_key = inv.Trans_key 
		left join employeeDetails e
		on inv.DoctorId = e.EmpID