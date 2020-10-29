    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.ViewModel.Question
{
    public class QuestionMasterViewModel
    {
        public QuestionMasterViewModel()
        {
           
        }

        [Required]
        [Display(Name = "Module")]
        public int ApprovalFormMasterId { get; set; }

        [Required]
        [Display(Name = "Tab Name")]
        public int TabMasterId { get; set; } 

        [Required]
        [Display(Name = "Control Name")]
        public int ControlMasterId { get; set; }

        [Required]
        [Display(Name = "Dropdown Source")]
        public int DataSourceMasterId { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }

        public List<TabMaster> TabMasterSource { get; set; }
        public List<DataSourceMaster> DataSourceMaster { get; set; }
        public List<ControlMaster> ControlMaster { get; set; }
    }

    public class QuestionMasterListViewModel
    {
        public long QuestionMasterId { get; set; }
        public string TabMaster { get; set; }
        public string ControlMaster { get; set; }
        public string DataSourceMaster { get; set; }
        public string QuestionText { get; set; }
    }
}
