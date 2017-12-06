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
    public partial class UcPage2 : UcBase
    {
        public UcPage2()
        {
            InitializeComponent();
        }

        private void UcPage2_Load(object sender, EventArgs e)
        {
            this.BaseInit(this.Name, "Back", this);
        }
    }
}
