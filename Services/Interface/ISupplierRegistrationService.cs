using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel.Question;

namespace WrokFlowWeb.Services.Interface
{
    public interface ISupplierRegistrationService
    {
        //Task AddQuestionMaster(QuestionMasterViewModel questionMaster);
        //Task<long> AddQuestionMaster(QuestionMasterViewModel questionMaster);
        //long AddQuestionMaster(QuestionMasterViewModel questionMaster);
        Task<long> AddQuestionMaster(QuestionMasterViewModel questionMaster);
        //Task<List<QuestionMaster>> GetAllQuestions();
        List<QuestionMaster> GetAllQuestions();
        QuestionMasterViewModel GetQuestionMasterViewModel();
        //Task<QuestionMasterViewModel> GetQuestionMasterViewModel();
    }
}
