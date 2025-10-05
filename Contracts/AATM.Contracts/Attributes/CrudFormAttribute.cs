using System;

namespace AATM.Contracts.Attributes
{
    /// <summary>
    /// Declarative configuration for a CRUD form derived from BaseGridCrudForm.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CrudFormAttribute : Attribute
    {
        public CrudFormAttribute(Type serviceType)
        {
            ServiceType = serviceType ?? throw new ArgumentNullException(nameof(serviceType));
        }

        /// <summary>
        /// Required: concrete ICrudService&lt;TDto&gt; type (must have public parameterless ctor).
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Optional: Type that exposes a static Rules property or field used by DtoValidator.
        /// </summary>
        public Type ValidatorRulesType { get; set; }

        /// <summary>
        /// If true (default) auto-bind fields via FieldControlAttribute.
        /// </summary>
        public bool AutoBindFields { get; set; } = true;

        /// <summary>
        /// Optional name of a control field on the Form to display aggregated validation errors.
        /// </summary>
        public string ErrorDisplayControlName { get; set; }
    }
}   