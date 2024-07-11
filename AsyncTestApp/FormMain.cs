using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async Task<DialogResult> ShowDialogAsync(TouchTransactionProcess tbxCancel, CWindowWrapper parentOwner, CancellationTokenSource cancelTokenSource)
        {
            await Task.Yield();
                        
            return tbxCancel.ShowDialog(parentOwner);
        }

        private async void btnStart_ClickAsync(object sender, EventArgs e)
        {

            int workResult = 0;
            try
            {
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource(); //set source for cancellation

                IntPtr iPtr = new IntPtr(this.Handle.ToInt32()); //get handler for parent
                CWindowWrapper oWindWrapper = new CWindowWrapper(iPtr); //set handler in proper type
                TouchTransactionProcess tbxCancel = new TouchTransactionProcess();
                tbxCancel.cancelTokenSource = cancelTokenSource; //pass by cancellation token source

                ShowDialogAsync(tbxCancel, oWindWrapper, cancelTokenSource);                


                try
                {
                    string result = await SymulateWorkAsync(cancelTokenSource.Token);
                    tbxCancel.Close();
                    MessageBox.Show("Result: " + result);
                }
                catch (Exception)
                {
                    
                }
                finally
                {

                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {

            }
        }

        private async Task<String> SymulateWorkAsync(CancellationToken ct)
        {
            //ct.ThrowIfCancellationRequested();

            for (int i = 0; i < 10; i++)
            {
                if (ct.IsCancellationRequested)
                    return "Task cancelled on attempt #" + i.ToString();
                else
                    await Task.Delay(1000);
            }            
            return "Task completed!";
        }
    }
}
