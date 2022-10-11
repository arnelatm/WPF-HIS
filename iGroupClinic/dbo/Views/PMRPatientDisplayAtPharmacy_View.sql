
CREATE VIEW [dbo].[PMRPatientDisplayAtPharmacy_View]
AS
SELECT        dbo.PMRPatientGeneralInfo.Trans_Key, dbo.PMRPatientGeneralInfo.TransNBR, dbo.PMRPatientGeneralInfo.TransDateEnglish, dbo.PMRPatientGeneralInfo.PatientType, dbo.PMRPatientGeneralInfo.RegistrationNo, 
                         dbo.PMRPatientGeneralInfo.DoctorID, dbo.PatientDetails.PatientNameEnglish, dbo.PatientDetails.PatientNameArabic, dbo.PatientDetails.Mobile, dbo.EmployeeDetails.EmpNameEnglish, dbo.EmployeeDetails.EmpNameArabic, 
                         dbo.EmployeeDetails.OPDNo, dbo.PMRMedicineDetails.Item_Code, dbo.PMRMedicineDetails.Qty, dbo.PMRMedicineDetails.Unit, dbo.ItemDetails.ItemNameEnglish, 'Covered' AS TransType
FROM            dbo.PMRPatientGeneralInfo INNER JOIN
                         dbo.PatientDetails ON dbo.PMRPatientGeneralInfo.RegistrationNo = dbo.PatientDetails.RegistrationNo AND dbo.PMRPatientGeneralInfo.PatientType = dbo.PatientDetails.PatientType INNER JOIN
                         dbo.EmployeeDetails ON dbo.PMRPatientGeneralInfo.DoctorID = dbo.EmployeeDetails.EmpID INNER JOIN
                         dbo.PMRMedicineGroup ON dbo.PMRPatientGeneralInfo.Trans_Key = dbo.PMRMedicineGroup.Trans_Key AND dbo.PMRPatientGeneralInfo.TransNBR = dbo.PMRMedicineGroup.TransNBR INNER JOIN
                         dbo.PMRMedicineDetails ON dbo.PMRMedicineGroup.Trans_Key = dbo.PMRMedicineDetails.Group_Key INNER JOIN
                         dbo.ItemDetails ON dbo.PMRMedicineDetails.Item_Code = dbo.ItemDetails.Item_Code
union
SELECT        dbo.PMRPatientGeneralInfo.Trans_Key, dbo.PMRPatientGeneralInfo.TransNBR, dbo.PMRPatientGeneralInfo.TransDateEnglish, dbo.PMRPatientGeneralInfo.PatientType, dbo.PMRPatientGeneralInfo.RegistrationNo, 
                         dbo.PMRPatientGeneralInfo.DoctorID, dbo.PatientDetails.PatientNameEnglish, dbo.PatientDetails.PatientNameArabic, dbo.PatientDetails.Mobile, dbo.EmployeeDetails.EmpNameEnglish, dbo.EmployeeDetails.EmpNameArabic, 
                         dbo.EmployeeDetails.OPDNo, dbo.PMRMedicineNotCoveredDetails.Item_Code, dbo.PMRMedicineNotCoveredDetails.Qty, dbo.PMRMedicineNotCoveredDetails.Unit, dbo.ItemDetails.ItemNameEnglish, 'NotCovered' AS TransType
FROM            dbo.PMRPatientGeneralInfo INNER JOIN
                         dbo.PatientDetails ON dbo.PMRPatientGeneralInfo.RegistrationNo = dbo.PatientDetails.RegistrationNo AND dbo.PMRPatientGeneralInfo.PatientType = dbo.PatientDetails.PatientType INNER JOIN
                         dbo.EmployeeDetails ON dbo.PMRPatientGeneralInfo.DoctorID = dbo.EmployeeDetails.EmpID INNER JOIN
                         dbo.PMRMedicineNotCoveredGroup ON dbo.PMRPatientGeneralInfo.Trans_Key = dbo.PMRMedicineNotCoveredGroup.Trans_Key AND dbo.PMRPatientGeneralInfo.TransNBR = dbo.PMRMedicineNotCoveredGroup.TransNBR INNER JOIN
                         dbo.PMRMedicineNotCoveredDetails ON dbo.PMRMedicineNotCoveredGroup.Trans_Key = dbo.PMRMedicineNotCoveredDetails.Group_Key INNER JOIN
                         dbo.ItemDetails ON dbo.PMRMedicineNotCoveredDetails.Item_Code = dbo.ItemDetails.Item_Code