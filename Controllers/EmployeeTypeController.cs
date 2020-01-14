using Repository.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Procurement.Controllers
{
    public class EmployeeTypeController
    {
        private _IProcurementRepository<EmployeeType> interfaceObj;
        private EmployeeType _gEmpModel;
        public EmployeeTypeController()
        {
            interfaceObj = new ProcurementRepository<EmployeeType>();
        }
        public EmployeeTypeController(EmployeeType pEmpModel)
        {
            interfaceObj = new ProcurementRepository<EmployeeType>();
            _gEmpModel = pEmpModel;
        }
        
        //public Object Create()
        //{
        //    FrmProject frmProject = new FrmProject();
        //    return frmProject;
        //}
        public void Save()
        {
            interfaceObj.InsertModel(_gEmpModel);
            interfaceObj.Save();
        }
        public EmployeeType GetModelByID(decimal modelId)
        {
            return interfaceObj.GetModelByID(modelId);
        }
        public List<EmployeeType> GetModels()
        {
            return interfaceObj.GetModels().ToList<EmployeeType>();
        }
        public void UpdateModel(EmployeeType model)
        {
            interfaceObj.UpdateModel(model);
            interfaceObj.Save();
        }

        //public void GetMaxProjectCode()
        //{
        //    //interfaceObj.GetModels()

        //    //    public void GetMaxProjectCode()
        //    //{
        //    //    //interfaceObj.GetMaxProjectCode();
        //    //    int maxId = dbEntity.DefaultIfEmpty().Max(p => p == null ? 0 : p.);

        //    //}

        //}
        public decimal GetMaxCode()
        {
            List<EmployeeType> Projects = GetModels();
            return Projects.DefaultIfEmpty().Max(p => p == null ? 1 : p.EmployeeTypeCode+1);
        }
        public void ReseedProjectPk()
        {
            interfaceObj.ReseedPK("EmployeeType");
        }
        public void DeleteModel(decimal modelID)
        {
            interfaceObj.DeleteModel(modelID);
            interfaceObj.Save();
        }

    }
}
