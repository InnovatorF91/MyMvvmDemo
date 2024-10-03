using Common.Base;
using Common.Utility;
using System;
using VehicleInspection.CM.InputModel;
using VehicleInspection.CM.ResultModel;

namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// 点検履歴リポジトリ
    /// </summary>
    public class InspectionHistoryRepository : RepositoryBase
    {
        public InspectionHistoryRepository(IHttpUtility httpUtility) : base(httpUtility)
        {

        }

        /// <summary>
        /// 情報を転送し、結果を集まる処理
        /// </summary>
        /// <param name="companyId">販売会社ID</param>
        /// <param name="loginDate">ログインデータ</param>
        /// <returns>result = true : 処理成功 / result = false : 処理失敗</returns>
        public bool Authenticate(int companyId,DateTime loginDate)
        {
            bool result = false;

            var input = new InspectionHistoryInputModel();

            var inspectionHistoryModel = InspectionHistoryModel.GetInstance();

            input.CompanyId = companyId;
            input.loginDate = loginDate;

            var resultModel = GetInspectionHistory(input);

            if (resultModel.CompanyName != null)
            {
                inspectionHistoryModel.CompanyName = resultModel.CompanyName;
                inspectionHistoryModel.Comment = resultModel.Comment;
                inspectionHistoryModel.ShakenInspectionFlag = resultModel.ShakenInspectionFlag;
                inspectionHistoryModel.TorqueWrenchInputResultCategory = resultModel.TorqueWrenchInputResultCategory;
                inspectionHistoryModel.ReportSetupCategory = resultModel.ReportSetupCategory;
                inspectionHistoryModel.DeleteFlag = resultModel.DeleteFlag;
                inspectionHistoryModel.RegisteredUserId = resultModel.RegisteredUserId;
                inspectionHistoryModel.RegisteredDate = resultModel.RegisteredDate;
                inspectionHistoryModel.LastUpdateUserId = resultModel.LastUpdateUserId;
                inspectionHistoryModel.LastUpdateDate = resultModel.LastUpdateDate;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 点検履歴取得処理
        /// </summary>
        /// <param name="inputModel">点検履歴インプットモデル</param>
        /// <returns>点検履歴リザルトモデル</returns>
        private InspectionHistoryResultModel GetInspectionHistory(InspectionHistoryInputModel inputModel)
        {
            var result = SendRequest<InspectionHistoryInputModel, InspectionHistoryResultModel>("api/InspectionHistory", inputModel);
            return result;
        }
    }
}
