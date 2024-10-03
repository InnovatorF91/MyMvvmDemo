using System;

namespace VoiceInspection.Tab.CL.Models
{
    /// <summary>
    /// QRコードモデル
    /// </summary>
    public class QRCodeModel : IDisposable
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static QRCodeModel instance;

        /// <summary>
        /// QRコード
        /// </summary>
        public string QRcode { get; set; }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>QRコードモデルインスタンス</returns>
        public static QRCodeModel GetInstance()
        {
            if (instance == null)
            {
                instance = new QRCodeModel();
            }

            return instance;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        public void Dispose()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
    }
}
