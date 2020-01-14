using Repository.DAL;
using StaticClasses;
using System.Collections.Generic;
using System.Linq;

namespace Procurement.Controllers
{
    public class EmployeeController
    {
        private _IProcurementRepository<Employee> interfaceObj;
        private Employee _gEmpModel;
        public EmployeeController()
        {
            interfaceObj = new ProcurementRepository<Employee>();
        }
        public EmployeeController(Employee pEmpModel)
        {
            interfaceObj = new ProcurementRepository<Employee>();
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
        public Employee GetModelByID(decimal modelId)
        {
            return interfaceObj.GetModelByID(modelId);
        }
        public List<Employee> GetModels()
        {
            
            return interfaceObj.GetModels().ToList<Employee>();
        }
        public List<Employee> GetModelsByCreatedBy()
        {
            //return GetModels().ToList<Employee>().Where(x => x.EmployeeCode == LoginInfo.LoginEmployee.EmployeeCode || x.EmployeeTypeCode == Constants.EMPLOYEE).ToList<Employee>();
            return GetModels().ToList<Employee>().Where(x => x.EmployeeCode == LoginInfo.LoginEmployee.EmployeeCode || x.CreatedBy == LoginInfo.LoginEmployee.EmployeeCode).ToList<Employee>();
            //return interfaceObj.GetModels().ToList<Employee>();
        }

        public void UpdateModel(Employee model)
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
            List<Employee> Projects = GetModels();
            return Projects.DefaultIfEmpty().Max(p => p == null ? 1 : p.EmployeeCode+1);
        }
        public void ReseedPk()
        {
            interfaceObj.ReseedPK("Employee");
        }
        public void DeleteModel(decimal modelID)
        {
            interfaceObj.DeleteModel(modelID);
            interfaceObj.Save();
        }

    }
}
