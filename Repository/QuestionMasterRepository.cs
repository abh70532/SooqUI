using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Repository.Interface;

namespace WrokFlowWeb.Repository
{
    public class QuestionMasterRepository:IQuestionMasterRepository
    {
        private readonly WrokFlowWebEntityContext context;
        public QuestionMasterRepository(WrokFlowWebEntityContext dbContext)
        {
            this.context = dbContext;
        }

        public void Add(QuestionMaster questionMaster)
        {
            context.QuestionMaster.Add(questionMaster);
        }

        public Task<List<QuestionMaster>> GetAllQuestion()
        {
            return context.QuestionMaster.Where(x=>x.IsActive.HasValue).Include(x=>x.TabMaster).ThenInclude(y=>y.ApprovalFormMaster).Include(x=>x.ControlMaster).Include(x=>x.DataSourceMaster).ToListAsync();
        }

        public Task<List<QuestionMaster>> GetAllQuestionByModule(int moduleId)
        {
            return context.QuestionMaster.Include(x => x.TabMaster).ThenInclude(y => y.ApprovalFormMaster).
                Include(x => x.ControlMaster).Include(x => x.DataSourceMaster).Where(x => x.IsActive.HasValue && x.TabMaster.ApprovalFormMasterId == moduleId).OrderBy(x=>x.TabMaster.TabMasterName)
                .ToListAsync();
        }
    }
}
