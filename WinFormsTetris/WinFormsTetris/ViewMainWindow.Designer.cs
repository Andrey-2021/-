
namespace WinFormsTetris
{
    partial class ViewMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewGameBox = new System.Windows.Forms.DataGridView();
            this.textBoxKeys = new System.Windows.Forms.TextBox();
            this.menuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RezultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameBox)).BeginInit();
            this.menuStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewGameBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKeys, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.menuStripMainMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClose, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonStart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxScore, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewGameBox
            // 
            this.dataGridViewGameBox.AllowUserToAddRows = false;
            this.dataGridViewGameBox.AllowUserToDeleteRows = false;
            this.dataGridViewGameBox.AllowUserToResizeColumns = false;
            this.dataGridViewGameBox.AllowUserToResizeRows = false;
            this.dataGridViewGameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewGameBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGameBox.Location = new System.Drawing.Point(222, 33);
            this.dataGridViewGameBox.MultiSelect = false;
            this.dataGridViewGameBox.Name = "dataGridViewGameBox";
            this.dataGridViewGameBox.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewGameBox, 5);
            this.dataGridViewGameBox.RowTemplate.Height = 25;
            this.dataGridViewGameBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewGameBox.Size = new System.Drawing.Size(341, 374);
            this.dataGridViewGameBox.TabIndex = 1;
            // 
            // textBoxKeys
            // 
            this.textBoxKeys.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxKeys.Enabled = false;
            this.textBoxKeys.Location = new System.Drawing.Point(37, 221);
            this.textBoxKeys.Multiline = true;
            this.textBoxKeys.Name = "textBoxKeys";
            this.textBoxKeys.Size = new System.Drawing.Size(126, 158);
            this.textBoxKeys.TabIndex = 7;
            this.textBoxKeys.Text = "Управление:\r\n\r\n< - влево\r\n->- вправо\r\n | - вниз\r\nZ - поворот влево\r\nX - поворов в" +
    "право";
            // 
            // menuStripMainMenu
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStripMainMenu, 3);
            this.menuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.RezultsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainMenu.Name = "menuStripMainMenu";
            this.menuStripMainMenu.Size = new System.Drawing.Size(606, 24);
            this.menuStripMainMenu.TabIndex = 8;
            this.menuStripMainMenu.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            // 
            // RezultsToolStripMenuItem
            // 
            this.RezultsToolStripMenuItem.Name = "RezultsToolStripMenuItem";
            this.RezultsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.RezultsToolStripMenuItem.Text = "Результаты";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.HelpToolStripMenuItem.Text = "Помощь";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClose.Location = new System.Drawing.Point(62, 418);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.Location = new System.Drawing.Point(62, 38);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(62, 78);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Очки";
            // 
            // textBoxScore
            // 
            this.textBoxScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxScore.Location = new System.Drawing.Point(50, 165);
            this.textBoxScore.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(100, 23);
            this.textBoxScore.TabIndex = 5;
            // 
            // ViewMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMainMenu;
            this.MinimumSize = new System.Drawing.Size(622, 489);
            this.Name = "ViewMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameBox)).EndInit();
            this.menuStripMainMenu.ResumeLayout(false);
            this.menuStripMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKeys;
        internal System.Windows.Forms.DataGridView dataGridViewGameBox;
        internal System.Windows.Forms.Button buttonClose;
        internal System.Windows.Forms.Button buttonStart;
        internal System.Windows.Forms.TextBox textBoxScore;
        internal System.Windows.Forms.Button buttonStop;
        internal System.Windows.Forms.MenuStrip menuStripMainMenu;
        internal System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RezultsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
    }
}

