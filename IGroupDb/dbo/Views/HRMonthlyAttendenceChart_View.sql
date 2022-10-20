
CREATE VIEW HRMonthlyAttendenceChart_View
 
AS
select 	a.BranchID,
	a.PeriodMonth,
	a.PeriodYear,
	a.EmpID,
	a.TotalDays,
	case when a.Day1 = 1 then 1 else 0 end +
	case when a.Day2 = 1 then 1 else 0 end +
	case when a.Day3 = 1 then 1 else 0 end +
	case when a.Day4 = 1 then 1 else 0 end +
	case when a.Day5 = 1 then 1 else 0 end +
	case when a.Day6 = 1 then 1 else 0 end +
	case when a.Day7 = 1 then 1 else 0 end +
	case when a.Day8 = 1 then 1 else 0 end +
	case when a.Day9 = 1 then 1 else 0 end +
	case when a.Day10 = 1 then 1 else 0 end +
	case when a.Day11 = 1 then 1 else 0 end +
	case when a.Day12 = 1 then 1 else 0 end +
	case when a.Day13 = 1 then 1 else 0 end +
	case when a.Day14 = 1 then 1 else 0 end +
	case when a.Day15 = 1 then 1 else 0 end +
	case when a.Day16 = 1 then 1 else 0 end +
	case when a.Day17 = 1 then 1 else 0 end +
	case when a.Day18 = 1 then 1 else 0 end +
	case when a.Day19 = 1 then 1 else 0 end +
	case when a.Day20 = 1 then 1 else 0 end +
	case when a.Day21 = 1 then 1 else 0 end +
	case when a.Day22 = 1 then 1 else 0 end +
	case when a.Day23 = 1 then 1 else 0 end +
	case when a.Day24 = 1 then 1 else 0 end +
	case when a.Day25 = 1 then 1 else 0 end +
	case when a.Day26 = 1 then 1 else 0 end +
	case when a.Day27 = 1 then 1 else 0 end +
	case when a.Day28 = 1 then 1 else 0 end +
	case when a.Day29 = 1 then 1 else 0 end +
	case when a.Day30 = 1 then 1 else 0 end +
	case when a.Day31 = 1 then 1 else 0  end  as WorkingDays,
	case when a.Day1 = 2 then 1 else 0 end +
	case when a.Day2 = 2 then 1 else 0 end +
	case when a.Day3 = 2 then 1 else 0 end +
	case when a.Day4 = 2 then 1 else 0 end +
	case when a.Day5 = 2 then 1 else 0 end +
	case when a.Day6 = 2 then 1 else 0 end +
	case when a.Day7 = 2 then 1 else 0 end +
	case when a.Day8 = 2 then 1 else 0 end +
	case when a.Day9 = 2 then 1 else 0 end +
	case when a.Day10 = 2 then 1 else 0 end +
	case when a.Day11 = 2 then 1 else 0 end +
	case when a.Day12 = 2 then 1 else 0 end +
	case when a.Day13 = 2 then 1 else 0 end +
	case when a.Day14 = 2 then 1 else 0 end +
	case when a.Day15 = 2 then 1 else 0 end +
	case when a.Day16 = 2 then 1 else 0 end +
	case when a.Day17 = 2 then 1 else 0 end +
	case when a.Day18 = 2 then 1 else 0 end +
	case when a.Day19 = 2 then 1 else 0 end +
	case when a.Day20 = 2 then 1 else 0 end +
	case when a.Day21 = 2 then 1 else 0 end +
	case when a.Day22 = 2 then 1 else 0 end +
	case when a.Day23 = 2 then 1 else 0 end +
	case when a.Day24 = 2 then 1 else 0 end +
	case when a.Day25 = 2 then 1 else 0 end +
	case when a.Day26 = 2 then 1 else 0 end +
	case when a.Day27 = 2 then 1 else 0 end +
	case when a.Day28 = 2 then 1 else 0 end +
	case when a.Day29 = 2 then 1 else 0 end +
	case when a.Day30 = 2 then 1 else 0 end +
	case when a.Day31 = 2 then 1 else 0  end  as OffDays,
	case when Day1 = 1 then 'P' else 'A' end as Day1,
	case when Day2 = 1 then 'P' else 'A' end as Day2,
	case when Day3 = 1 then 'P' else 'A' end as Day3,
	case when Day4 = 1 then 'P' else 'A' end as Day4,
	case when Day5 = 1 then 'P' else 'A' end as Day5,
	case when Day6 = 1 then 'P' else 'A' end as Day6,
	case when Day7 = 1 then 'P' else 'A' end as Day7,
	case when Day8 = 1 then 'P' else 'A' end as Day8,
	case when Day9 = 1 then 'P' else 'A' end as Day9,
	case when Day10 = 1 then 'P' else 'A' end as Day10,
	case when Day11 = 1 then 'P' else 'A' end as Day11,
	case when Day12 = 1 then 'P' else 'A' end as Day12,
	case when Day13 = 1 then 'P' else 'A' end as Day13,
	case when Day14 = 1 then 'P' else 'A' end as Day14,
	case when Day15 = 1 then 'P' else 'A' end as Day15,
	case when Day16 = 1 then 'P' else 'A' end as Day16,
	case when Day17 = 1 then 'P' else 'A' end as Day17,
	case when Day18 = 1 then 'P' else 'A' end as Day18,
	case when Day19 = 1 then 'P' else 'A' end as Day19,
	case when Day20 = 1 then 'P' else 'A' end as Day20,
	case when Day21 = 1 then 'P' else 'A' end as Day21,
	case when Day22 = 1 then 'P' else 'A' end as Day22,
	case when Day23 = 1 then 'P' else 'A' end as Day23,
	case when Day24 = 1 then 'P' else 'A' end as Day24,
	case when Day25 = 1 then 'P' else 'A' end as Day25,
	case when Day26 = 1 then 'P' else 'A' end as Day26,
	case when Day27 = 1 then 'P' else 'A' end as Day27,
	case when Day28 = 1 then 'P' else 'A' end as Day28,
	case when Day29 = 1 then 'P' else 'A' end as Day29,
	case when Day30 = 1 then 'P' else 'A' end as Day30,
	case when Day31 = 1 then 'P' else 'A' end as Day31,
	b.EmpNameEnglish,
	b.DepartmentID
from HRAttendenceDescription a
left outer join HREmployeeDetails b on a.EmpID = b.EmpID