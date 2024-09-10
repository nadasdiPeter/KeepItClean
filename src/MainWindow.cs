using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using KeepItClean.src;
using System.ComponentModel;
using System.IO;

namespace KeepItClean
{
   public partial class MainWindow : Form
   {
      private BackgroundWorker Read_BackgroundWorker = new BackgroundWorker();

      public MainWindow()
      {
         InitializeComponent();
         Load_UserSettings();
         InitializeBackgroundWorker();
         textBox_fileFilter.Text = String.Join(", ", config.IMAGE_FORMATS);
         this.menuStrip.Items.Add(new ToolStripSeparator());
         this.menuStrip.Items.Insert(2, new ToolStripSeparator());
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

      private void Import_Click(object sender, EventArgs e)
      {
         if(Directory.Exists(textBox_source.Text))
         {
            if (Read_BackgroundWorker.IsBusy != true)
            {
               ClearDatabase();
               Read_BackgroundWorker.RunWorkerAsync(); // Start the asynchronous operation.
            }
         }
         else
         {
            MessageBox.Show("No source directory set, or its not existing.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Analise_Click(object sender, EventArgs e)
      {
         if (Database.Files().Count > 0)
         {
            if (!textBox_target.Text.Equals(""))
            {
               Database.AssigneNewPaths(textBox_target.Text, dateErrorSeparationMenuItem.Checked);
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
            MessageBox.Show("No files in the database currently.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Start_Click(object sender, EventArgs e)
      {
         if (Database.Files().Count > 0)
         {
            if(Database.Files()[0].NewPath != "")
            {
               FileMover fileMover = new FileMover(textBox_source.Text, textBox_target.Text);
               fileMover.RelocateFiles();
               if(deleteEmptyFoldersMenuItem.Checked)
                  fileMover.DeleteEmptyFolders(textBox_source.Text);
               SetProgressBarStatus(true, "Relocation completed.", 100);
               ClearDatabase();
            }
            else
            {
               MessageBox.Show("New paths are not set, please use ANALISE first.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
         else
         {
            MessageBox.Show("No files in the database currently.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Restore_Click(object sender, EventArgs e)
      {
         CommonOpenFileDialog dialog = new CommonOpenFileDialog();
         dialog.InitialDirectory = "C:\\Users";
         dialog.DefaultFileName = "ChangeLog.txt";
         dialog.IsFolderPicker = false;
         if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
         {
            if(new FileRestorer(dialog.FileName).Start())
               MessageBox.Show("Files successfully restored.", "KeepItClean Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
               MessageBox.Show("Process failed.", "KeepItClean Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
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

      private void ClearDatabase()
      {
         Database.Clear();
         dataView.DataSource = null;
         DataGridView_Refresh();
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
            new FileReader(textBox_source.Text, recursiveFileImportMenuItem.Checked, textBox_fileFilter.Text, ref worker);
         }
      }

      // This event handler updates the progress.
      private void Read_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) => SetProgressBarStatus(true, "Importing files...", e.ProgressPercentage);

      // This event handler deals with the results of the background operation.
      private void Read_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         SetProgressBarStatus(true, "Import completed. (" + Database.FileCount() + " files)", 100);
         DataGridView_Update(Database.Files());
      }



      private void Load_UserSettings()
      {
         dateErrorSeparationMenuItem.Checked = Properties.Settings.Default.DATE_ERROR_SEPARATION_SETTING;
         deleteEmptyFoldersMenuItem.Checked = Properties.Settings.Default.DELETE_EMPTY_FOLDER_SETTING;
         recursiveFileImportMenuItem.Checked = Properties.Settings.Default.RECURSIVE_SEARCH_SETTING;
      }

      private void Save_UserSettings(object sender, EventArgs e)
      {
         Properties.Settings.Default.DATE_ERROR_SEPARATION_SETTING = dateErrorSeparationMenuItem.Checked;
         Properties.Settings.Default.DELETE_EMPTY_FOLDER_SETTING = deleteEmptyFoldersMenuItem.Checked;
         Properties.Settings.Default.RECURSIVE_SEARCH_SETTING = recursiveFileImportMenuItem.Checked;
         Properties.Settings.Default.Save();
      }


   }
}
