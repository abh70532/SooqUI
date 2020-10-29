using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel.Question;

namespace WrokFlowWeb.Services
{
    public class SupplierRegistrationService : ISupplierRegistrationService
    {
        private readonly IUnitOfWork _context;
        public SupplierRegistrationService(IUnitOfWork Context)
        {
            this._context = Context;
        }

        public QuestionMasterViewModel GetQuestionMasterViewModel()
        {
            var controlMaster =  this._context.ControlMasterRepository.GetAllControls().Result;
            var tabMasterSource =  this._context.TabMasterRepository.GetAllTabSource().Result;
            var dataSourceMaster =  this._context.DataSourceMasterRepository.GetAllDataSource().Result;
            var questionViewmodel = new QuestionMasterViewModel
            {
                ControlMaster = controlMaster,
                TabMasterSource = tabMasterSource,
                DataSourceMaster = dataSourceMaster
            };
            return questionViewmodel;
        }

        public async Task<long> AddQuestionMaster(QuestionMasterViewModel questionMaster)
        {
            this._context.QuestionMasterRepository.Add(new Database.QuestionMaster() { 
                 ControlMasterId = questionMaster.ControlMasterId,
                 DataSourceMasterId = questionMaster.DataSourceMasterId,
                 TabMasterId = questionMaster.TabMasterId,
                 QuestionText = questionMaster.QuestionText,
                 IsActive = true
            });
           return this._context.CompleteAsync().Result;
        }


        public  List<QuestionMaster> GetAllQuestions()
        {
           return  this._context.QuestionMasterRepository.GetAllQuestion().Result;
        }


    }
}
