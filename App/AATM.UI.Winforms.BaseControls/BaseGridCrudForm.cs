using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

// Change the accessibility of DesignTimeCrudService from internal sealed to public sealed
public sealed class DesignTimeCrudService : ICrudService<T>
{
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default) => Task.FromResult((IReadOnlyList<T>)new List<T>());
    public Task<T> GetByIdAsync(int id, CancellationToken ct = default) => Task.FromResult<T>(null);
    public Task<T> UpsertAsync(T dto, CancellationToken ct = default) => Task.FromResult(dto);
    public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => Task.FromResult(false);
}

protected void InitializeLanguageHelperIfNeeded()
{
    if (!_languageUiNeedsInit) return;
    if (_langHelper != null) return;
    if (_languageCombo == null) return; // safety

    _langHelper = new LanguageUiHelper(() => _localizationService, () => _dataGridView, OnAfterLanguageApplied);
    _langHelper.PopulateLanguages(_languageCombo);
    _languageCombo.SelectedIndexChanged += (s, e) => _langHelper.ApplySelectedLanguage(this, _languageCombo);
    _applyLangButton.Click += (s, e) => _langHelper.ApplySelectedLanguage(this, _languageCombo);
    _languageUiNeedsInit = false;
}

protected void OnAfterLanguageApplied(string code)
{
    ApplyLayoutDirectionFromLocalization();
    statusLabel.Text = $"Language applied: {code}";
}

protected void ApplyLayoutDirectionFromLocalization()
{
    if (_localizationService == null) return;

    bool rtl = _localizationService.IsRightToLeft;

    SuspendLayout();
    try
    {
        RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No;
        RightToLeftLayout = rtl;

        foreach (Control c in Controls)
        {
            if (c.RightToLeft != RightToLeft.Inherit && c.RightToLeft != RightToLeft)
                c.RightToLeft = RightToLeft.Inherit;
        }
    }
    finally
    {
        ResumeLayout(true);
    }
    // Optional: RtlLayoutApplier.Apply(this, _localizationService);
}

protected ILocalizationService ResolveLocalizationService()
    => new LocalizationService(_languageCombo?.SelectedItem is LanguageUiHelper.LanguageItem li ? li.Code : "en-US", Name);

protected IUiLocalizationManager ResolveUiLocalizationManager()
    => new InMemoryUiLocalizationManager();