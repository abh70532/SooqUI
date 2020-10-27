using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.ViewModel.SupplierRegistration
{
    public class SupplierRegistration
    {
        public List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public string QuestionComment { get; set; }
        public Controls QuestionControlType { get; set; }
        public string QuestionAnswer { get; set; }
        public List<DropdownSource> DataSource { get; set; }
        public long SelectedValue { get; set; }
    }
    public class AnswerModel
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class DropdownSource
    {
        public long Id { get; set; }
        public string Text { get; set; }
    }
}
