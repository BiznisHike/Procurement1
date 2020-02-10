using Repository.DAL;
using StaticClasses;
using System.Collections.Generic;
using System.Linq;

namespace Procurement.Controllers
{
    public class MRVersionController
    {
        private _IProcurementRepository<MRVersion> interfaceObj;
        private MRVersion _gMRModel;
        public MRVersionController()
        {
            interfaceObj = new ProcurementRepository<MRVersion>();
        }
        public MRVersionController(MRVersion pMRModel)
        {
            interfaceObj = new ProcurementRepository<MRVersion>();
            _gMRModel = pMRModel;
        }
        
        //public Object Create()
        //{
        //    FrmMRVersion frmMRVersion = new FrmMRVersion();
        //    return frmMRVersion;
        //}
        public void Save()
        {
            interfaceObj.InsertModel(_gMRModel);
            interfaceObj.Save();
        }
        public MRVersion GetModelByID(decimal modelId)
        {
            return interfaceObj.GetModelByID(modelId);
        }
        public List<MRVersion> GetModels()
        {
            return interfaceObj.GetModels().ToList<MRVersion>();
            //return interfaceObj.GetModels().ToList<MRVersion>();
        }
        public void UpdateModel(MRVersion model)
        {
            interfaceObj.UpdateModel(model);
            interfaceObj.Save();
        }

       
        public decimal GetMaxMRVersionCode()
        {
            List<MRVersion> MRVersions = GetModels();
            if (MRVersions.Count == 0) ReseedPk();


            return MRVersions.DefaultIfEmpty().Max(p => p == null ? 1 : p.Version+1);
        }
        public void ReseedPk()
        {
            interfaceObj.ReseedPK("MRVersion");
        }
        public void DeleteModel(decimal modelID)
        {
            interfaceObj.DeleteModel(modelID);
            interfaceObj.Save();
        }

    }
}
