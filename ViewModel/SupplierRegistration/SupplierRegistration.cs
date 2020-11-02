using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.ViewModel.SupplierRequest;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.ViewModel.SupplierRegistration
{
    public class SupplierRegistration
    {
        public SupplierRegistration()
        {
            TabNames = new List<TabModel>();
            SuppilerListViewModels = new List<SuppilerListViewModel>();
        }

        [Required]
        [DisplayName("Supplier")]
        public long SupplierRequestId { get; set; }
        public List<SuppilerListViewModel> SuppilerListViewModels { get; set; }
        public List<TabModel> TabNames { get; set; }
    }

    public class QuestionModel
    {
        public QuestionModel()
        {
            DataSource = new List<DropdownSource>();
        }
        public long QuestionMasterId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionComment { get; set; }
        public string QuestionControlType { get; set; }
        public string QuestionAnswer { get; set; }
        public List<DropdownSource> DataSource { get; set; }
        public long SelectedValue { get; set; }
    }
    public class AnswerModel
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class TabModel
    {
        public TabModel()
        {
            Questions = new List<QuestionModel>();
        }
        public int TabId { get; set; }
        public string Tabname { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }

    public class DropdownSource
    {
        public long Id { get; set; }
        public string Text { get; set; }

    }

    public  class SupplierRegistrationInternalQuestionViewModel
    {
        public long SupplierRegistrationInternalQuestionId { get; set; }
        public long SupplierRequestId { get; set; }
        public string AccountGroup { get; set; } = "A001";
        public string SearchTerm { get; set; }
        public string Industry { get; set; }
        public string TrainStation { get; set; }
        public string ActualQmsystem { get; set; } = "CR";
        public string ReconsiliationAccount { get; set; }
        public string CashMangementGroup { get; set; } = "A1";
        public string CompanyCode { get; set; } = "ALBA";
        public string PaymentTerm { get; set; } = "A430";
        public bool? CheckDoubleInvoice { get; set; }
        public string PaymentMethod { get; set; }
        public string ClerkAbbrevation { get; set; }
        public string PurchasingOrganisation { get; set; }
        public string OrderCurreny { get; set; } = "BHD";
        public bool? SetIncoterm { get; set; }
        public bool? BlockForCompanyCodeAlba { get; set; }
        public bool? BlockForPurchasingOrganisation { get; set; }
        public string BlockForQualityReasons { get; set; }
    }

    public class SyncSAPViewModel
    {
        public string SupplierRequestId { get; set; }
       
    }
}
