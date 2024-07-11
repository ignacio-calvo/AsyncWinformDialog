using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTestApp
{
    public partial class TouchTransactionProcess : Form
    {

        public CancellationTokenSource cancelTokenSource { get; set; }

        public TouchTransactionProcess()
        {
            InitializeComponent();
        }

        private async void cmdAction_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
            DialogResult = DialogResult.Cancel;
        }

    }
}
