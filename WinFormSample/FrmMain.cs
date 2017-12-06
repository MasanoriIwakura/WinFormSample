using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormSample.Common;
using WinFormSample.Controls;

namespace WinFormSample
{
    /// <summary>
    /// Windows Form 画面遷移サンプル
    /// </summary>
    public partial class FrmMain : Form
    {
        private static FrmMain _instance;
        private static object lockObj = new object();

        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 画面遷移情報保持用
        /// </summary>
        private static Stack<UserControl> pageStack = new Stack<UserControl>();

        #region Pages

        private UcPage1 ucPage1;
        public UcPage1 GetUcPage1() { return ucPage1; }

        private UcPage2 ucPage2;
        public UcPage2 GetUcPage2() { return ucPage2; }

        #endregion

        /// <summary>
        /// シングルトン
        /// </summary>
        public static FrmMain Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new FrmMain();
                    }
                }

                return _instance;
            }
        }

        private FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            logger.Info(CommonConst.Log.START);

            // ロード時に初期化しておく
            // Note.
            //  画面多くなるならプログレスバー作ったほうが良いかも
            ucPage1 = new UcPage1();
            ucPage2 = new UcPage2();

            // 著作権情報取得
            var assembly = Assembly.GetEntryAssembly();
            AssemblyCopyrightAttribute[] copyrightAttributes = (AssemblyCopyrightAttribute[])assembly
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            this.LblCopyright.Text = copyrightAttributes[0].Copyright;

            this.PnlBody.Controls.Add(ucPage1);

            logger.Info(CommonConst.Log.END);
        }

        /// <summary>
        /// 戻るボタンアクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            logger.Info(CommonConst.Log.START);

            if (1 < pageStack.Count)
            {
                var nowUc = pageStack.Pop();
                var prevUc = pageStack.Peek();

                nowUc.Visible = false;
                prevUc.Visible = true;
            }
            else
            {
                Application.Exit();
            }

            logger.Info(CommonConst.Log.END);
        }

        /// <summary>
        /// ボディ部高さ取得
        /// </summary>
        /// <remarks>
        /// ユーザーコントロール高さ設定用
        /// </remarks>
        /// <returns></returns>
        public int GetBodyHeight()
        {
            return this.PnlBody.Height;
        }

        /// <summary>
        /// ボディ部横幅取得
        /// </summary>
        /// <remarks>
        /// ユーザーコントロール幅設定用
        /// </remarks>
        /// <returns></returns>
        public int GetBodyWidth()
        {
            return this.PnlBody.Width;
        }

        public void SetTitle(string title)
        {
            this.LblTitle.Text = title;
        }

        public void SetBackBtnText(string txt)
        {
            this.BtnBack.Text = txt;
        }

        public void SetPageStack(UserControl uc)
        {
            pageStack.Push(uc);
        }

        #region 画面遷移

        public void GoToUcPage2(UserControl uc)
        {
            logger.Info(CommonConst.Log.START);

            this.PnlBody.Controls.Add(ucPage2);

            logger.Info(CommonConst.Log.END);
        }

        #endregion
    }
}
