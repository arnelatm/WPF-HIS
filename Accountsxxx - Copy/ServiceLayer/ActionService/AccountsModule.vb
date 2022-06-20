Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer.ActionService

    Public Module AccountsModule

        Private ReadOnly MonthType = EnumToCode(PayRateUnitSelection.Month)
        Private ReadOnly SemiMonthType = EnumToCode(PayRateUnitSelection.SemiMonth)
        Private ReadOnly YearType = EnumToCode(PayRateUnitSelection.Year)
        Private ReadOnly SemiYearType = EnumToCode(PayRateUnitSelection.SemiYear)
        Private ReadOnly QuarterType = EnumToCode(PayRateUnitSelection.Quarter)
        Private ReadOnly WeekType = EnumToCode(PayRateUnitSelection.Week)
        Private ReadOnly DayType = EnumToCode(PayRateUnitSelection.Day)
        Private ReadOnly BiWeekType = EnumToCode(PayRateUnitSelection.BiWeek)

        Public Function ComputePayAmount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
            Dim factor As Decimal
            Select Case payFrequency
                Case PayFrequencySelection.Monthly
                    If unit = MonthType Then
                        factor = 1D
                    ElseIf unit = SemiMonthType Then
                        factor = 2D
                    ElseIf unit = YearType Then
                        factor = 1D / 12D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 6D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 3D
                    ElseIf unit = WeekType Then
                        factor = 13D / 2D
                    ElseIf unit = DayType Then
                        factor = 30D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 6D
                    End If
                Case PayFrequencySelection.Yearly
                    If unit = MonthType Then
                        factor = 12D
                    ElseIf unit = SemiMonthType Then
                        factor = 24D
                    ElseIf unit = YearType Then
                        factor = 1D
                    ElseIf unit = SemiYearType Then
                        factor = 2D
                    ElseIf unit = QuarterType Then
                        factor = 4D
                    ElseIf unit = WeekType Then
                        factor = 52D
                    ElseIf unit = DayType Then
                        factor = 365D
                    ElseIf unit = BiWeekType Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If unit = MonthType Then
                        factor = 6D
                    ElseIf unit = SemiMonthType Then
                        factor = 12D
                    ElseIf unit = YearType Then
                        factor = 1D / 2D
                    ElseIf unit = SemiYearType Then
                        factor = 1D
                    ElseIf unit = QuarterType Then
                        factor = 2D
                    ElseIf unit = WeekType Then
                        factor = 26D
                    ElseIf unit = DayType Then
                        factor = 365D / 2D
                    ElseIf unit = BiWeekType Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If unit = MonthType Then
                        factor = 3D
                    ElseIf unit = SemiMonthType Then
                        factor = 6D
                    ElseIf unit = YearType Then
                        factor = 1D / 4D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 2D
                    ElseIf unit = QuarterType Then
                        factor = 1D
                    ElseIf unit = WeekType Then
                        factor = 13D
                    ElseIf unit = DayType Then
                        factor = 365D / 4D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If unit = MonthType Then
                        factor = 1D / 2D
                    ElseIf unit = SemiMonthType Then
                        factor = 1D
                    ElseIf unit = YearType Then
                        factor = 1D / 24D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 12D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 6D
                    ElseIf unit = WeekType Then
                        factor = 13D / 4D
                    ElseIf unit = DayType Then
                        factor = 15D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If unit = MonthType Then
                        factor = 12D / 52D
                    ElseIf unit = SemiMonthType Then
                        factor = 24D / 52D
                    ElseIf unit = YearType Then
                        factor = 1D / 52D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 26D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 13D
                    ElseIf unit = WeekType Then
                        factor = 1D
                    ElseIf unit = DayType Then
                        factor = 7D
                    ElseIf unit = BiWeekType Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If unit = MonthType Then
                        factor = 1D / 30D
                    ElseIf unit = SemiMonthType Then
                        factor = 1D / 15D
                    ElseIf unit = YearType Then
                        factor = 1D / 360D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 180D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 90D
                    ElseIf unit = WeekType Then
                        factor = 1D / 7D
                    ElseIf unit = DayType Then
                        factor = 1D
                    ElseIf unit = BiWeekType Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

        Private Function ComputeFixedRateEarning(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
            Dim factor As Decimal
            Select Case payFrequency
                Case PayFrequencySelection.Monthly
                    If unit = MonthType Then
                        factor = 1D
                    ElseIf unit = SemiMonthType Then
                        factor = 2D
                    ElseIf unit = YearType Then
                        factor = 1D / 12D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 6D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 3D
                    ElseIf unit = WeekType Then
                        factor = 13D / 2D
                    ElseIf unit = DayType Then
                        factor = 30D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 6D
                    End If
                Case PayFrequencySelection.Yearly
                    If unit = MonthType Then
                        factor = 12D
                    ElseIf unit = SemiMonthType Then
                        factor = 24D
                    ElseIf unit = YearType Then
                        factor = 1D
                    ElseIf unit = SemiYearType Then
                        factor = 2D
                    ElseIf unit = QuarterType Then
                        factor = 4D
                    ElseIf unit = WeekType Then
                        factor = 52D
                    ElseIf unit = DayType Then
                        factor = 365D
                    ElseIf unit = BiWeekType Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If unit = MonthType Then
                        factor = 6D
                    ElseIf unit = SemiMonthType Then
                        factor = 12D
                    ElseIf unit = YearType Then
                        factor = 1D / 2D
                    ElseIf unit = SemiYearType Then
                        factor = 1D
                    ElseIf unit = QuarterType Then
                        factor = 2D
                    ElseIf unit = WeekType Then
                        factor = 26D
                    ElseIf unit = DayType Then
                        factor = 365D / 2D
                    ElseIf unit = BiWeekType Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If unit = MonthType Then
                        factor = 3D
                    ElseIf unit = SemiMonthType Then
                        factor = 6D
                    ElseIf unit = YearType Then
                        factor = 1D / 4D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 2D
                    ElseIf unit = QuarterType Then
                        factor = 1D
                    ElseIf unit = WeekType Then
                        factor = 13D
                    ElseIf unit = DayType Then
                        factor = 365D / 4D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If unit = MonthType Then
                        factor = 1D / 2D
                    ElseIf unit =
                           SemiMonthType Then
                        factor = 1D
                    ElseIf unit = YearType Then
                        factor = 1D / 24D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 12D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 6D
                    ElseIf unit = WeekType Then
                        factor = 13D / 4D
                    ElseIf unit = DayType Then
                        factor = 15D
                    ElseIf unit = BiWeekType Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If unit = MonthType Then
                        factor = 12D / 52D
                    ElseIf unit = SemiMonthType Then
                        factor = 24D / 52D
                    ElseIf unit = YearType Then
                        factor = 1D / 52D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 26D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 13D
                    ElseIf unit = WeekType Then
                        factor = 1D
                    ElseIf unit = DayType Then
                        factor = 7D
                    ElseIf unit = BiWeekType Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If unit = MonthType Then
                        factor = 1D / 30D
                    ElseIf unit = SemiMonthType Then
                        factor = 1D / 15D
                    ElseIf unit = YearType Then
                        factor = 1D / 360D
                    ElseIf unit = SemiYearType Then
                        factor = 1D / 180D
                    ElseIf unit = QuarterType Then
                        factor = 1D / 90D
                    ElseIf unit = WeekType Then
                        factor = 1D / 7D
                    ElseIf unit = DayType Then
                        factor = 1D
                    ElseIf unit = BiWeekType Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

    End Module

End Namespace