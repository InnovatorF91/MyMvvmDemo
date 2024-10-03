namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// 設定モデル
    /// </summary>
    public class SettingsModel
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static SettingsModel instance;

        /// <summary>
        /// タイヤシーズン
        /// </summary>
        public string TireSeason { get; set; }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>設定モデルインスタンス</returns>
        public static SettingsModel GetInstance()
        {
            if (instance == null)
            {
                instance = new SettingsModel();
            }

            return instance;
        }
    }
}
