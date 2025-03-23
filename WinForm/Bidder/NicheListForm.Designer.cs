namespace Bidder
{
    partial class NicheListForm
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
            nicheDataGridView = new DataGridView();
            newButton = new Button();
            editButton = new Button();
            ((System.ComponentModel.ISupportInitialize)nicheDataGridView).BeginInit();
            SuspendLayout();
            // 
            // nicheDataGridView
            // 
            nicheDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nicheDataGridView.Location = new Point(12, 12);
            nicheDataGridView.Name = "nicheDataGridView";
            nicheDataGridView.ReadOnly = true;
            nicheDataGridView.RowHeadersWidth = 82;
            nicheDataGridView.Size = new Size(876, 300);
            nicheDataGridView.TabIndex = 0;
            // 
            // newButton
            // 
            newButton.Location = new Point(12, 330);
            newButton.Name = "newButton";
            newButton.Size = new Size(75, 41);
            newButton.TabIndex = 1;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            editButton.Location = new Point(100, 330);
            editButton.Name = "editButton";
            editButton.Size = new Size(75, 41);
            editButton.TabIndex = 2;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            // 
            // NicheListForm
            // 
            ClientSize = new Size(900, 380);
            Controls.Add(nicheDataGridView);
            Controls.Add(newButton);
            Controls.Add(editButton);
            Name = "NicheListForm";
            Text = "Niche List";
            ((System.ComponentModel.ISupportInitialize)nicheDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}