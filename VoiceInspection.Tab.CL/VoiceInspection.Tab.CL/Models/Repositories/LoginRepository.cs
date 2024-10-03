using Common.Base;
using Common.Utility;
using VehicleInspectionWebApp.Models;

namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// ログインリポジトリ
    /// </summary>
    public class LoginRepository : RepositoryBase
    {
        public LoginRepository(IHttpUtility httpUtility) : base(httpUtility)
        {

        }

        /// <summary>
        /// 情報を転送し、結果を集まる処理
        /// </summary>
        /// <param name="username">ユーザID</param>
        /// <param name="password">パスワード</param>
        /// <returns>result = true : 処理成功 / result = false : 処理失敗</returns>
        public bool Authenticate(string username, string password)
        {
            // 実際の認証ロジックをここに実装
            var result = false;

            var input = new GetUserInfoInputModel();

            var loginModel = LoginModel.GetInstance();

            input.Id = username;
            input.Password = password;

            var resultModel = GetUserInfo(input);

            if (resultModel.UserName != null)
            {
                loginModel.UserId = resultModel.UserId;
                loginModel.UserName = resultModel.UserName;
                loginModel.CompanyId = resultModel.CompanyId;
                loginModel.StoreId = resultModel.StoreId;
                loginModel.Authorization = resultModel.Authorization;
                loginModel.MechanicType = resultModel.MechanicType;
                loginModel.LoginDateTime = resultModel.LoginDateTime;

                result = true;
            }

            return result;// ダミー実装
        }

        /// <summary>
        /// ユーザ情報取得処理
        /// </summary>
        /// <param name="inputModel">ユーザ情報インプットモデル</param>
        /// <returns>ユーザ情報リザルトモデル</returns>
        private GetUserInfoResultModel GetUserInfo(GetUserInfoInputModel inputModel)
        {
            GetUserInfoResultModel result = SendRequest<GetUserInfoInputModel, GetUserInfoResultModel>("api/values", inputModel);
            return result;
        }
    }
}
