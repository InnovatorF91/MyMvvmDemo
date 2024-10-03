using System;

namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// 点検履歴モデル
    /// </summary>
    public class InspectionHistoryModel
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static  InspectionHistoryModel instance;

        /// <summary>
        /// 販売会社名
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 車検機能フラグ
        /// </summary>
        public bool ShakenInspectionFlag { get; set; }

        /// <summary>
        /// 帳票設定区分
        /// </summary>
        public string ReportSetupCategory { get; set; }

        /// <summary>
        /// ホイールナット緩みのトルクレンチ入力結果区分
        /// </summary>
        public string TorqueWrenchInputResultCategory { get; set; }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public bool DeleteFlag { get; set; }

        /// <summary>
        /// 登録ユーザID
        /// </summary>
        public int RegisteredUserId { get; set; }

        /// <summary>
        /// 登録日時
        /// </summary>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// 最終更新ユーザID
        /// </summary>
        public int LastUpdateUserId { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>点検履歴モデルインスタンス</returns>
        public static InspectionHistoryModel GetInstance()
        {
            if (instance == null )
            {
                instance = new InspectionHistoryModel();
            }

            return instance;
        }
    }
}
