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
         this.textBox_source = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label_target = new System.Windows.Forms.Label();
         this.textBox_target = new System.Windows.Forms.TextBox();
         this.button_browse_source = new System.Windows.Forms.Button();
         this.button_browse_target = new System.Windows.Forms.Button();
         this.dataView = new System.Windows.Forms.DataGridView();
         this.label_files = new System.Windows.Forms.Label();
         this.button_read = new System.Windows.Forms.Button();
         this.button_start = new System.Windows.Forms.Button();
         this.button_analise = new System.Windows.Forms.Button();
         this.label_fileFilter = new System.Windows.Forms.Label();
         this.textBox_fileFilter = new System.Windows.Forms.TextBox();
         this.label_changes = new System.Windows.Forms.Label();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
         this.SuspendLayout();
         // 
         // textBox_source
         // 
         this.textBox_source.Location = new System.Drawing.Point(12, 35);
         this.textBox_source.Name = "textBox_source";
         this.textBox_source.Size = new System.Drawing.Size(668, 20);
         this.textBox_source.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Source folder:";
         // 
         // label_target
         // 
         this.label_target.AutoSize = true;
         this.label_target.Location = new System.Drawing.Point(12, 58);
         this.label_target.Name = "label_target";
         this.label_target.Size = new System.Drawing.Size(70, 13);
         this.label_target.TabIndex = 3;
         this.label_target.Text = "Target folder:";
         // 
         // textBox_target
         // 
         this.textBox_target.Location = new System.Drawing.Point(12, 74);
         this.textBox_target.Name = "textBox_target";
         this.textBox_target.Size = new System.Drawing.Size(668, 20);
         this.textBox_target.TabIndex = 2;
         // 
         // button_browse_source
         // 
         this.button_browse_source.Location = new System.Drawing.Point(686, 33);
         this.button_browse_source.Name = "button_browse_source";
         this.button_browse_source.Size = new System.Drawing.Size(102, 23);
         this.button_browse_source.TabIndex = 4;
         this.button_browse_source.Text = "Browse Source";
         this.button_browse_source.UseVisualStyleBackColor = true;
         this.button_browse_source.Click += new System.EventHandler(this.BrowseSource_Click);
         // 
         // button_browse_target
         // 
         this.button_browse_target.Location = new System.Drawing.Point(686, 72);
         this.button_browse_target.Name = "button_browse_target";
         this.button_browse_target.Size = new System.Drawing.Size(102, 23);
         this.button_browse_target.TabIndex = 5;
         this.button_browse_target.Text = "Browse Target";
         this.button_browse_target.UseVisualStyleBackColor = true;
         this.button_browse_target.Click += new System.EventHandler(this.BrowseTarget_Click);
         // 
         // dataView
         // 
         this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataView.Location = new System.Drawing.Point(12, 174);
         this.dataView.Name = "dataView";
         this.dataView.Size = new System.Drawing.Size(776, 575);
         this.dataView.TabIndex = 6;
         // 
         // label_files
         // 
         this.label_files.AutoSize = true;
         this.label_files.Location = new System.Drawing.Point(12, 158);
         this.label_files.Name = "label_files";
         this.label_files.Size = new System.Drawing.Size(31, 13);
         this.label_files.TabIndex = 7;
         this.label_files.Text = "Files:";
         // 
         // button_read
         // 
         this.button_read.Location = new System.Drawing.Point(798, 116);
         this.button_read.Name = "button_read";
         this.button_read.Size = new System.Drawing.Size(178, 23);
         this.button_read.TabIndex = 8;
         this.button_read.Text = "Read";
         this.button_read.UseVisualStyleBackColor = true;
         this.button_read.Click += new System.EventHandler(this.Read_ClickAsync);
         // 
         // button_start
         // 
         this.button_start.Location = new System.Drawing.Point(799, 174);
         this.button_start.Name = "button_start";
         this.button_start.Size = new System.Drawing.Size(177, 23);
         this.button_start.TabIndex = 9;
         this.button_start.Text = "Start";
         this.button_start.UseVisualStyleBackColor = true;
         this.button_start.Click += new System.EventHandler(this.Start_Click);
         // 
         // button_analise
         // 
         this.button_analise.Location = new System.Drawing.Point(799, 145);
         this.button_analise.Name = "button_analise";
         this.button_analise.Size = new System.Drawing.Size(177, 23);
         this.button_analise.TabIndex = 10;
         this.button_analise.Text = "Analise";
         this.button_analise.UseVisualStyleBackColor = true;
         this.button_analise.Click += new System.EventHandler(this.Analise_Click);
         // 
         // label_fileFilter
         // 
         this.label_fileFilter.AutoSize = true;
         this.label_fileFilter.Location = new System.Drawing.Point(12, 100);
         this.label_fileFilter.Name = "label_fileFilter";
         this.label_fileFilter.Size = new System.Drawing.Size(48, 13);
         this.label_fileFilter.TabIndex = 12;
         this.label_fileFilter.Text = "File filter:";
         // 
         // textBox_fileFilter
         // 
         this.textBox_fileFilter.Location = new System.Drawing.Point(12, 116);
         this.textBox_fileFilter.Name = "textBox_fileFilter";
         this.textBox_fileFilter.Size = new System.Drawing.Size(668, 20);
         this.textBox_fileFilter.TabIndex = 11;
         // 
         // label_changes
         // 
         this.label_changes.AutoSize = true;
         this.label_changes.Location = new System.Drawing.Point(794, 739);
         this.label_changes.Name = "label_changes";
         this.label_changes.Size = new System.Drawing.Size(52, 13);
         this.label_changes.TabIndex = 13;
         this.label_changes.Text = "Changes:";
         // 
         // progressBar
         // 
         this.progressBar.Location = new System.Drawing.Point(799, 204);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(173, 23);
         this.progressBar.TabIndex = 14;
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(984, 761);
         this.Controls.Add(this.progressBar);
         this.Controls.Add(this.label_changes);
         this.Controls.Add(this.label_fileFilter);
         this.Controls.Add(this.textBox_fileFilter);
         this.Controls.Add(this.button_analise);
         this.Controls.Add(this.button_start);
         this.Controls.Add(this.button_read);
         this.Controls.Add(this.label_files);
         this.Controls.Add(this.dataView);
         this.Controls.Add(this.button_browse_target);
         this.Controls.Add(this.button_browse_source);
         this.Controls.Add(this.label_target);
         this.Controls.Add(this.textBox_target);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox_source);
         this.Name = "MainWindow";
         this.Text = "KeepItClean";
         ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox_source;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label_target;
      private System.Windows.Forms.TextBox textBox_target;
      private System.Windows.Forms.Button button_browse_source;
      private System.Windows.Forms.Button button_browse_target;
      private System.Windows.Forms.DataGridView dataView;
      private System.Windows.Forms.Label label_files;
      private System.Windows.Forms.Button button_read;
      private System.Windows.Forms.Button button_start;
      private System.Windows.Forms.Button button_analise;
      private System.Windows.Forms.Label label_fileFilter;
      private System.Windows.Forms.TextBox textBox_fileFilter;
      private System.Windows.Forms.Label label_changes;
      private System.Windows.Forms.ProgressBar progressBar;
   }
}

