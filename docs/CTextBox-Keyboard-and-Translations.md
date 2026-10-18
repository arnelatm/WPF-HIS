# CTextBox keyboard and menu translations

## Keyboard behavior

The shared textbox uses normal WinForms focus navigation instead of sending a
synthetic Tab key. An unmodified Enter moves to the next control when
`AcceptsReturn=False` and the form has no default button. Existing key handlers
run first and can consume the key. Validation can prevent the focus change.

Tab/Shift+Tab, modified Enter, multiline input with `AcceptsReturn=True`, default
buttons, and DataGridView editing-control key ownership retain normal handling.
Composite controls with their own key handlers continue to own those handlers.

## Translation lookup

Only the seven built-in CTextBox menu captions use this new lookup. Existing
form-caption and message translation paths remain in place.

1. At runtime, database translations for the current UI culture take precedence.
2. A missing/empty translation or unavailable database uses embedded language
   resources. English and Arabic are supplied, with original English text as the
   final fallback.
3. The Visual Studio designer and control/menu construction perform no caption
   database lookup. Runtime lookup happens when the owned menu opens.

The original English caption strings remain the database keys. No existing
caption identifiers, translations, or user permissions are replaced. When a
runtime lookup discovers a new original caption, it registers that caption for
the existing translation screens without overwriting existing records. A
read-only connection can still use translations already present.

Overrides are cached by database context, UI culture, and caption group for one
minute. Local saves/deletes through the caption presenters and Translation Table
Manager invalidate this cache immediately; the revised text appears on the next
menu opening. Other workstations' changes appear after cache expiry. Failed
lookups have a five-second retry cooldown. `ControlCaptionTranslations.Invalidate`
is also available to an explicit application refresh action.

The lookup batches the captions, uses parameterized SQL, bounds connection and
command timeouts to two seconds, and falls back without database-error dialogs.
Registration stops after the first database error rather than repeating failed
writes for every missing caption.

## Verification and deployment

Offline checks cover keyboard preprocessing/native input, validation, default
buttons, multiline and grid ownership, resource fallback, database overrides
using an in-memory backend, language changes, cache expiry/invalidation,
connection-context separation, and nested designer sites. The earlier textbox,
login, and combo compatibility probes are also used for regression checks.

The control library and Accounts are built with full MSBuild into an ignored,
isolated output directory; Accounts manifest signing is disabled for validation
only. No translation query, caption registration, schema change, authentication,
or other database operation is executed against an installed database during
these checks. No output is deployed.

Before deployment, manually verify a translation save/delete in an authorized
non-production database, reopen an existing textbox menu, switch English/Arabic,
and check the Visual Studio designer. The updated MessagingLibrary,
CBaseControlsLibrary, Forms, Common, and Arabic satellite resources must be
distributed together through the normal application deployment process.
