using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample.Controls
{
    public partial class UcPage1 : UcBase
    {
        public UcPage1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GetFrmMain.GoToUcPage2(this);
        }

        private void UcPage1_Load(object sender, EventArgs e)
        {
            this.BaseInit(this.Name, "End", this);
        }
    }
}
