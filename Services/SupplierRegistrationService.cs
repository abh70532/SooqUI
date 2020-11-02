using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.UnitOfWork;
using WrokFlowWeb.ViewModel.Question;
using WrokFlowWeb.ViewModel.SupplierRegistration;
using WrokFlowWeb.ViewModel.SupplierRequest;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.Services
{
    public class SupplierRegistrationService : ISupplierRegistrationService
    {
        private readonly IUnitOfWork _context;
        private readonly ISupplierRequestService supplierRequestService;

        public SupplierRegistrationService(IUnitOfWork Context,ISupplierRequestService supplierRequestService)
        {
            this._context = Context;
            this.supplierRequestService = supplierRequestService;
        }

        public QuestionMasterViewModel GetQuestionMasterViewModel()
        {
            var approvalFormMaster = this._context.ApprovalFormMasterRepository.GetAllApprovalModules().Result;
            var controlMaster =  this._context.ControlMasterRepository.GetAllControls().Result;
            var tabMasterSource =  this._context.TabMasterRepository.GetAllTabSource().Result;
            var dataSourceMaster =  this._context.DataSourceMasterRepository.GetAllDataSource().Result;
            var questionViewmodel = new QuestionMasterViewModel
            {
                ApprovalFormMasterId = 1,
                ApprovalFormMaster= approvalFormMaster,
                //TabMasterSource = tabMasterSource,
                ControlMaster = controlMaster,
                DataSourceMaster = dataSourceMaster
            };
            questionViewmodel.TabMasterSource = tabMasterSource.Where(x => x.ApprovalFormMasterId == questionViewmodel.ApprovalFormMasterId).ToList();
            return questionViewmodel;
        }

        public List<TabMaster> LoadTabDetails(int moduleId)
        {
            var tabMasterSource = this._context.TabMasterRepository.GetAllTabSource().Result;
            return tabMasterSource.Where(x => x.ApprovalFormMasterId == moduleId).ToList();
        }

        public bool CheckLoadDataSource(int controlId)
        {
            var controlMaster = this._context.ControlMasterRepository.GetAllControls().Result;
            return controlMaster.Where(x => x.ControlMasterId == controlId).FirstOrDefault().IsDataSource.Value ? true : false;
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

        public SupplierRegistration GetAllQuestionByModule(int moduleId)
        {
            var suppliers = supplierRequestService.GetSupplierRequestMaster().Result;
            List<SuppilerListViewModel> suppilerListViewModels = new List<SuppilerListViewModel>();
            suppliers.ForEach(item => {
                suppilerListViewModels.Add(new SuppilerListViewModel()
                {
                    SupplierRequestId = item.SupplierRequestId,
                    SupplierName = string.Join('-', item.SupplierName, item.SupplierRequestId)
                });
            });

            SupplierRegistration supplierRegistration = new SupplierRegistration
            {
                SuppilerListViewModels = suppilerListViewModels
            };
            var questionModels = new List<QuestionModel>();
            var response = this._context.QuestionMasterRepository.GetAllQuestionByModule(moduleId).Result;
            foreach (var item in response.Select(x=>x.TabMaster).Distinct().ToList())
            {
                supplierRegistration.TabNames.Add(new TabModel()
                {
                    TabId = item.TabMasterId,
                    Tabname = item.TabMasterName
                });
            }

           foreach (var item in response)
            {
               var tab =  supplierRegistration.TabNames.Where(x => x.Tabname == item.TabMaster.TabMasterName).FirstOrDefault();
                tab.Questions.Add(new QuestionModel()
                {
                    QuestionMasterId = item.QuestionMasterId,
                    QuestionText = item.QuestionText,
                    QuestionControlType = item.ControlMaster.ControlName
                });

                var dataSource = item.ControlMaster.IsDataSource.Value ? 
                    this._context.DataSourceMasterRepository.GetAllDataSourceBySourceid(item.DataSourceMasterId.Value).Result : new List<SourceMaster>();
                foreach (var sourceMaster in dataSource)
                {
                    tab.Questions[tab.Questions.Count - 1].DataSource.Add(new DropdownSource() { 
                        Id  = sourceMaster.DataSourceMasterId,
                        Text = sourceMaster.Text
                    });
                }
                
            }
            return supplierRegistration;
        }


    }
}
