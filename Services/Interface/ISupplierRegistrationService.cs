using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.ViewModel.Question;
using WrokFlowWeb.ViewModel.SupplierRegistration;

namespace WrokFlowWeb.Services.Interface
{
    public interface ISupplierRegistrationService
    {
        //Task AddQuestionMaster(QuestionMasterViewModel questionMaster);
        //Task<long> AddQuestionMaster(QuestionMasterViewModel questionMaster);
        //long AddQuestionMaster(QuestionMasterViewModel questionMaster);
        Task<long> AddQuestionMaster(QuestionMasterViewModel questionMaster);
        bool CheckLoadDataSource(int controlId);
        SupplierRegistration GetAllQuestionByModule(int moduleId);

        //Task<List<QuestionMaster>> GetAllQuestions();
        List<QuestionMaster> GetAllQuestions();
        QuestionMasterViewModel GetQuestionMasterViewModel();
        List<TabMaster> LoadTabDetails(int moduleId);
        //Task<QuestionMasterViewModel> GetQuestionMasterViewModel();
    }
}
