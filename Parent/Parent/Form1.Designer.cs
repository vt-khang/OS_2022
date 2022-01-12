
namespace Parent
{
    partial class Form
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
            this.LabelFrom = new System.Windows.Forms.Label();
            this.LabelTo = new System.Windows.Forms.Label();
            this.LabelDuration = new System.Windows.Forms.Label();
            this.LabelInterrupt = new System.Windows.Forms.Label();
            this.LabelSum = new System.Windows.Forms.Label();
            this.TextBoxDuration = new System.Windows.Forms.TextBox();
            this.TextBoxInterrupt = new System.Windows.Forms.TextBox();
            this.TextBoxSum = new System.Windows.Forms.TextBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.ListView = new System.Windows.Forms.ListView();
            this.ColumnSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnInterrupt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.TimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.XemThoiGianToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AnhChupToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LichSuDungMayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MatKhauToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PasswordChildrenLabel = new System.Windows.Forms.Label();
            this.PasswordParentLabel = new System.Windows.Forms.Label();
            this.PasswordChildrenTextBox = new System.Windows.Forms.TextBox();
            this.PasswordParentTextBox = new System.Windows.Forms.TextBox();
            this.ButtonEditAndSavePasswordChildren = new System.Windows.Forms.Button();
            this.ButtonEditAndSavePasswordParent = new System.Windows.Forms.Button();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelFrom
            // 
            this.LabelFrom.AutoSize = true;
            this.LabelFrom.Location = new System.Drawing.Point(26, 45);
            this.LabelFrom.Name = "LabelFrom";
            this.LabelFrom.Size = new System.Drawing.Size(40, 17);
            this.LabelFrom.TabIndex = 0;
            this.LabelFrom.Text = "From";
            // 
            // LabelTo
            // 
            this.LabelTo.AutoSize = true;
            this.LabelTo.Location = new System.Drawing.Point(25, 77);
            this.LabelTo.Name = "LabelTo";
            this.LabelTo.Size = new System.Drawing.Size(25, 17);
            this.LabelTo.TabIndex = 0;
            this.LabelTo.Text = "To";
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Location = new System.Drawing.Point(304, 45);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(62, 17);
            this.LabelDuration.TabIndex = 0;
            this.LabelDuration.Text = "Duration";
            // 
            // LabelInterrupt
            // 
            this.LabelInterrupt.AutoSize = true;
            this.LabelInterrupt.Location = new System.Drawing.Point(304, 77);
            this.LabelInterrupt.Name = "LabelInterrupt";
            this.LabelInterrupt.Size = new System.Drawing.Size(61, 17);
            this.LabelInterrupt.TabIndex = 0;
            this.LabelInterrupt.Text = "Interrupt";
            // 
            // LabelSum
            // 
            this.LabelSum.AutoSize = true;
            this.LabelSum.ForeColor = System.Drawing.Color.Black;
            this.LabelSum.Location = new System.Drawing.Point(304, 111);
            this.LabelSum.Name = "LabelSum";
            this.LabelSum.Size = new System.Drawing.Size(36, 17);
            this.LabelSum.TabIndex = 0;
            this.LabelSum.Text = "Sum";
            // 
            // TimePickerFrom
            // 
            this.TimePickerFrom.CustomFormat = "HH:mm";
            this.TimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerFrom.Location = new System.Drawing.Point(96, 45);
            this.TimePickerFrom.Name = "TimePickerFrom";
            this.TimePickerFrom.ShowUpDown = true;
            this.TimePickerFrom.Size = new System.Drawing.Size(127, 22);
            this.TimePickerFrom.TabIndex = 1;
            // 
            // TimePickerTo
            // 
            this.TimePickerTo.CustomFormat = "HH:mm";
            this.TimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerTo.Location = new System.Drawing.Point(96, 77);
            this.TimePickerTo.Name = "TimePickerTo";
            this.TimePickerTo.ShowUpDown = true;
            this.TimePickerTo.Size = new System.Drawing.Size(127, 22);
            this.TimePickerTo.TabIndex = 2;
            // 
            // TextBoxDuration
            // 
            this.TextBoxDuration.Location = new System.Drawing.Point(385, 45);
            this.TextBoxDuration.Name = "TextBoxDuration";
            this.TextBoxDuration.Size = new System.Drawing.Size(144, 22);
            this.TextBoxDuration.TabIndex = 3;
            // 
            // TextBoxInterrupt
            // 
            this.TextBoxInterrupt.Location = new System.Drawing.Point(385, 77);
            this.TextBoxInterrupt.Name = "TextBoxInterrupt";
            this.TextBoxInterrupt.Size = new System.Drawing.Size(144, 22);
            this.TextBoxInterrupt.TabIndex = 4;
            // 
            // TextBoxSum
            // 
            this.TextBoxSum.Location = new System.Drawing.Point(385, 109);
            this.TextBoxSum.Name = "TextBoxSum";
            this.TextBoxSum.Size = new System.Drawing.Size(144, 22);
            this.TextBoxSum.TabIndex = 5;
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(596, 35);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(118, 31);
            this.ButtonEdit.TabIndex = 6;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(596, 72);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(118, 31);
            this.ButtonAdd.TabIndex = 7;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(596, 109);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(118, 31);
            this.ButtonRemove.TabIndex = 8;
            this.ButtonRemove.Text = "Remove";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnSTT,
            this.ColumnFrom,
            this.ColumnTo,
            this.ColumnDuration,
            this.ColumnInterrupt,
            this.ColumnSum});
            this.ListView.FullRowSelect = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(15, 156);
            this.ListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(725, 288);
            this.ListView.TabIndex = 9;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListView_ColumnWidthChanging);
            this.ListView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
            // 
            // ColumnSTT
            // 
            this.ColumnSTT.Text = "STT";
            this.ColumnSTT.Width = 50;
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.Text = "From";
            this.ColumnFrom.Width = 80;
            // 
            // ColumnTo
            // 
            this.ColumnTo.Text = "To";
            this.ColumnTo.Width = 80;
            // 
            // ColumnDuration
            // 
            this.ColumnDuration.Text = "Duration";
            this.ColumnDuration.Width = 100;
            // 
            // ColumnInterrupt
            // 
            this.ColumnInterrupt.Text = "Interrupt";
            this.ColumnInterrupt.Width = 100;
            // 
            // ColumnSum
            // 
            this.ColumnSum.Text = "Sum";
            this.ColumnSum.Width = 100;
            // 
            // PictureBox
            // 
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox.Location = new System.Drawing.Point(58, 77);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(640, 335);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // ComboBox
            // 
            this.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox.FormattingEnabled = true;
            this.ComboBox.Location = new System.Drawing.Point(524, 42);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(174, 24);
            this.ComboBox.TabIndex = 1;
            this.ComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // LeftButton
            // 
            this.LeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.Location = new System.Drawing.Point(289, 418);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(75, 36);
            this.LeftButton.TabIndex = 2;
            this.LeftButton.Text = "←";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.Location = new System.Drawing.Point(391, 418);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(75, 36);
            this.RightButton.TabIndex = 3;
            this.RightButton.Text = "→";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XemThoiGianToolStripMenu,
            this.AnhChupToolStripMenu,
            this.LichSuDungMayToolStripMenuItem,
            this.MatKhauToolStripMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1008, 28);
            this.MenuStrip.TabIndex = 0;
            // 
            // XemThoiGianToolStripMenu
            // 
            this.XemThoiGianToolStripMenu.Name = "XemThoiGianToolStripMenu";
            this.XemThoiGianToolStripMenu.Size = new System.Drawing.Size(91, 24);
            this.XemThoiGianToolStripMenu.Text = "Khung giờ";
            this.XemThoiGianToolStripMenu.Click += new System.EventHandler(this.XemThoiGianToolStripMenu_Click);
            // 
            // AnhChupToolStripMenu
            // 
            this.AnhChupToolStripMenu.Name = "AnhChupToolStripMenu";
            this.AnhChupToolStripMenu.Size = new System.Drawing.Size(85, 24);
            this.AnhChupToolStripMenu.Text = "Ảnh chụp";
            this.AnhChupToolStripMenu.Click += new System.EventHandler(this.AnhChupToolStripMenu_Click);
            // 
            // LichSuDungMayToolStripMenuItem
            // 
            this.LichSuDungMayToolStripMenuItem.Name = "LichSuDungMayToolStripMenuItem";
            this.LichSuDungMayToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.LichSuDungMayToolStripMenuItem.Text = "Lịch sử dùng máy";
            this.LichSuDungMayToolStripMenuItem.Click += new System.EventHandler(this.LichSuDungMayToolStripMenuItem_Click);
            // 
            // MatKhauToolStripMenu
            // 
            this.MatKhauToolStripMenu.Name = "MatKhauToolStripMenu";
            this.MatKhauToolStripMenu.Size = new System.Drawing.Size(84, 24);
            this.MatKhauToolStripMenu.Text = "Mật khẩu";
            this.MatKhauToolStripMenu.Click += new System.EventHandler(this.MatKhauToolStripMenu_Click);
            // 
            // PasswordChildrenLabel
            // 
            this.PasswordChildrenLabel.AutoSize = true;
            this.PasswordChildrenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordChildrenLabel.Location = new System.Drawing.Point(29, 158);
            this.PasswordChildrenLabel.Name = "PasswordChildrenLabel";
            this.PasswordChildrenLabel.Size = new System.Drawing.Size(253, 32);
            this.PasswordChildrenLabel.TabIndex = 0;
            this.PasswordChildrenLabel.Text = "Password Children";
            // 
            // PasswordParentLabel
            // 
            this.PasswordParentLabel.AutoSize = true;
            this.PasswordParentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordParentLabel.Location = new System.Drawing.Point(29, 214);
            this.PasswordParentLabel.Name = "PasswordParentLabel";
            this.PasswordParentLabel.Size = new System.Drawing.Size(230, 32);
            this.PasswordParentLabel.TabIndex = 0;
            this.PasswordParentLabel.Text = "Password Parent";
            // 
            // PasswordChildrenTextBox
            // 
            this.PasswordChildrenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordChildrenTextBox.Location = new System.Drawing.Point(289, 155);
            this.PasswordChildrenTextBox.Name = "PasswordChildrenTextBox";
            this.PasswordChildrenTextBox.ReadOnly = true;
            this.PasswordChildrenTextBox.Size = new System.Drawing.Size(261, 38);
            this.PasswordChildrenTextBox.TabIndex = 1;
            this.PasswordChildrenTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordParentTextBox
            // 
            this.PasswordParentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordParentTextBox.Location = new System.Drawing.Point(289, 214);
            this.PasswordParentTextBox.Name = "PasswordParentTextBox";
            this.PasswordParentTextBox.ReadOnly = true;
            this.PasswordParentTextBox.Size = new System.Drawing.Size(261, 38);
            this.PasswordParentTextBox.TabIndex = 3;
            this.PasswordParentTextBox.UseSystemPasswordChar = true;
            // 
            // ButtonEditAndSavePasswordChildren
            // 
            this.ButtonEditAndSavePasswordChildren.Location = new System.Drawing.Point(574, 155);
            this.ButtonEditAndSavePasswordChildren.Name = "ButtonEditAndSavePasswordChildren";
            this.ButtonEditAndSavePasswordChildren.Size = new System.Drawing.Size(59, 38);
            this.ButtonEditAndSavePasswordChildren.TabIndex = 2;
            this.ButtonEditAndSavePasswordChildren.Text = "Edit";
            this.ButtonEditAndSavePasswordChildren.UseVisualStyleBackColor = true;
            this.ButtonEditAndSavePasswordChildren.Click += new System.EventHandler(this.ButtonEditAndSavePasswordChildren_Click);
            // 
            // ButtonEditAndSavePasswordParent
            // 
            this.ButtonEditAndSavePasswordParent.Location = new System.Drawing.Point(574, 214);
            this.ButtonEditAndSavePasswordParent.Name = "ButtonEditAndSavePasswordParent";
            this.ButtonEditAndSavePasswordParent.Size = new System.Drawing.Size(59, 38);
            this.ButtonEditAndSavePasswordParent.TabIndex = 4;
            this.ButtonEditAndSavePasswordParent.Text = "Edit";
            this.ButtonEditAndSavePasswordParent.UseVisualStyleBackColor = true;
            this.ButtonEditAndSavePasswordParent.Click += new System.EventHandler(this.ButtonEditAndSavePasswordParent_Click);
            // 
            // RichTextBox
            // 
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBox.Location = new System.Drawing.Point(12, 44);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(694, 300);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 579);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parent";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelFrom;
        private System.Windows.Forms.Label LabelTo;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.TextBox TextBoxDuration;
        private System.Windows.Forms.Label LabelInterrupt;
        private System.Windows.Forms.TextBox TextBoxInterrupt;
        private System.Windows.Forms.Label LabelSum;
        private System.Windows.Forms.TextBox TextBoxSum;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader ColumnSTT;
        private System.Windows.Forms.ColumnHeader ColumnFrom;
        private System.Windows.Forms.ColumnHeader ColumnTo;
        private System.Windows.Forms.ColumnHeader ColumnDuration;
        private System.Windows.Forms.ColumnHeader ColumnInterrupt;
        private System.Windows.Forms.ColumnHeader ColumnSum;
        private System.Windows.Forms.DateTimePicker TimePickerFrom;
        private System.Windows.Forms.DateTimePicker TimePickerTo;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ComboBox ComboBox;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem XemThoiGianToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem AnhChupToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem MatKhauToolStripMenu;
        private System.Windows.Forms.Label PasswordChildrenLabel;
        private System.Windows.Forms.Label PasswordParentLabel;
        private System.Windows.Forms.TextBox PasswordChildrenTextBox;
        private System.Windows.Forms.TextBox PasswordParentTextBox;
        private System.Windows.Forms.Button ButtonEditAndSavePasswordChildren;
        private System.Windows.Forms.Button ButtonEditAndSavePasswordParent;
        private System.Windows.Forms.ToolStripMenuItem LichSuDungMayToolStripMenuItem;
        private System.Windows.Forms.RichTextBox RichTextBox;
    }
}

