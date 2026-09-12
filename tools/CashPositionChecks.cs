// Standalone checks for the compiled Accounts graph; no database writes.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using AATM.Accounts.DataLayer;
using AATM.Accounts.PresentationLayer.Models;
using AATM.Accounts.PresentationLayer.Views.Forms;
using AATM.Accounts.ServiceLayer;
using AATM.Libraries.GlobalFuncNSub;

public static class CashPositionChecks
{
    private sealed class RenderForm : CashPositionForm
    {
        protected override bool ShowWithoutActivation { get { return true; } }
        protected override void OnLoad(EventArgs e) { }
        protected override void OnShown(EventArgs e) { }
    }

    public static void ResolveRuntimeFrom(string directory)
    {
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            var name = new AssemblyName(args.Name).Name + ".dll";
            var path = Path.Combine(directory, name);
            return File.Exists(path) ? Assembly.LoadFrom(path) : null;
        };
    }

    private sealed class Fixture : ICashPositionDao
    {
        public DataTable Data;
        public DataTable GetAccounts() { return Data; }
        public DataTable GetTransaction(string code, int journalIdNo, int itemIdNo) { return Data; }
        public DataTable GetPosition(DateTime start, DateTime end, List<short> ids) { return Data; }
    }

    private static void Check(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static void Reject(Action action, string expected)
    {
        try { action(); }
        catch (Exception ex) { Check(ex.Message == expected, "Unexpected validation: " + ex.Message); return; }
        throw new InvalidOperationException("Expected rejection: " + expected);
    }

    private static DataTable Sample()
    {
        var table = new DataTable();
        string[] names = { "IdNo", "AccountCode", "AccountName", "AccountNameAra", "Active", "SnapshotId",
            "SnapshotDebit", "SnapshotCredit", "SnapshotRows", "SnapshotDifference", "JournalCode",
            "JournalIdNo", "ItemIdNo", "TransactionDate", "ReferenceNo", "Notes", "HeaderPosted",
            "ItemPosted", "ClosingJournal", "Debit", "Credit" };
        foreach (var name in names) table.Columns.Add(name, typeof(object));
        // Same item and journal IDs across different journal tables must remain distinct.
        table.Rows.Add((short)104, "104", "Cash", "نقد", true, 1, 100m, 0m, 2, 0m,
            "CR", 7, 9, new DateTime(2025, 11, 30), "A", "", true, true, false, 20m, 0m);
        table.Rows.Add((short)104, "104", "Cash", "نقد", true, 1, 100m, 0m, 2, 0m,
            "CD", 7, 9, new DateTime(2025, 12, 1), "B", "", false, false, false, 0m, 5m);
        table.Rows.Add((short)104, "104", "Cash", "نقد", true, 1, 100m, 0m, 2, 0m,
            "CR", 8, 10, new DateTime(2025, 12, 31), "C", "", true, false, false, 30m, 0m);
        // No source lines and no individual opening row: keep the account visible and flagged.
        table.Rows.Add((short)105, "105", "Till", "صندوق", false, DBNull.Value, DBNull.Value, DBNull.Value,
            2, 0m, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, "", "", DBNull.Value,
            DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value);
        return table;
    }

    public static void RunOffline()
    {
        var fixture = new Fixture { Data = Sample() };
        var service = new CashPositionService(fixture);
        var start = new DateTime(2025, 12, 1);
        var end = new DateTime(2025, 12, 31);
        short[] ids = { 104, 105 };
        var result = service.GetPosition(start, end, ids);
        Check(result.Accounts.Count == 2 && result.Lines.Count == 2, "Scope and source identity");
        var cash = result.Accounts[0];
        Check(cash.OpeningBalance == 120m && cash.Debit == 30m && cash.Credit == 5m && cash.ClosingBalance == 145m,
            "Snapshot once plus pre-period and unposted movements");
        Check(cash.PostingReviewLines == 1, "Mixed header/detail state must remain included and flagged");
        Check(!result.Accounts[1].HasOpeningSnapshot && result.Accounts[1].ClosingBalance == 0m, "Zero-activity account");
        Reject(() => service.GetPosition(end, start, ids), "CashPositionInvalidDates");
        Reject(() => service.GetPosition(start, end, new short[0]), "CashPositionSelectAccounts");
        Reject(() => service.GetPosition(start, end, new short[] { 104, 106 }), "CashPositionAccountsChanged");
        fixture.Data.ImportRow(fixture.Data.Rows[0]);
        Reject(() => service.GetPosition(start, end, ids), "CashPositionDuplicateSource");
        fixture.Data = Sample(); fixture.Data.Rows[0]["SnapshotRows"] = 0;
        Reject(() => service.GetPosition(start, end, ids), "CashPositionMissingYear");
        fixture.Data = Sample(); fixture.Data.Rows[0]["SnapshotDifference"] = 1m;
        Reject(() => service.GetPosition(start, end, ids), "CashPositionUnbalancedSnapshot");
        fixture.Data = Sample();
        fixture.Data.Rows.Add((short)104, "104", "Cash", "نقد", true, 1, 100m, 0m, 2, 0m,
            "CR", 9, 11, new DateTime(2026, 1, 1), "D", "", false, false, false, 50m, 0m);
        result = service.GetPosition(start, new DateTime(2026, 1, 1), ids);
        Check(result.Accounts[0].ClosingBalance == 195m, "Cross-year report must not add a second snapshot");
        Console.WriteLine("PASS: offline calculation and validation checks");
    }

    public static void RunCaptions()
    {
        var previousContext = LicenseManager.CurrentContext;
        var previousCulture = Thread.CurrentThread.CurrentCulture;
        var previousUiCulture = Thread.CurrentThread.CurrentUICulture;
        LicenseManager.CurrentContext = new DesigntimeLicenseContext();
        try
        {
            using (var form = new RenderForm())
            {
                var resources = new System.Resources.ResourceManager(
                    "AATM.Accounts.PresentationLayer.Views.Forms.CashPositionForm", typeof(CashPositionForm).Assembly);
                var grids = new[] { Field<DataGridView>(form, "_summary"), Field<DataGridView>(form, "_details") };
                string[][] keys = {
                    new[] { "Account", "Opening", "Debit", "Credit", "Closing", "Review" },
                    new[] { "Date", "Journal", "JournalId", "ItemId", "Reference", "Debit", "Credit",
                            "HeaderPosted", "ItemPosted", "ClosingEntry", "Notes" }
                };
                foreach (var language in new[] { "en-GB", "ar-SA", "en-GB" })
                {
                    var culture = new CultureInfo(language);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    // The shared caption collector owns Tag and may replace it with display text.
                    foreach (var grid in grids)
                        foreach (DataGridViewColumn column in grid.Columns) column.Tag = column.HeaderText;
                    typeof(CashPositionForm).GetMethod("ApplyCaptions", BindingFlags.Instance | BindingFlags.NonPublic)
                        .Invoke(form, null);
                    form.SetAccounts(new CashPositionService(new Fixture { Data = Sample() }).GetPosition(
                        new DateTime(2025, 12, 1), new DateTime(2025, 12, 31), new short[] { 104, 105 }).Accounts);
                    for (int pass = 0; pass < 2; pass++)
                    {
                        form.ShowPosition(new CashPositionService(new Fixture { Data = Sample() }).GetPosition(
                            new DateTime(2025, 12, 1), new DateTime(2025, 12, 31), new short[] { 104, 105 }));
                        for (int g = 0; g < grids.Length; g++)
                            for (int c = 0; c < keys[g].Length; c++)
                                Check(grids[g].Columns[c].HeaderText == resources.GetString(keys[g][c], culture),
                                    language + " header " + grids[g].Columns[c].Name + ": " + grids[g].Columns[c].HeaderText);
                        form.ClearPosition();
                    }
                }
            }
        }
        finally
        {
            LicenseManager.CurrentContext = previousContext;
            Thread.CurrentThread.CurrentCulture = previousCulture;
            Thread.CurrentThread.CurrentUICulture = previousUiCulture;
        }
        Console.WriteLine("PASS: all 17 grid captions after Tag replacement, rebinding and English/Arabic/English switching (offline)");
    }

    public static void RunTransactions(string outputDirectory)
    {
        var data = new DataTable();
        foreach (var name in new[] { "JournalIdNo", "TransactionDate", "ReferenceNo", "HeaderNotes", "HeaderPosted",
            "Approved", "Cancelled", "ClosingJournal", "ItemIdNo", "Sequence", "AccountIdNo", "AccountCode",
            "AccountName", "AccountNameAra", "Debit", "Credit", "Notes", "ItemPosted" })
            data.Columns.Add(name, typeof(object));
        data.Rows.Add(40000, new DateTime(2025,12,1), "Test ref", "Voucher notes", true, true, false, false,
            50000, (short)1, (short)104, "104", "Cash", "نقد", 0m, 25m, "Cash line", true);
        data.Rows.Add(40000, new DateTime(2025,12,1), "Test ref", "Voucher notes", true, true, false, false,
            50001, (short)2, (short)500, "500", "Expense", "مصروف", 25m, 0m, "Other account", false);
        var fixture = new Fixture { Data = data };
        var service = new CashPositionService(fixture);
        var transaction = service.GetTransaction("CD", 40000, 50000);
        Check(transaction.Lines.Count == 2 && transaction.Notes == "Voucher notes", "Whole voucher and header notes");
        Check(transaction.Lines.Sum(l => l.Debit) == transaction.Lines.Sum(l => l.Credit), "All sides of the voucher");
        Reject(() => service.GetTransaction("bad", 40000, 50000), "CashPositionTransactionUnavailable");
        Reject(() => service.GetTransaction("CD", 0, 50000), "CashPositionTransactionUnavailable");
        Reject(() => service.GetTransaction("CD", 40000, 59999), "CashPositionTransactionUnavailable");
        Reject(() => service.GetTransaction("CD", 40001, 50000), "CashPositionTransactionUnavailable");
        fixture.Data = data.Clone();
        Reject(() => service.GetTransaction("CD", 40000, 50000), "CashPositionTransactionUnavailable");

        var previousContext = LicenseManager.CurrentContext;
        LicenseManager.CurrentContext = new DesigntimeLicenseContext();
        try
        {
            using (var form = new RenderForm())
            {
                var position = new CashPositionService(new Fixture { Data = Sample() }).GetPosition(
                    new DateTime(2025,12,1), new DateTime(2025,12,31), new short[] {104,105});
                form.ShowPosition(position);
                var details = Field<DataGridView>(form, "_details");
                details.BindingContext = new BindingContext();
                details.DataSource = new BindingList<CashPositionLineModel>(position.Lines);
                int requests = 0;
                form.TransactionRequested += (code, journalId, itemId) => {
                    var expected = position.Lines[1];
                    Check(code == expected.JournalCode && journalId == expected.JournalIdNo && itemId == expected.ItemIdNo,
                        "Double-click dispatches the clicked row's full identity");
                    requests++;
                };
                var click = typeof(DataGridView).GetMethod("OnCellDoubleClick", BindingFlags.Instance | BindingFlags.NonPublic);
                click.Invoke(details, new object[] { new DataGridViewCellEventArgs(0, -1) });
                Check(requests == 0, "Column headers do not open a transaction");
                click.Invoke(details, new object[] { new DataGridViewCellEventArgs(0, 1) });
                Check(requests == 1, "Double-click event is connected");
                form.ClearPosition();
                typeof(CashPositionForm).GetMethod("DetailsCellDoubleClick", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(form, new object[] { details, new DataGridViewCellEventArgs(0, 0) });
                Check(requests == 1, "Cleared results do not reopen stale transactions");
            }
        }
        finally { LicenseManager.CurrentContext = previousContext; }
        RenderTransaction(transaction, outputDirectory);
        Console.WriteLine("PASS: transaction identity, missing records, full voucher, double-click event and popup rendering");
    }

    public static void RunTransactionDatabase(CashPositionModel position, string outputDirectory)
    {
        var dao = new AATM.Accounts.DataLayer.AdoNet.CashPositionDao();
        foreach (var code in new[] { "GJ", "AP", "AR", "ER", "CK", "CD", "CR", "PC", "SJ" })
            Check(dao.GetTransaction(code, int.MaxValue, int.MaxValue).Rows.Count == 0, "Query schema and missing ID: " + code);
        var service = new CashPositionService();
        foreach (var source in position.Lines.GroupBy(l => l.JournalCode).Select(g => g.First()))
        {
            var voucher = service.GetTransaction(source.JournalCode, source.JournalIdNo, source.ItemIdNo);
            var clicked = voucher.Lines.Single(l => l.ItemIdNo == source.ItemIdNo);
            Check(clicked.AccountIdNo == source.AccountIdNo && clicked.Debit == source.Debit && clicked.Credit == source.Credit,
                "Live source-line agreement: " + source.JournalCode);
        }
        var cash = position.Lines.First(l => l.JournalCode == "CD");
        var full = service.GetTransaction(cash.JournalCode, cash.JournalIdNo, cash.ItemIdNo);
        Check(full.Lines.Any(l => l.AccountIdNo != cash.AccountIdNo), "Live popup includes other accounts");
        RenderTransaction(full, outputDirectory);
        Console.WriteLine("PASS: nine journal query schemas and read-only test-database transaction drill-down");
    }

    private static void RenderTransaction(CashPositionTransactionModel transaction, string outputDirectory)
    {
        var previousCulture = Thread.CurrentThread.CurrentCulture;
        var previousUiCulture = Thread.CurrentThread.CurrentUICulture;
        try
        {
            foreach (var language in new[] { "en-GB", "ar-SA" })
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                using (var form = new CashPositionTransactionForm(transaction))
                {
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = new Point(-32000, -32000);
                    form.Show();
                    form.PerformLayout();
                    var grid = (DataGridView)typeof(CashPositionTransactionForm).GetField("_grid",
                        BindingFlags.Instance | BindingFlags.NonPublic).GetValue(form);
                    grid.BindingContext = new BindingContext();
                    Check(grid.ReadOnly && !grid.AllowUserToAddRows && !grid.AllowUserToDeleteRows, "Read-only voucher");
                    Check(grid.Rows.Count == transaction.Lines.Count, "Popup contains all journal lines");
                    Check(((CashPositionTransactionLineModel)grid.CurrentRow.DataBoundItem).ItemIdNo == transaction.SelectedItemIdNo,
                        "Clicked cash line highlighted");
                    Check(form.RightToLeftLayout == (language == "ar-SA"), "Popup RTL");
                    foreach (DataGridViewColumn column in grid.Columns)
                        Check(!string.IsNullOrWhiteSpace(column.HeaderText) && !column.HeaderText.StartsWith("Unable to load"), "Popup caption");
                    using (var bitmap = new Bitmap(form.Width, form.Height))
                    {
                        form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                        bitmap.Save(Path.Combine(outputDirectory, "cash-transaction-" + language + ".png"));
                    }
                }
            }
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = previousCulture;
            Thread.CurrentThread.CurrentUICulture = previousUiCulture;
        }
    }

    public static CashPositionModel RunDatabase()
    {
        var service = new CashPositionService();
        var accounts = service.GetAccounts();
        var ids = accounts.Select(a => a.IdNo).ToArray();
        var result = service.GetPosition(new DateTime(2025, 12, 1), new DateTime(2025, 12, 31), ids);
        Check(result.Accounts.Sum(a => a.OpeningBalance) == 42520.50m, "December opening baseline");
        Check(result.Accounts.Sum(a => a.Debit) == 569843.34m, "December debit baseline");
        Check(result.Accounts.Sum(a => a.Credit) == 453445.61m, "December credit baseline");
        Check(result.Accounts.Sum(a => a.ClosingBalance) == 158918.23m, "December closing baseline");
        Check(result.Lines.Count == 661, "December source line count");
        foreach (var account in result.Accounts)
        {
            Check(result.Lines.Where(l => l.AccountIdNo == account.IdNo).Sum(l => l.Debit) == account.Debit,
                "Detail-to-summary debit agreement");
            Check(result.Lines.Where(l => l.AccountIdNo == account.IdNo).Sum(l => l.Credit) == account.Credit,
                "Detail-to-summary credit agreement");
        }
        var single = service.GetPosition(result.BeginningDate, result.EndingDate, new short[] { 113 });
        Check(single.Accounts.Count == 1 && single.Accounts[0].OpeningBalance == -11143.41m &&
            single.Accounts[0].ClosingBalance == 0m, "Petty cash subset");
        var november = service.GetPosition(new DateTime(2025, 11, 1), new DateTime(2025, 11, 30), ids);
        foreach (var account in november.Accounts)
            Check(account.ClosingBalance == result.Accounts.Single(a => a.IdNo == account.IdNo).OpeningBalance,
                "November closing equals December opening");
        var cross = service.GetPosition(new DateTime(2025, 12, 1), new DateTime(2026, 1, 31), ids);
        var january = service.GetPosition(new DateTime(2026, 1, 1), new DateTime(2026, 1, 31), ids);
        foreach (var account in cross.Accounts)
            Check(account.ClosingBalance == january.Accounts.Single(a => a.IdNo == account.IdNo).ClosingBalance,
                "Fiscal year boundary agrees with the next opening snapshot");
        Console.WriteLine("PASS: read-only December baseline, subset, monthly and fiscal boundaries");
        return result;
    }

    private static T Field<T>(object instance, string name)
    {
        return (T)typeof(CashPositionForm).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(instance);
    }

    public static void Render(CashPositionModel result, string outputDirectory)
    {
        var previousContext = LicenseManager.CurrentContext;
        LicenseManager.CurrentContext = new DesigntimeLicenseContext();
        try
        {
        foreach (var language in new[] { "en-GB", "ar-SA" })
        {
            var culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            GlobalVariables.AppCurrentCultureInfo = culture;
            // Offscreen rendering avoids login, translation initialization and application startup side effects.
            using (var form = new RenderForm())
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(-32000, -32000);
                form.ShowInTaskbar = false;
                form.SetAccounts(result.Accounts);
                form.ShowPosition(result);
                form.Show();
                form.PerformLayout();
                var grid = Field<DataGridView>(form, "_summary");
                grid.BindingContext = new BindingContext();
                Check(grid.Rows.Count == result.Accounts.Count, "Summary grid binding");
                Check(form.RightToLeftLayout == culture.TextInfo.IsRightToLeft, "RTL layout");
                Check(language != "ar-SA" || form.Text == "الموقف النقدي", "Arabic resources");
                grid.CurrentCell = grid.Rows[0].Cells[0];
                var detailGrid = Field<DataGridView>(form, "_details");
                Check(detailGrid.Rows.Count == result.Lines.Count(l => l.AccountIdNo == result.Accounts[0].IdNo),
                    "Selecting an account filters its source detail");
                Check(Convert.ToString(detailGrid.Rows[0].Cells["TransactionDate"].FormattedValue).StartsWith("2025-12-"),
                    "Detail and filter dates use the same Gregorian calendar in both languages");
                using (var bitmap = new Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                    bitmap.Save(Path.Combine(outputDirectory, "cash-position-" + language + ".png"));
                }
                Field<CheckedListBox>(form, "_accounts").SetItemChecked(0, false);
                Check(grid.DataSource == null, "Changing scope clears stale balances");
                form.ShowPosition(result);
                Field<DateTimePicker>(form, "_ending").Value = new DateTime(2025, 12, 30);
                Check(grid.DataSource == null, "Changing dates clears stale balances");
            }
        }
        }
        finally { LicenseManager.CurrentContext = previousContext; }
        Console.WriteLine("PASS: English/Arabic offscreen rendering, binding and stale-result clearing");
    }
}
