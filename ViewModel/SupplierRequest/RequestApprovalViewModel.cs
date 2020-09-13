using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.ViewModel.SupplierRequest
{
    public class RequestApprovalViewModel
    {
        [Required]
        [BindProperty]
        [DisplayName("Approve/Reject")]
        public string Approve { get; set; }

        public string[] ApproveList = new[] { "Approve", "Reject" };
        [Required]
        public string Comments { get; set; }
        public List<SupplierRequestApprovalLog> SupplierRequestApprovalLog { get; set; }
        public SupplierViewModel SupplierViewModel { get; set; }
        public InboxListViewModel InboxListViewModel { get; set; }
    }
}
    