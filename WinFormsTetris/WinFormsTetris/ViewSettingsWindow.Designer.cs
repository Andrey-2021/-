
namespace WinFormsTetris
{
    partial class ViewSettingsWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonExtendedSet = new System.Windows.Forms.RadioButton();
            this.radioButtonStandartSet = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRows = new System.Windows.Forms.Label();
            this.trackBarRows = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.labelColumns = new System.Windows.Forms.Label();
            this.trackBarColumns = new System.Windows.Forms.TrackBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRows, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBarRows, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelColumns, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.trackBarColumns, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.radioButtonExtendedSet);
            this.groupBox1.Controls.Add(this.radioButtonStandartSet);
            this.groupBox1.Location = new System.Drawing.Point(68, 240);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 3);
            this.groupBox1.Size = new System.Drawing.Size(198, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Набор фигур:";
            // 
            // radioButtonExtendedSet
            // 
            this.radioButtonExtendedSet.AutoSize = true;
            this.radioButtonExtendedSet.Location = new System.Drawing.Point(20, 81);
            this.radioButtonExtendedSet.Name = "radioButtonExtendedSet";
            this.radioButtonExtendedSet.Size = new System.Drawing.Size(172, 19);
            this.radioButtonExtendedSet.TabIndex = 1;
            this.radioButtonExtendedSet.Text = "Расширеный набор фигур";
            this.radioButtonExtendedSet.UseVisualStyleBackColor = true;
            // 
            // radioButtonStandartSet
            // 
            this.radioButtonStandartSet.AutoSize = true;
            this.radioButtonStandartSet.Checked = true;
            this.radioButtonStandartSet.Location = new System.Drawing.Point(20, 39);
            this.radioButtonStandartSet.Name = "radioButtonStandartSet";
            this.radioButtonStandartSet.Size = new System.Drawing.Size(172, 19);
            this.radioButtonStandartSet.TabIndex = 0;
            this.radioButtonStandartSet.TabStop = true;
            this.radioButtonStandartSet.Text = "Стандартный набор фигур";
            this.radioButtonStandartSet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество строк:";
            // 
            // labelRows
            // 
            this.labelRows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(111, 39);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(111, 15);
            this.labelRows.TabIndex = 8;
            this.labelRows.Text = "Текущее значение:";
            // 
            // trackBarRows
            // 
            this.trackBarRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarRows.Location = new System.Drawing.Point(13, 62);
            this.trackBarRows.Maximum = 20;
            this.trackBarRows.Minimum = 8;
            this.trackBarRows.Name = "trackBarRows";
            this.trackBarRows.Size = new System.Drawing.Size(308, 29);
            this.trackBarRows.TabIndex = 4;
            this.trackBarRows.Value = 8;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество столбцов:";
            // 
            // labelColumns
            // 
            this.labelColumns.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelColumns.AutoSize = true;
            this.labelColumns.Location = new System.Drawing.Point(111, 153);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new System.Drawing.Size(111, 15);
            this.labelColumns.TabIndex = 9;
            this.labelColumns.Text = "Текущее значение:";
            // 
            // trackBarColumns
            // 
            this.trackBarColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarColumns.Location = new System.Drawing.Point(13, 176);
            this.trackBarColumns.Maximum = 15;
            this.trackBarColumns.Minimum = 6;
            this.trackBarColumns.Name = "trackBarColumns";
            this.trackBarColumns.Size = new System.Drawing.Size(308, 29);
            this.trackBarColumns.TabIndex = 5;
            this.trackBarColumns.Value = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.Location = new System.Drawing.Point(96, 391);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(151, 25);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить настройки";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.Location = new System.Drawing.Point(129, 427);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Закрыть";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ViewSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(650, 600);
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "ViewSettingsWindow";
            this.Text = "Настройки";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.RadioButton radioButtonExtendedSet;
        internal System.Windows.Forms.RadioButton radioButtonStandartSet;
        internal System.Windows.Forms.TrackBar trackBarRows;
        internal System.Windows.Forms.TrackBar trackBarColumns;
        internal System.Windows.Forms.Button buttonSave;
        internal System.Windows.Forms.Button buttonCancel;
        internal System.Windows.Forms.Label labelRows;
        internal System.Windows.Forms.Label labelColumns;
    }
}