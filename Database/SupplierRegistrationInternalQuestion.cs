using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SupplierRegistrationInternalQuestion
    {
        public long SupplierRegistrationInternalQuestionId { get; set; }
        public long SupplierRequestId { get; set; }
        public string AccountGroup { get; set; }
        public string SearchTerm { get; set; }
        public string Industry { get; set; }
        public string TrainStation { get; set; }
        public string ActualQmsystem { get; set; }
        public string ReconsiliationAccount { get; set; }
        public string CashMangementGroup { get; set; }
        public string CompanyCode { get; set; }
        public string PaymentTerm { get; set; }
        public bool? CheckDoubleInvoice { get; set; }
        public string PaymentMethod { get; set; }
        public string ClerkAbbrevation { get; set; }
        public string PurchasingOrganisation { get; set; }
        public string OrderCurreny { get; set; }
        public bool? SetIncoterm { get; set; }
        public bool? BlockForCompanyCodeAlba { get; set; }
        public bool? BlockForPurchasingOrganisation { get; set; }
        public string BlockForQualityReasons { get; set; }
    }
}
