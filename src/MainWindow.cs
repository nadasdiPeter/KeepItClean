using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using KeepItClean.src;
using System.ComponentModel;

namespace KeepItClean
{
   public partial class MainWindow : Form
   {
      private BackgroundWorker Read_BackgroundWorker = new BackgroundWorker();



      public MainWindow()
      {
         InitializeComponent();
         InitializeBackgroundWorker();
         textBox_fileFilter.Text = String.Join(", ", config.IMAGE_FORMATS);
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

      private void Read_Click(object sender, EventArgs e)
      {
         if (Read_BackgroundWorker.IsBusy != true)
         {
            SetProgressBarStatus(true, "Reading...", 0);
            Read_BackgroundWorker.RunWorkerAsync(); // Start the asynchronous operation.
         }
      }

      private void Analise_Click(object sender, EventArgs e)
      {
         if (Database.Files().Count > 0)
         {
            if (!textBox_target.Text.Equals(""))
            {
               Database.AssigneNewPaths(textBox_target.Text, true);
               DataGridView_Refresh();
               SetProgressBarStatus(true, "Analysis completed.", 100);
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
         FileMover.RelocateFiles();
         FileMover.DeleteEmptyFolders(textBox_source.Text);
         SetProgressBarStatus(true, "Relocation completed.", 100);
         Database.Clear();
         DataGridView_Refresh();
      }



      private void SetProgressBarStatus(bool isVisible, string message = "", int value = 0)
      {
         progress_lablel.Visible = isVisible;
         progressBar.Visible = isVisible;

         progress_lablel.Text = message;
         progressBar.Value = value;
      }

      private void DataGridView_Update(List<IFile> list)
      {
         /* Set data source */
         dataView.ScrollBars = ScrollBars.Both;
         dataView.DataSource = list;
         dataView.AutoGenerateColumns = true;

         /* Set column visibility */
         dataView.Columns["Path"].Visible = false;
         dataView.Columns["Extension"].Visible = false;

         /* Set column width */
         dataView.Columns["Path"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         dataView.Columns["Directory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         dataView.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         dataView.Columns["Extension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         dataView.Columns["NewPath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
         dataView.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }

      private void DataGridView_Refresh()
      {
         dataView.Update();
         dataView.Refresh();
      }



      private void InitializeBackgroundWorker()
      {
         Read_BackgroundWorker.DoWork += new DoWorkEventHandler(Read_BackgroundWorker_DoWork);
         Read_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(Read_BackgroundWorker_ProgressChanged);
         Read_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Read_BackgroundWorker_RunWorkerCompleted);
         Read_BackgroundWorker.WorkerReportsProgress = true;
         Read_BackgroundWorker.WorkerSupportsCancellation = true;
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
         }
      }

      // This event handler updates the progress.
      private void Read_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) => SetProgressBarStatus(true, "Reading...", e.ProgressPercentage);

      // This event handler deals with the results of the background operation.
      private void Read_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         SetProgressBarStatus(true, "Import completed. (" + Database.FileCount() + " files)", 100);
         DataGridView_Update(Database.Files());
      }

   }
}
