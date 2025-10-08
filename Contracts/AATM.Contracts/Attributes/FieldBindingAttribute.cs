using System;

namespace AATM.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FieldBindingAttribute : Attribute
    {
        public string ControlName { get; }
        public string ControlProperty { get; }
        public FieldBindingAttribute(string controlName, string controlProperty = null)
        {
            ControlName = controlName;
            ControlProperty = controlProperty;
        }
    }
}   