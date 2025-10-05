using AATM.Business.Logic.Validators;
using AATM.Contracts.Interfaces.Services;
using AATM.UI.Winforms.BaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public abstract class BaseGridCrudForm<TDto> : BaseGridCrudForm
    where TDto : class, IEntityWithId, new()
{
    protected BaseGridCrudForm(string moduleName) : base(moduleName) { }

    protected virtual Func<ICrudService<TDto>> ServiceFactory
        => () => new DesignTimeCrudService() as ICrudService<TDto>;

    protected virtual Func<TDto, IEnumerable<ValidationError>> Validator => null;

    protected virtual bool AutoBind => true;
    protected virtual bool AutoInitErrorHandling => true;
    protected virtual string ErrorDisplayControlName => "txtErrors";

    protected void InitializeTypedContext()
    {
        if (AutoInitErrorHandling)
            InitializeErrorHandling(FindErrorDisplayControl());

        InitializeTypedController(ServiceFactory);

        if (AutoBind)
            AutoBindFormFields(typeof(TDto));

        if (Validator != null)
            StructuredValidator = e => Validator((TDto)e);
    }

    protected virtual Control FindErrorDisplayControl()
    {
        return Controls.Find(ErrorDisplayControlName, true).FirstOrDefault();
    }
}           