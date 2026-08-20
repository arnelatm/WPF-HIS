# Codex repository instructions

## Scope and source of truth

- These instructions apply to the entire repository.
- Treat `HIS.sln` as the primary solution for the production Accounts application. It is a Visual Studio 2022 solution (`Format Version 12.00`) whose startup application is `Accounts\Accounts.vbproj`.
- Read `docs\Accounts-System-Handover.md` before making a substantial Accounts, reporting, security, or database change. It contains useful feature-level orientation, but verify details against current code and project files.
- The repository also contains standalone solutions/projects, historical scripts, copies, experiments, and quarantined material. A file's presence does not prove that it is compiled or deployed. Before changing a file, verify that it is included by the relevant `.sln` and old-style project file.
- `HIS.sln.bak`, the root `HIS.vbproj`, `PresentationLayer\PresentationLayer.vbproj`, and projects outside `HIS.sln` are not substitutes for the primary solution. Only touch a standalone project when the task explicitly puts it in scope.
- Do not delete or exclude apparently unused code as incidental cleanup. Some files under `Accounts\_Quarantine` and `Common\_Quarantine` remain deliberately included in their projects because runtime, reflection, configuration, or database-driven use has not been ruled out. The top-level `_Quarantine` manifests document isolated legacy projects.
- Preserve unrelated working-tree changes and untracked files. Never commit or push unless the user explicitly requests it.

## Technology and toolchain

- The production application is predominantly VB.NET Windows Forms. Small C# helper libraries and SQL Server database projects are also present.
- `Accounts`, the shared VB libraries, `Common`, `BusinessLayer`, `DataLayer`, `ServicesLayer`, the split `PresentationLayer` projects, and `PMR` target .NET Framework 4.7.2.
- Exceptions inside the main solution include `Libraries\MessageBoxManager` (.NET Framework 4.8) and `Libraries\AatmInterfaces` plus `Accounts\CAccounts` (`netstandard2.0`). Do not retarget these projects as part of an unrelated change.
- The solution configurations named `Debug (.NET 3.5)` and `Release (.NET 3.5)` are legacy configuration names; they do not mean that the main projects currently target .NET 3.5. Prefer `Debug|Any CPU` or `Release|Any CPU` unless a task specifically concerns the legacy configurations.
- Projects outside the main solution span older .NET Framework versions, `netstandard2.1`, and `netcoreapp3.1` (for example `QrDrugScanner`). Do not apply main-solution framework assumptions repository-wide.
- The active UI is WinForms. There is no tracked, active WPF/XAML project in `HIS.sln`; the `WPF`, `App`, and `UI` roots currently contain only local `.user` remnants. A few active projects reference `PresentationFramework` or import isolated `System.Windows.*` namespaces, but that does not make them WPF applications.
- Use Visual Studio/MSBuild on Windows for the primary solution. A practical workstation needs the .NET desktop workload, the .NET Framework 4.7.2 and 4.8 targeting packs, and SSDT/database-project support. The SQL projects use SQL120, SQL130, and SQL160 schema providers.
- NuGet dependencies use `packages.config` and restore into the ignored root `packages\` directory. The main app uses AutoMapper 9, Autofac 6 (but is not organized around container-based DI), Compare-NET-Objects, Crystal Reports, and other compatibility packages.
- Telerik WinForms 2020.1.218.40 assemblies are checked in under `lib\RCWF\2020.1.218.40` and referenced with relative paths. Crystal Reports references are restored from packages, and local Crystal designer/runtime installation may still be needed. Crystal package versions differ slightly between projects; do not normalize them casually.
- Git LFS is required for the LFS-marked binaries. On a fresh workstation, make sure `git lfs pull` has completed before diagnosing missing binary assets.

## Solution and project architecture

### Main executable and shared projects

- `Accounts\Accounts.vbproj` is a .NET Framework 4.7.2 `WinExe`, root namespace `AATM.Accounts`, with custom `Sub Main` in `Accounts\Main.vb`. `MainForm` performs culture setup, initializes AutoMapper with `MappingProfileAccounts` and `MappingProfileCommon`, creates the login presenter, and launches most forms.
- Accounts-specific business objects, DAOs, services, models, presenters, view interfaces, forms, and reports live under `Accounts\...` and are compiled into the single `Accounts` executable project. They are folders/layers, not separate Accounts assemblies.
- `BusinessLayer` supplies the shared `BusinessObject` validation base, rule types, and common security/login business objects.
- `DataLayer` supplies DAO contracts, `AdoNet\Db.vb`, `BaseDao`, conversion extensions, data retrieval, and the base reflection-driven DAO factory.
- `ServicesLayer` supplies the shared `Service` facade and service contracts. It maps presentation models to business objects and delegates to DAOs.
- `PresentationLayer` is split in `HIS.sln` into `Models`, `Presenters`, `Views`, `Forms`, and `Events`. These projects contain the reusable MVP bases, base WinForms, view contracts, and event types.
- `Common` is a shared vertical slice: it contains common business objects, DAOs, services, models, presenters, forms, and `MappingProfileCommon` in one project.
- `Libraries` contains custom WinForms controls, shared interfaces, global functions and variables, resources/localization, messaging, Crystal helpers, and other utilities. Reuse the established library nearest to the feature instead of duplicating helpers in `Accounts`.
- Project dependencies are broad and historically coupled. `Accounts` references the shared business/data/service/common projects, every split presentation project, and many local libraries. `Models` references business/services; `Presenters` references models/views/events/services; `Forms` references presenters/models/views/events and shared layers. Do not attempt dependency cleanup or move types between projects during a feature fix.

### MVP presentation pattern

- The normal screen flow is WinForms view -> presenter -> service -> DAO -> SQL Server, with AutoMapper between view/model/business-object shapes.
- Forms implement a view interface such as `IAccountView`. Interface properties wrap controls, and view-specific events notify the presenter. Keep UI mechanics in the form and workflow, validation coordination, authorization, and persistence orchestration in the presenter.
- Data-entry forms normally inherit one of the shared bases such as `BFMain`, `CFormEntry`, or `CFormEntryTv`. Preserve the existing base class and use a nearby working screen as the template; several old and new presenter/form bases coexist and are not interchangeable.
- Presenters normally inherit through the existing chain (`Presenter` -> `CommonPresenter` -> `AccountsPresenter`, with specialized presenters such as `TransactionsPresenter`). Do not select `BasePresenter`, `PresenterBase`, `PresenterOld`, or another similarly named base just because its name looks appropriate; follow the chain used by the closest active feature.
- `MainForm.RunForm(Of TV, TP)` and related helpers instantiate forms and presenters, often via `Activator.CreateInstance`, then assign the form's `Presenter`. Constructor signatures therefore form part of the runtime contract.
- Base forms and presenters use an event aggregator plus types in `PresentationLayer\Events`. Preserve `ISubscriber(Of T)`, `SubscribeEvent`, `PublishEvent`, `Handles`, and `AddHandler` wiring when changing events. Weak/reflection-based wiring may not appear in a simple caller search.
- A form's `MainFieldsDictionary`, view-interface properties, model properties, business-object properties, DAO fields, and SQL column names are intentionally aligned. Treat spelling, casing, nullable types, and numeric widths (`Int16` versus `Int32`) as contracts.
- Tree screens additionally rely on presenter fields such as `TableName`, `TableBaseName`, `SortOrderKey`, `ParentFieldName`, `TreeViewMainField`, and `TreeViewSecondaryField`.
- Business objects inherit `AATM.BusinessLayer.BusinessObject` and normally register reusable validation rules in their constructor. Presentation models are mostly simple DTOs. Put durable domain validation in the business object when that is the pattern for the feature; do not replace it with form-only validation.
- Update `Accounts\MappingProfileAccounts.vb` or `Common\MappingProfileCommon.vb` whenever a new or renamed model/view/business mapping requires it. Missing mappings commonly fail only at runtime.
- Transaction screens inherit `TransactionsPresenter` protections. Preserve checks for posted records, closed periods (`LastPosting`), approvals/security, and reconciled lines. Never bypass those checks merely to make a save path succeed.
- UI text is bilingual and can run right-to-left. Use the existing `Messaging`, global resource, translated caption/message, and `...NameAra` patterns. Test both ordinary and RTL culture behavior when changing labels, layout, lookup display, or reports.

### Services, DAOs, and the repository abstraction

- The active persistence abstraction is the DAO/service stack, not Entity Framework. `Service`, `CommonService`, and `AccountsService` are facade-style services that hold `DataBo` and `DataDao`, map through `GlobalVariables.Mapper`, and call ADO.NET DAOs.
- `New AccountsService("Account")` is convention based. It expects `AATM.Accounts.BusinessLayer.Account` and `AATM.Accounts.DataLayer.AdoNet.AccountDao`. The DAO factory builds that fully qualified name with reflection. Renaming a feature class or changing its namespace must be traced across the business object, DAO, service construction, model, view, presenter, mapper, and SQL object names.
- VB project `RootNamespace` values are automatically prepended. Most source files deliberately declare relative namespaces such as `Namespace BusinessLayer` or `Namespace DataLayer.AdoNet`; do not prepend `AATM.Accounts` again without checking the resulting fully qualified type.
- DAOs normally inherit `BaseDao`, `CommonDao`, or `AccountsDao` and implement focused contracts such as `IDao(Of T)`, `IDaoChild(Of T)`, or an Accounts-specific interface. Typical DAOs contain parameterized SQL, a reader-to-business-object `Make` function, and a business-object-to-parameter-array `Take` function.
- Use the existing `Db`/`BaseDao` helpers and parameter arrays for normal CRUD. Never concatenate user-entered values into SQL. Existing dynamic table, field, sort, and filter strings are legacy trusted-metadata paths; do not widen them to accept untrusted input.
- Some child collections are saved with `DataTable` table-valued parameters through `InsertTvp`, `DelUpdateTvp`, or paired update/insert procedures. The DataTable column names, order, CLR types, SQL user-defined table type, stored-procedure parameter name, and DAO procedure names must remain synchronized.
- AP, AR, and Cash Receipt journals now have dedicated `*JournalTransactionService` classes and `Save*Atomic`, `Update*Atomic`, and `Delete*Atomic` stored procedures. These procedures keep header, detail, open-invoice/payment, VAT, and reference-number work inside one SQL transaction. Preserve that atomic boundary; do not reintroduce sequential presenter-side writes for those flows. Other journals may still use the older presenter/TVP pattern, so do not claim or assume that every transaction has been converted.
- `ServicesLayer\Services\Repository.vb` and `IRepositories.vb` define a generic `Repository(Of TEntity)`, but repository search shows no consumers and the implementation contains incomplete/self-delegating members. Do not build new work on it or describe this repository as an EF repository architecture without an explicit refactoring task.
- Connection selection ultimately uses `GlobalVariables.DacConnectionString` and named connection strings such as `ISPDATA`, `IGROUPCLINIC`, and `TRANSLATIONS`. Existing services sometimes temporarily switch connection strings; always restore them, preferably with a `Try...Finally` if touching such code.

## WinForms and report changes

- Old-style VB projects explicitly list source files. When adding a `.vb` file, ensure its `<Compile Include>` is present in the correct `.vbproj`. SDK-style projects are the exception.
- A WinForms class usually has `.vb`, `.Designer.vb`, and `.resx` files with `DependentUpon` metadata. Preserve partial-class names, inheritance, component disposal, resource keys, and project nesting. Avoid broad reformatting of generated designer or resource files.
- Prefer changing behavioral code in the non-designer partial class. If a layout/control change requires editing designer code, make the smallest possible edit and verify that the form still opens in the Visual Studio designer.
- Reuse custom controls and their existing `GetValue`, `SetValue`, nullable parsing, `DisplayOnly`, security, and localization behaviors. Replacing them with stock controls can silently break presenter and security conventions.
- `Accounts\Reports` contains Crystal `.rpt` binaries and generated `.vb` wrappers. Treat `.rpt` as binary (except the explicit text exception in `.gitattributes`) and use the Crystal designer for report-definition changes. Keep report filename and parameter names synchronized with presenter/wrapper code and configured report paths.
- Report paths and some application integrations may be network- or site-specific. A missing share or runtime on one PC is not by itself evidence of a code defect.

## SQL Server/database-project rules

- `IspDataDb\IspDataDb.sqlproj` is the main `ISPDATA` schema project used by Accounts. It contains tables, views, functions, user-defined table types, and stored procedures under `IspDataDb\dbo\...` and targets the SQL120 provider.
- Other schemas are separate concerns: `IGroupClinicDb`/`IGroupDb`, `KizenDb`, `BioTime.Reporting.Database`, `BioTime.Reporting.ViewsOnly*`, and `BiotimeIbnServer` have their own projects and provider levels. `HIS.sln` includes only a subset of all database projects in the repository. Put a change in the project that owns the target database; do not copy it into every similar database automatically.
- `IspDataDb` has a checked-in DACPAC snapshot reference. Do not refresh, replace, or remove snapshots as incidental work; snapshot churn can change schema resolution broadly.
- SQL projects explicitly list objects as `<Build Include>`. When adding, moving, or renaming a database object, update the owning `.sqlproj` and verify there is exactly one authoritative object definition.
- There is no repository-wide ordered migration framework. The many SQL files at the repository root are historical setup, repair, data-fix, comparison, and diagnostic scripts; they are not automatically executed and are not necessarily authoritative. Prefer the object definition inside the owning database project for durable schema changes.
- Preserve `dbo` qualification, parameter types/lengths, nullability, money/decimal semantics, and existing error/transaction behavior. For multi-table accounting writes use `SET XACT_ABORT ON`, `TRY/CATCH`, and a transaction as the nearby atomic procedures do.
- Respect each project's SQL schema provider and the actual target server. Do not upgrade SQL120/130 projects or introduce provider-incompatible syntax merely to fix a local design-time warning.
- Do not publish a database project, run a root SQL script, execute a stored procedure, perform schema compare, or modify real data unless the user explicitly authorizes it and the target server/database is confirmed. Production-affecting work requires a backup and should be exercised first on a restored test database.
- Never put credentials or complete connection strings in code, documentation, logs, test output, or chat. Existing tracked config variants contain sensitive values; avoid displaying them unnecessarily.

## Coding and change discipline

- Match the style of the file being changed. This is legacy VB with `Option Explicit On`, `Option Infer On`, and project-level `Option Strict Off`; do not perform a repo-wide strictness, syntax, naming, namespace, or formatting conversion during a focused change.
- Use PascalCase for public types/members and follow the surrounding private-field convention (`_name`, `Db`, or another established local form). Preserve existing VB line continuations and `Handles` clauses.
- `.editorconfig` and `.gitattributes` require CRLF for Visual Studio source, project, config, SQL, and resource files. Crystal reports and other binaries must remain binary.
- Make narrow edits. Large generated forms, presenter bases, `Db.vb`, `BaseDao.vb`, mapper profiles, project files, and SQL project files have wide blast radius.
- Do not silently fix nearby legacy bugs, commented alternatives, duplicate-looking files, package-version mismatches, or casing inconsistencies. Record them separately unless they block the requested change.
- Do not introduce a new architecture, ORM, DI framework, async layer, or repository pattern for a local feature. Extend the nearest working vertical slice.

## Build and verification

- Run commands from a Visual Studio Developer PowerShell/Command Prompt so `MSBuild.exe` and SSDT targets resolve without hard-coded installation paths.
- Restore packages with Visual Studio or, where supported:

  ```powershell
  msbuild HIS.sln /t:Restore /p:RestorePackagesConfig=true
  ```

- A normal full build is:

  ```powershell
  msbuild HIS.sln /m /p:Configuration=Debug /p:Platform="Any CPU"
  ```

- For a focused application change, first build the smallest affected project graph, commonly:

  ```powershell
  msbuild Accounts\Accounts.vbproj /m /p:Configuration=Debug
  ```

- For a main schema-only change, build the DACPAC without publishing it:

  ```powershell
  msbuild IspDataDb\IspDataDb.sqlproj /p:Configuration=Debug
  ```

- Do not use `dotnet build` as the primary validation for `HIS.sln`; old-style .NET Framework VB projects, Crystal components, and SSDT projects need full MSBuild/Visual Studio tooling.
- There is no automated test project in `HIS.sln`. The only test-like project found is a standalone TimePicker test form. Do not report a change as fully tested based only on compilation.
- After a code change, perform the narrowest relevant manual smoke test against a non-production database: open the form, load/find a record, exercise add/edit/delete as applicable, confirm validation and permissions, and check both English and Arabic/RTL behavior when relevant. Accounting transaction changes also require balanced details and posted/approved/closed/reconciled scenarios. Report changes require preview/print verification with the expected parameter set.
- If the current task limits modified files, skip builds or designers that would generate additional files and state that limitation. Otherwise, ignored `bin\`/`obj\` outputs are expected, but verify tracked changes afterward.

## Office/home PC portability and safety

- Keep source and project references repository-relative. Do not add a path tied to `D:\AATM`, a user profile, a Visual Studio installation, or a particular office/home drive or share.
- `Accounts.vbproj` already contains legacy machine-specific ClickOnce `PublishUrl` and network `InstallUrl` values. They are deployment settings, not normal build prerequisites. Do not rewrite them for the current PC or invoke Publish unless deployment is explicitly requested.
- The active runtime configuration is `Accounts\app.config`; many `app-*.config` site/machine variants also exist and may contain live credentials. Do not guess which variant belongs on a PC, overwrite `app.config`, or commit a workstation's settings without explicit direction from the user.
- Keep `.vs\`, `bin\`, `obj\`, `packages\`, `*.user`, logs, output, and temporary verification directories out of changes. Some historical `.sqlproj.user` files are already tracked; do not update them just because Visual Studio did.
- Before work, inspect `git status --short`. After work, inspect it again and review `git diff --check`, `git diff -- AGENTS.md` or the task's exact paths, and `git diff --name-only`. Account for every changed path and never discard user-owned changes.
- A successful build does not authorize running the application against the configured database, publishing ClickOnce output, deploying a DACPAC, updating security records, refreshing snapshots, or printing to configured devices. Confirm the environment and obtain explicit authorization for those side effects.

## Checklist for a new Accounts feature

Use the closest existing feature as the exact template; not every feature needs every item.

1. Add or update the Accounts business object and constructor validation rules.
2. Add or update the DAO and appropriate DAO contract, keeping the reflection name `<ObjectName>Dao` when `AccountsService("<ObjectName>")` is used.
3. Add or update the presentation model and AutoMapper registrations.
4. Add or update the view interface and WinForms implementation, including the main-fields dictionary and view events.
5. Add or update the presenter using the existing base chain and table/view/sort metadata.
6. Wire presenter creation through the established `MainForm`/`RunForm` path and preserve security-key/menu behavior.
7. Add or update schema objects in the owning SQL project. Keep TVP shapes and stored-procedure parameters synchronized with the DAO/service.
8. Add new source/database files to old-style `.vbproj`/`.sqlproj` files and preserve WinForms `DependentUpon` metadata.
9. Restore/build the smallest affected graph, then the full solution when practical.
10. Smoke-test with a non-production database, including validation, security, localization, and accounting-state restrictions relevant to the feature.
