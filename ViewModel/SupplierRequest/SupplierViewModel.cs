using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Helper;

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
        [RequiredIf("RequestTypeMasterId", 2)]
        public string RequesterName { get; set; }
        [RequiredIf("RequestTypeMasterId", 2)]
        public string Department { get; set; }
        [Required]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public string ContactPhone { get; set; }

        public  List<RequestTypeMaster> RequestTypeMaster { get; set; }
        public virtual List<SuplierTypeRequestMaster> SuplierTypeRequest { get; set; }
    }
}
