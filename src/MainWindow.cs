using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using KeepItClean.src;
using System.IO;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Controls;

namespace KeepItClean
{
   public partial class MainWindow : Form
   {

      private System.ComponentModel.BackgroundWorker Read_BackgroundWorker = new BackgroundWorker();

      public MainWindow()
      {
         InitializeComponent();
         InitializeBackgroundWorker();
         Read_BackgroundWorker.WorkerReportsProgress = true;
         Read_BackgroundWorker.WorkerSupportsCancellation = true;
         textBox_fileFilter.Text = String.Join(", ", config.IMAGE_FORMATS);
      }

      private void InitializeBackgroundWorker()
      {
         Read_BackgroundWorker.DoWork += new DoWorkEventHandler(Read_BackgroundWorker_DoWork);
         Read_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(Read_BackgroundWorker_ProgressChanged);
         Read_BackgroundWorker.RunWorkerCompleted +=  new RunWorkerCompletedEventHandler(Read_BackgroundWorker_RunWorkerCompleted);
      }

      private void BrowseSource_Click(object sender, EventArgs e)
      {
         CommonOpenFileDialog dialog = new CommonOpenFileDialog();
         dialog.InitialDirectory = "C:\\Users";
         dialog.IsFolderPicker = true;
         if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
         {
            textBox_source.Text = dialog.FileName;
         }
      }

      private void BrowseTarget_Click(object sender, EventArgs e)
      {
         CommonOpenFileDialog dialog = new CommonOpenFileDialog();
         dialog.InitialDirectory = "C:\\Users";
         dialog.IsFolderPicker = true;
         if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
         {
                textBox_target.Text = dialog.FileName;
         }
      }

      //private async void Read_AsyncTask() => new FileReader(textBox_source.Text, true, textBox_fileFilter.Text);

      private async void Read_ClickAsync(object sender, EventArgs e)
      {
         /*if (!textBox_source.Text.Equals("") && Directory.Exists(textBox_source.Text))
         {
            await Task.Run(() => Read_AsyncTask());
            DataGridView_Update(Database.Files());
         }
         else
         {
            MessageBox.Show("The source directory: \"" + textBox_source.Text + "\" does not exist.","KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }*/

         if (Read_BackgroundWorker.IsBusy != true)
         {
            // Start the asynchronous operation.
            Read_BackgroundWorker.RunWorkerAsync();
         }

      }

      // This event handler is where the time-consuming work is done.
      private void Read_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         BackgroundWorker worker = sender as BackgroundWorker;
         if (worker.CancellationPending == true)
         {
            e.Cancel = true;
         }
         else
         {
            // Perform a time consuming operation and report progress.
            new FileReader(textBox_source.Text, true, textBox_fileFilter.Text, ref worker);
            DataGridView_Update(Database.Files());
         }
      }

      // This event handler updates the progress.
      private void Read_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         progressBar.Value = e.ProgressPercentage;
      }

      // This event handler deals with the results of the background operation.
      private void Read_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         if (e.Cancelled == true)
         {
            label_changes.Text = "Canceled!";
         }
         else if (e.Error != null)
         {
            label_changes.Text = "Error: " + e.Error.Message;
         }
         else
         {
            label_changes.Text = "Done!";
         }
      }

      private void Analise_Click(object sender, EventArgs e)
      {
         if( Database.Files().Count > 0 )
         {
            if (!textBox_target.Text.Equals(""))
            {

            }
            else
            {
               MessageBox.Show("No target directory set.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         else
         {
            MessageBox.Show("No files in the databse currently.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Start_Click(object sender, EventArgs e)
      {

      }

      delegate void DataGridView_Update_Callback(List<IFile> list);

      private void DataGridView_Update(List<IFile> list)
      {
         // InvokeRequired required compares the thread ID of the
         // calling thread to the thread ID of the creating thread.
         // If these threads are different, it returns true.
         if (this.dataView.InvokeRequired)
         {
            DataGridView_Update_Callback d = new DataGridView_Update_Callback(DataGridView_Update);
            this.Invoke(d, list);
         }
         else
         {
            /* Set data source */
            this.dataView.DataSource = list;
            this.dataView.AutoGenerateColumns = true;

            /* Set column visibility */
            this.dataView.Columns["Path"].Visible = false;
            this.dataView.Columns["Extension"].Visible = false;

            /* Set column width */
            this.dataView.Columns["Path"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataView.Columns["Directory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataView.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataView.Columns["Extension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataView.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         }
      }
   }
}
