using Repository.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Procurement.Controllers
{
    public class ProjectEmployeeDetailController
    {
        private _IProcurementRepository<ProjectEmployeeDetail> interfaceObj;
        private ProjectEmployeeDetail _gPedModel;
        private List<ProjectEmployeeDetail> _gLstPedModel;
        public ProjectEmployeeDetailController()
        {
            interfaceObj = new ProcurementRepository<ProjectEmployeeDetail>();

        }
        public ProjectEmployeeDetailController(ProjectEmployeeDetail _pPedModel)
        {
            interfaceObj = new ProcurementRepository<ProjectEmployeeDetail>();
            _gPedModel = _pPedModel;
        }
        public ProjectEmployeeDetailController(List<ProjectEmployeeDetail> pLstPedModel)
        {
            interfaceObj = new ProcurementRepository<ProjectEmployeeDetail>();
            _gLstPedModel = pLstPedModel;
        }
        //public Object Create()
        //{
        //    FrmProject frmProject = new FrmProject();
        //    return frmProject;
        //}
        public void Save()
        {
            interfaceObj.InsertModel(_gPedModel);
            interfaceObj.Save();
        }
        public void SaveList(decimal pEmployeeCode)
        {
            //if (ModelState.IsValid)
            //{ 
            //interfaceObj.DeleteModel(ProjectCode);
             List<ProjectEmployeeDetail> LstPed = GetModels(pEmployeeCode); //.Products.where(x => x.StoreId == store.StoreId)
            if (LstPed.Count > 0)
            {
                foreach (ProjectEmployeeDetail pedModel in LstPed)
                {
                    interfaceObj.DeleteModel(pedModel.Id);
                }
                 
            }
            foreach (ProjectEmployeeDetail pedModel in _gLstPedModel)
            {
                interfaceObj.InsertModel(pedModel);
            }
            interfaceObj.Save();
            //}

        }

        public List<ProjectEmployeeDetail> GetModels(decimal pEmployeeCode)
        {
            return interfaceObj.GetModels().Where(x=>x.EmployeeCode== pEmployeeCode).AsQueryable().ToList<ProjectEmployeeDetail>();
        }
        //public ProjectEmployeeDetail GetModelByID(decimal projectCode)
        //{
        //    return interfaceObj.GetModelByID(projectCode);
        //}
    }
}
