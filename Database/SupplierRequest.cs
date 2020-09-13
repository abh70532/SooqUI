using System;
using System.Collections.Generic;

namespace WrokFlowWeb.Database
{
    public partial class SupplierRequest
    {
        public SupplierRequest()
        {
            SupplierRequestApprovalLog = new HashSet<SupplierRequestApprovalLog>();
            SupplierRequestCategoryMapping = new HashSet<SupplierRequestCategoryMapping>();
        }

        public long SupplierRequestId { get; set; }
        public byte SuplierTypeRequestId { get; set; }
        public byte RequestTypeMasterId { get; set; }
        public string RequesterName { get; set; }
        public string Department { get; set; }
        public string SupplierName { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactPhone { get; set; }
        public bool? IsApprovalPending { get; set; }
        public int? SupplierRequestApprovalId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRejected { get; set; }

        public virtual RequestTypeMaster RequestTypeMaster { get; set; }
        public virtual SuplierTypeRequestMaster SuplierTypeRequest { get; set; }
        public virtual ICollection<SupplierRequestApprovalLog> SupplierRequestApprovalLog { get; set; }
        public virtual ICollection<SupplierRequestCategoryMapping> SupplierRequestCategoryMapping { get; set; }
    }
}
