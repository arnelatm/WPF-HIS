using System;
using System.Collections.Generic;

namespace AATM.Accounts.PresentationLayer.Forms
{
    public partial class BankEntryTv : PresentationLayer.Views.IBankView
    {
        public BankEntryTv() : base()
        {
            // This call is required by the designer.
            this.InitializeComponent();
            this.MainTableName = "Bank";
            this.TvMainFieldName = "BankName";
            this.TvSecondaryFieldName = "BankCode";
            this.SortOrderKey = "BankName";
            this.FirstControl = this.txtBankCode;
            this.PresenterObj = new PresentationLayer.Presenters.BankPresenter(this);
            this.Ea = (Libraries.EventAggregator)this.PresenterObj.Ea;
            this.Ea.SubscribeEvent(this);
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public int IdNo
        {
            get
            {
                string argnumString = this.TxtIdNo.Text;
                return NumParser<int>(ref argnumString);
                this.TxtIdNo.Text = argnumString;
            }

            set
            {
                this.TxtIdNo.Text = Convert.ToString(value);
            }
        }

        public string BankCode
        {
            get
            {
                return this.txtBankCode.Text;
            }

            set
            {
                this.txtBankCode.Text = value;
            }
        }

        public string BankName
        {
            get
            {
                return this.txtBankName.Text;
            }

            set
            {
                this.txtBankName.Text = value;
            }
        }

        public string BankNameAra
        {
            get
            {
                return this.txtBankNameAra.Text;
            }

            set
            {
                this.txtBankNameAra.Text = value;
            }
        }

        public string Notes
        {
            get
            {
                return this.txtNotes.Text;
            }

            set
            {
                this.txtNotes.Text = value;
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        protected override void CreateFieldsDictionary()
        {
            this.FieldsDictionary = new Dictionary<string, object>() { { "BankCode", this.txtBankCode }, { "BankName", this.txtBankName }, { "BankNameAra", this.txtBankNameAra }, { "IdNo", this.TxtIdNo }, { "Notes", this.txtNotes } };
        }
    }
}