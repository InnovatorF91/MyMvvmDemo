using System;

namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// ログインモデル
    /// </summary>
    public class LoginModel : IDisposable
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static LoginModel instance;

        /// <summary>
        /// ユーザID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ユーザ名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 販売会社ID
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 店舗ID
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// 権限
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// 整備士タイプ
        /// </summary>
        public string MechanicType { get; set; }

        /// <summary>
        /// ログイン年月日
        /// </summary>
        public DateTime LoginDateTime { get; set; }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>ログインモデル</returns>
        public static LoginModel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginModel();
            }

            return instance;
        }

        public void Dispose()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
    }
}
