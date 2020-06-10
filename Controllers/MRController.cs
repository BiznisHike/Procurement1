using Repository.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Procurement.Controllers
{
    public class MRController
    {
        private _IProcurementRepository<MR> interfaceObj;
        private MR _gMRModel;
        private List<MR> _gLstMRModel;
        public MRController()
        {
            interfaceObj = new ProcurementRepository<MR>();

        }
        public MRController(MR pMRModel)
        {
            interfaceObj = new ProcurementRepository<MR>();
            _gMRModel = pMRModel;
        }
        public MRController(List<MR> pLstMRModel)
        {
            interfaceObj = new ProcurementRepository<MR>();
            _gLstMRModel = pLstMRModel;
        }
        //public Object Create()
        //{
        //    FrmProject frmProject = new FrmProject();
        //    return frmProject;
        //}
        public void Save()
        {
            interfaceObj.InsertModel(_gMRModel);
            interfaceObj.Save();
        }
        public void SaveList(string ProjectCode,decimal MRVersion)
        {
            //List<BOM> LstBoms = GetModels().AsQueryable().Where(x=>x.ProjectCode==ProjectCode && x.BOMTypeCode==bomTypeCode).ToList<BOM>(); //.Products.where(x => x.StoreId == store.StoreId)

            List<MR> LstMRs = GetModels().AsQueryable().Where(x=> x.MRVersion.ProjectCode == ProjectCode && x.Version == MRVersion).ToList<MR>(); //.Products.where(x => x.StoreId == store.StoreId)
            if (LstMRs.Count > 0)
            {
                foreach (MR MRModel in LstMRs)
                {
                    interfaceObj.DeleteModel(MRModel.RowAuto);
                }
                 
            }
            foreach (MR MRModel in _gLstMRModel)
            {
                interfaceObj.InsertModel(MRModel);
            }
             interfaceObj.Save();
            //}

        }

        public List<MR> GetModels()
        {
            return interfaceObj.GetModels().ToList<MR>();
        }
        //public MR GetModelByID(decimal projectCode)
        //{
        //    return interfaceObj.GetModelByID(projectCode);
        //}
        public void DeleteModel(decimal modelID)
        {
            interfaceObj.DeleteModel(modelID);
            interfaceObj.Save();
        }
        public MR GetModelByID(decimal modelId)
        {
            return interfaceObj.GetModelByID(modelId);
        }
    }
}
