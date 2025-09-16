using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Winforms.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FrmCustomer m_FrmCustomer;

            public FrmCustomer FrmCustomer
            {
                [DebuggerHidden]
                get
                {
                    m_FrmCustomer = Create__Instance__(m_FrmCustomer);
                    return m_FrmCustomer;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_FrmCustomer))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FrmCustomer);
                }
            }

        }


    }
}