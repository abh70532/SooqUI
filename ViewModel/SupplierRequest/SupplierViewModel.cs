using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Helper;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.ViewModel
{
    public class SupplierViewModel
    {
        public long SupplierRequestId { get; set; }
        public long SupplierRequestCode { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Select SuplierType Request")]
        [DisplayName("Suplier Type")]
        public byte SuplierTypeRequestId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Select Request Type")]
        [DisplayName("Request Type")]
        public byte RequestTypeMasterId { get; set; }
        [Required]
        [DisplayName("Requester Name")]
        public string RequesterName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [Required]

        public string Country { get; set; }
        [Required]
        [DisplayName("Primary Contact Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Primary Contact Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string EmailId { get; set; }
        [Required]
        [DisplayName("Contact No")]
        public string ContactPhone { get; set; }

        public List<RequestTypeMaster> RequestTypeMaster { get; set; }
        public virtual List<SuplierTypeRequestMaster> SuplierTypeRequest { get; set; }
        [DisplayName("Category")]
        public List<CategoryMasterViewModel> CategoryMaster { get; set; }

        public string CategoryMasterNames { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}