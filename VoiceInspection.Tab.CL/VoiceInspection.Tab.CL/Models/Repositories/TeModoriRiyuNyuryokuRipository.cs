using Common.Base;
using Common.Utility;
using VehicleInspection.CM.InputModel;
using VehicleInspection.CM.ResultModel;

namespace VoiceInspection.Tab.CL.Models.Repositories
{
    public class TeModoriRiyuNyuryokuRipository : RepositoryBase
    {
        public TeModoriRiyuNyuryokuRipository(IHttpUtility httpUtility) : base(httpUtility)
        {

        }



        
        public TemodoriRiyuNyuryokuResultModel InsertTemodoriRiyu(TeModoriRiyuNyuryokuInputModel inputModel)
        {
            var result = SendRequest<TeModoriRiyuNyuryokuInputModel, TemodoriRiyuNyuryokuResultModel>("api/InsertTemodoriRiyu", inputModel);

            return result;
        }
    }
}
