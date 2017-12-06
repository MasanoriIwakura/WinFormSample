using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormSample;

namespace WinFormSample.Controls
{
    /// <summary>
    /// ユーザーコントロール基底クラス
    /// </summary>
    /// <remarks>
    /// abstractにするとデザイナーが使用できない
    /// </remarks>
    public partial class UcBase : UserControl
    {
        public UcBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 共通初期化処理
        /// </summary>
        /// <param name="title">ヘッダタイトル</param>
        /// <param name="btnTxt">戻るボタンテキスト</param>
        /// <param name="uc">表示するユーザーコントロール</param>
        protected void BaseInit(string title, string btnTxt, UserControl uc)
        {
            // 画面最大化
            this.Height = GetFrmMain.GetBodyHeight();
            this.Width = GetFrmMain.GetBodyWidth();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            // ヘッダー設定
            GetFrmMain.SetTitle(title);
            GetFrmMain.SetBackBtnText(btnTxt);

            // 遷移情報設定
            GetFrmMain.SetPageStack(uc);
        }

        /// <summary>
        /// 親フォーム
        /// </summary>
        protected FrmMain GetFrmMain = FrmMain.Instance;
    }
}
