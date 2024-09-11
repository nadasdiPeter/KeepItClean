namespace KeepItClean
{
   partial class MainWindow
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
         this.textBox_source = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label_target = new System.Windows.Forms.Label();
         this.textBox_target = new System.Windows.Forms.TextBox();
         this.dataView = new System.Windows.Forms.DataGridView();
         this.label_files = new System.Windows.Forms.Label();
         this.label_fileFilter = new System.Windows.Forms.Label();
         this.textBox_fileFilter = new System.Windows.Forms.TextBox();
         this.progress_lablel = new System.Windows.Forms.Label();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.toolTip = new System.Windows.Forms.ToolTip(this.components);
         this.filesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.browseSourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.browseTargetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.restoreChangesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.deleteEmptyFoldersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.recursiveFileImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.dateErrorSeparationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.analiseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip = new System.Windows.Forms.MenuStrip();
         ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
         this.menuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // textBox_source
         // 
         this.textBox_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox_source.Location = new System.Drawing.Point(158, 18);
         this.textBox_source.Name = "textBox_source";
         this.textBox_source.Size = new System.Drawing.Size(810, 21);
         this.textBox_source.TabIndex = 0;
         this.toolTip.SetToolTip(this.textBox_source, "Source folder path.");
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(79, 23);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Source folder:";
         // 
         // label_target
         // 
         this.label_target.AutoSize = true;
         this.label_target.Location = new System.Drawing.Point(76, 49);
         this.label_target.Name = "label_target";
         this.label_target.Size = new System.Drawing.Size(70, 13);
         this.label_target.TabIndex = 3;
         this.label_target.Text = "Target folder:";
         // 
         // textBox_target
         // 
         this.textBox_target.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox_target.Location = new System.Drawing.Point(158, 44);
         this.textBox_target.Name = "textBox_target";
         this.textBox_target.Size = new System.Drawing.Size(810, 21);
         this.textBox_target.TabIndex = 2;
         this.toolTip.SetToolTip(this.textBox_target, "Target folder path.");
         // 
         // dataView
         // 
         this.dataView.AllowUserToAddRows = false;
         this.dataView.AllowUserToDeleteRows = false;
         this.dataView.AllowUserToOrderColumns = true;
         this.dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataView.Location = new System.Drawing.Point(82, 186);
         this.dataView.Name = "dataView";
         this.dataView.Size = new System.Drawing.Size(886, 563);
         this.dataView.TabIndex = 6;
         // 
         // label_files
         // 
         this.label_files.AutoSize = true;
         this.label_files.Location = new System.Drawing.Point(79, 170);
         this.label_files.Name = "label_files";
         this.label_files.Size = new System.Drawing.Size(31, 13);
         this.label_files.TabIndex = 7;
         this.label_files.Text = "Files:";
         // 
         // label_fileFilter
         // 
         this.label_fileFilter.AutoSize = true;
         this.label_fileFilter.Location = new System.Drawing.Point(79, 75);
         this.label_fileFilter.Name = "label_fileFilter";
         this.label_fileFilter.Size = new System.Drawing.Size(48, 13);
         this.label_fileFilter.TabIndex = 12;
         this.label_fileFilter.Text = "File filter:";
         // 
         // textBox_fileFilter
         // 
         this.textBox_fileFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox_fileFilter.Location = new System.Drawing.Point(158, 70);
         this.textBox_fileFilter.Name = "textBox_fileFilter";
         this.textBox_fileFilter.Size = new System.Drawing.Size(810, 21);
         this.textBox_fileFilter.TabIndex = 11;
         // 
         // progress_lablel
         // 
         this.progress_lablel.AutoSize = true;
         this.progress_lablel.Location = new System.Drawing.Point(79, 111);
         this.progress_lablel.Name = "progress_lablel";
         this.progress_lablel.Size = new System.Drawing.Size(67, 13);
         this.progress_lablel.TabIndex = 13;
         this.progress_lablel.Text = "ProgressBar:";
         this.progress_lablel.Visible = false;
         // 
         // progressBar
         // 
         this.progressBar.Location = new System.Drawing.Point(82, 127);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(886, 23);
         this.progressBar.TabIndex = 14;
         this.progressBar.Visible = false;
         // 
         // filesMenuItem
         // 
         this.filesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseSourceMenuItem,
            this.browseTargetMenuItem,
            this.toolStripSeparator1,
            this.restoreChangesMenuItem});
         this.filesMenuItem.Name = "filesMenuItem";
         this.filesMenuItem.Size = new System.Drawing.Size(63, 23);
         this.filesMenuItem.Text = "Files";
         this.filesMenuItem.ToolTipText = "Files";
         // 
         // browseSourceMenuItem
         // 
         this.browseSourceMenuItem.Name = "browseSourceMenuItem";
         this.browseSourceMenuItem.Size = new System.Drawing.Size(178, 24);
         this.browseSourceMenuItem.Text = "Browse source";
         this.browseSourceMenuItem.Click += new System.EventHandler(this.BrowseSource_Click);
         // 
         // browseTargetMenuItem
         // 
         this.browseTargetMenuItem.Name = "browseTargetMenuItem";
         this.browseTargetMenuItem.Size = new System.Drawing.Size(178, 24);
         this.browseTargetMenuItem.Text = "Browse target";
         this.browseTargetMenuItem.Click += new System.EventHandler(this.BrowseTarget_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
         // 
         // restoreChangesMenuItem
         // 
         this.restoreChangesMenuItem.Name = "restoreChangesMenuItem";
         this.restoreChangesMenuItem.Size = new System.Drawing.Size(178, 24);
         this.restoreChangesMenuItem.Text = "Restore changes";
         this.restoreChangesMenuItem.Click += new System.EventHandler(this.Restore_Click);
         // 
         // settingsMenuItem
         // 
         this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmptyFoldersMenuItem,
            this.recursiveFileImportMenuItem,
            this.dateErrorSeparationMenuItem});
         this.settingsMenuItem.Name = "settingsMenuItem";
         this.settingsMenuItem.Size = new System.Drawing.Size(63, 23);
         this.settingsMenuItem.Text = "Settings";
         this.settingsMenuItem.ToolTipText = "Settings";
         // 
         // deleteEmptyFoldersMenuItem
         // 
         this.deleteEmptyFoldersMenuItem.Checked = true;
         this.deleteEmptyFoldersMenuItem.CheckOnClick = true;
         this.deleteEmptyFoldersMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.deleteEmptyFoldersMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.deleteEmptyFoldersMenuItem.Name = "deleteEmptyFoldersMenuItem";
         this.deleteEmptyFoldersMenuItem.Size = new System.Drawing.Size(205, 24);
         this.deleteEmptyFoldersMenuItem.Text = "Delete empty folders";
         this.deleteEmptyFoldersMenuItem.CheckedChanged += new System.EventHandler(this.Save_UserSettings);
         // 
         // recursiveFileImportMenuItem
         // 
         this.recursiveFileImportMenuItem.Checked = true;
         this.recursiveFileImportMenuItem.CheckOnClick = true;
         this.recursiveFileImportMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.recursiveFileImportMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.recursiveFileImportMenuItem.Name = "recursiveFileImportMenuItem";
         this.recursiveFileImportMenuItem.Size = new System.Drawing.Size(205, 24);
         this.recursiveFileImportMenuItem.Text = "Recursive file import";
         this.recursiveFileImportMenuItem.CheckedChanged += new System.EventHandler(this.Save_UserSettings);
         // 
         // dateErrorSeparationMenuItem
         // 
         this.dateErrorSeparationMenuItem.Checked = true;
         this.dateErrorSeparationMenuItem.CheckOnClick = true;
         this.dateErrorSeparationMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.dateErrorSeparationMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this.dateErrorSeparationMenuItem.Name = "dateErrorSeparationMenuItem";
         this.dateErrorSeparationMenuItem.Size = new System.Drawing.Size(205, 24);
         this.dateErrorSeparationMenuItem.Text = "DateError separation";
         this.dateErrorSeparationMenuItem.CheckedChanged += new System.EventHandler(this.Save_UserSettings);
         // 
         // importMenuItem
         // 
         this.importMenuItem.Name = "importMenuItem";
         this.importMenuItem.Size = new System.Drawing.Size(63, 23);
         this.importMenuItem.Text = "Import";
         this.importMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.importMenuItem.ToolTipText = "Import";
         this.importMenuItem.Click += new System.EventHandler(this.Import_Click);
         // 
         // analiseMenuItem
         // 
         this.analiseMenuItem.Name = "analiseMenuItem";
         this.analiseMenuItem.Size = new System.Drawing.Size(63, 23);
         this.analiseMenuItem.Text = "Analise";
         this.analiseMenuItem.ToolTipText = "Analise";
         this.analiseMenuItem.Click += new System.EventHandler(this.Analise_Click);
         // 
         // startMenuItem
         // 
         this.startMenuItem.Name = "startMenuItem";
         this.startMenuItem.Size = new System.Drawing.Size(63, 23);
         this.startMenuItem.Text = "Start";
         this.startMenuItem.ToolTipText = "Start";
         this.startMenuItem.Click += new System.EventHandler(this.Start_Click);
         // 
         // menuStrip
         // 
         this.menuStrip.BackColor = System.Drawing.Color.DarkSeaGreen;
         this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
         this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
         this.menuStrip.ImageScalingSize = new System.Drawing.Size(50, 50);
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesMenuItem,
            this.settingsMenuItem,
            this.importMenuItem,
            this.analiseMenuItem,
            this.startMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.ShowItemToolTips = true;
         this.menuStrip.Size = new System.Drawing.Size(76, 761);
         this.menuStrip.TabIndex = 15;
         this.menuStrip.Text = "Menu";
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(984, 761);
         this.Controls.Add(this.progressBar);
         this.Controls.Add(this.progress_lablel);
         this.Controls.Add(this.label_fileFilter);
         this.Controls.Add(this.textBox_fileFilter);
         this.Controls.Add(this.label_files);
         this.Controls.Add(this.dataView);
         this.Controls.Add(this.label_target);
         this.Controls.Add(this.textBox_target);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox_source);
         this.Controls.Add(this.menuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip;
         this.Name = "MainWindow";
         this.Text = "Keep-It-Clean";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save_UserSettings);
         ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
         this.menuStrip.ResumeLayout(false);
         this.menuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox_source;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label_target;
      private System.Windows.Forms.TextBox textBox_target;
      private System.Windows.Forms.DataGridView dataView;
      private System.Windows.Forms.Label label_files;
      private System.Windows.Forms.Label label_fileFilter;
      private System.Windows.Forms.TextBox textBox_fileFilter;
      private System.Windows.Forms.Label progress_lablel;
      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.ToolTip toolTip;
      private System.Windows.Forms.ToolStripMenuItem filesMenuItem;
      private System.Windows.Forms.ToolStripMenuItem browseSourceMenuItem;
      private System.Windows.Forms.ToolStripMenuItem browseTargetMenuItem;
      private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteEmptyFoldersMenuItem;
      private System.Windows.Forms.ToolStripMenuItem recursiveFileImportMenuItem;
      private System.Windows.Forms.ToolStripMenuItem dateErrorSeparationMenuItem;
      private System.Windows.Forms.ToolStripMenuItem importMenuItem;
      private System.Windows.Forms.ToolStripMenuItem analiseMenuItem;
      private System.Windows.Forms.ToolStripMenuItem startMenuItem;
      private System.Windows.Forms.MenuStrip menuStrip;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem restoreChangesMenuItem;
   }
}

