
update ItemDetailsNew set NewItemNameEnglish = itemNameEnglish + IIf([strength value] is null,'',' ' + [Strength Value]) 
+ IIf([Unit Of Strength] is null,'',' ' + [Unit Of Strength])
+ IIf([Dosage Form] is null,'',' ' + [Dosage Form])
+ IIf([Volume] is null,'',' ' + Convert(VarChar,[Volume])) 
+ IIf([Unit of Volume] is null,'',' ' + [Unit of Volume])
+ IIf([Package Type] is null,'',' ' + [Package Type]) 
+ IIf([Package Size] is null,'',IIf([Package Size]=1,'',' ' + Convert(VarChar,[Package Size])))
where Not (itemnameenglish like '% %')


