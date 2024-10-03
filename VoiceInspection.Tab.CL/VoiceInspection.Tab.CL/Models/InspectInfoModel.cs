namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// 点検情報モデル
    /// </summary>
    public class InspectInfoModel
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static InspectInfoModel instance;

        /// <summary>
        /// 受付番号
        /// </summary>
        public string ReceiptNo { get; set; }

        /// <summary>
        /// 1.車検 / 2.点検
        /// </summary>
        public int? InspectType { get; set; }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>点検情報インスタンス</returns>
        public static InspectInfoModel GetInstance()
        {
            if (instance == null)
            {
                instance = new InspectInfoModel();
            }

            return instance;
        }
    }
}
