using System;

namespace AATM.Contracts.Attributes
{
    /// <summary>
    /// Maps a DTO property to a UI control using the control's TYPE NAME and FIELD NAME.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FieldControlAttribute : Attribute
    {
        public string ControlTypeName { get; }
        public string ControlName { get; }

        // ** [CHANGE]: Use string for TypeName instead of Type **
        public FieldControlAttribute(string controlTypeName, string controlName)
        {
            ControlTypeName = controlTypeName;
            ControlName = controlName;
        }
    }
}

//namespace AATM.Contracts.Attributes
//{
//    /// <summary>
//    /// Maps a DTO property to a WinForms control by its private/protected field name.
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
//    public class FieldControlAttribute : Attribute
//    {
//        public string ControlName { get; }
//        public Type ControlType { get; }

//        public FieldControlAttribute(Type controlType, string controlName)
//        {
//            ControlType = controlType;
//            ControlName = controlName;
//        }
//    }
//}