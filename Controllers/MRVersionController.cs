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
            return interfaceObj.GetModels().Where(x => x.ProjectCode == CurrentOpenProject.CurrentProject.ProjectCode).ToList<MRVersion>();
            //return interfaceObj.GetModels().ToList<MRVersion>();
        }
        public void UpdateModel(MRVersion model)
        {
            interfaceObj.UpdateModel(model);
            interfaceObj.Save();
        }


        public decimal GetMaxMRVersionAutoRowId()
        {
            List<MRVersion> MRVersions = interfaceObj.GetModels().ToList<MRVersion>();
            if (MRVersions.Count == 0) ReseedPk();


            return MRVersions.DefaultIfEmpty().Max(p => p == null ? 1 : p.Id + 1);
        }

        public decimal GetMaxMRVersionNo(bool IsVersion,string VersionNo)
        {
            //List<MRVersion> MRVersions = GetModels().Where(x => x.ProjectCode == CurrentOpenProject.CurrentProject.ProjectCode && x.VersionNo.StartsWith(VersionNo) && !x.VersionNo.Contains("-REV")).ToList<MRVersion>();
            List<MRVersion> MRVersions = GetModels().Where(x => x.ProjectCode == CurrentOpenProject.CurrentProject.ProjectCode && x.VersionNo.StartsWith(VersionNo) && x.IsVersion == IsVersion).ToList<MRVersion>();
            if (MRVersions.Count == 0)
            {
                return 1;
            }
            else
            {
                return MRVersions.Count + 1;
            }



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
