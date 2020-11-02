using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;

namespace WrokFlowWeb.Repository.Interface
{
   public interface IQuestionMasterRepository
    {
        void Add(QuestionMaster questionMaster);
        Task<List<QuestionMaster>> GetAllQuestion();
        Task<List<QuestionMaster>> GetAllQuestionByModule(int moduleId);
    }
}
