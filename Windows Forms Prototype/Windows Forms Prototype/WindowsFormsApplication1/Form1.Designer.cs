//Don't pay attention to this file
namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.StatusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ItemPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ItemObjectBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.UsableItemBox = new System.Windows.Forms.TextBox();
            this.ItemActionsToBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UniversalActionPanel = new System.Windows.Forms.Panel();
            this.ActionsBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ObjectLabel = new System.Windows.Forms.Label();
            this.ObjectBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemActionToggle = new System.Windows.Forms.CheckBox();
            this.HeadlineLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.HeadlineCompleteLabel = new System.Windows.Forms.Label();
            this.StatusPanel.SuspendLayout();
            this.ItemPanel.SuspendLayout();
            this.UniversalActionPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(421, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(220, 368);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(97, 3);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(100, 20);
            this.locationBox.TabIndex = 18;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(3, 0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(88, 13);
            this.LocationLabel.TabIndex = 16;
            this.LocationLabel.Text = "Current Location:";
            // 
            // StatusPanel
            // 
            this.StatusPanel.Controls.Add(this.LocationLabel);
            this.StatusPanel.Controls.Add(this.locationBox);
            this.StatusPanel.Location = new System.Drawing.Point(9, 352);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(359, 26);
            this.StatusPanel.TabIndex = 20;
            // 
            // ItemPanel
            // 
            this.ItemPanel.Controls.Add(this.label4);
            this.ItemPanel.Controls.Add(this.label3);
            this.ItemPanel.Controls.Add(this.ItemObjectBox);
            this.ItemPanel.Controls.Add(this.label2);
            this.ItemPanel.Controls.Add(this.label9);
            this.ItemPanel.Controls.Add(this.UsableItemBox);
            this.ItemPanel.Controls.Add(this.ItemActionsToBox);
            this.ItemPanel.Enabled = false;
            this.ItemPanel.Location = new System.Drawing.Point(21, 3);
            this.ItemPanel.Name = "ItemPanel";
            this.ItemPanel.Size = new System.Drawing.Size(353, 126);
            this.ItemPanel.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Actions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Noun (optional):";
            // 
            // ItemObjectBox
            // 
            this.ItemObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemObjectBox.FormattingEnabled = true;
            this.ItemObjectBox.Location = new System.Drawing.Point(214, 72);
            this.ItemObjectBox.Name = "ItemObjectBox";
            this.ItemObjectBox.Size = new System.Drawing.Size(121, 21);
            this.ItemObjectBox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "TO:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Equiped Item:";
            // 
            // UsableItemBox
            // 
            this.UsableItemBox.Location = new System.Drawing.Point(121, 22);
            this.UsableItemBox.Name = "UsableItemBox";
            this.UsableItemBox.Size = new System.Drawing.Size(100, 20);
            this.UsableItemBox.TabIndex = 20;
            // 
            // ItemActionsToBox
            // 
            this.ItemActionsToBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemActionsToBox.FormattingEnabled = true;
            this.ItemActionsToBox.Location = new System.Drawing.Point(73, 72);
            this.ItemActionsToBox.Name = "ItemActionsToBox";
            this.ItemActionsToBox.Size = new System.Drawing.Size(101, 21);
            this.ItemActionsToBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Action 1";
            // 
            // UniversalActionPanel
            // 
            this.UniversalActionPanel.Controls.Add(this.ActionsBox);
            this.UniversalActionPanel.Controls.Add(this.label8);
            this.UniversalActionPanel.Controls.Add(this.ObjectLabel);
            this.UniversalActionPanel.Controls.Add(this.ObjectBox);
            this.UniversalActionPanel.Location = new System.Drawing.Point(3, 37);
            this.UniversalActionPanel.Name = "UniversalActionPanel";
            this.UniversalActionPanel.Size = new System.Drawing.Size(376, 140);
            this.UniversalActionPanel.TabIndex = 22;
            // 
            // ActionsBox
            // 
            this.ActionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionsBox.FormattingEnabled = true;
            this.ActionsBox.Location = new System.Drawing.Point(94, 34);
            this.ActionsBox.Name = "ActionsBox";
            this.ActionsBox.Size = new System.Drawing.Size(121, 21);
            this.ActionsBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Actions:";
            // 
            // ObjectLabel
            // 
            this.ObjectLabel.AutoSize = true;
            this.ObjectLabel.Location = new System.Drawing.Point(91, 75);
            this.ObjectLabel.Name = "ObjectLabel";
            this.ObjectLabel.Size = new System.Drawing.Size(82, 13);
            this.ObjectLabel.TabIndex = 13;
            this.ObjectLabel.Text = "Noun (optional):";
            // 
            // ObjectBox
            // 
            this.ObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectBox.FormattingEnabled = true;
            this.ObjectBox.Location = new System.Drawing.Point(94, 91);
            this.ObjectBox.Name = "ObjectBox";
            this.ObjectBox.Size = new System.Drawing.Size(121, 21);
            this.ObjectBox.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.03252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.96748F));
            this.tableLayoutPanel1.Controls.Add(this.UniversalActionPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 326);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ItemActionToggle);
            this.panel2.Controls.Add(this.ItemPanel);
            this.panel2.Location = new System.Drawing.Point(3, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 132);
            this.panel2.TabIndex = 27;
            // 
            // ItemActionToggle
            // 
            this.ItemActionToggle.AutoSize = true;
            this.ItemActionToggle.Enabled = false;
            this.ItemActionToggle.Location = new System.Drawing.Point(9, 57);
            this.ItemActionToggle.Name = "ItemActionToggle";
            this.ItemActionToggle.Size = new System.Drawing.Size(79, 17);
            this.ItemActionToggle.TabIndex = 25;
            this.ItemActionToggle.Text = "Item Action";
            this.ItemActionToggle.UseVisualStyleBackColor = true;
            this.ItemActionToggle.CheckedChanged += new System.EventHandler(this.ItemActionToggle_CheckedChanged);
            // 
            // HeadlineLabel
            // 
            this.HeadlineLabel.AutoSize = true;
            this.HeadlineLabel.Location = new System.Drawing.Point(13, 501);
            this.HeadlineLabel.Name = "HeadlineLabel";
            this.HeadlineLabel.Size = new System.Drawing.Size(0, 13);
            this.HeadlineLabel.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HeadlineCompleteLabel
            // 
            this.HeadlineCompleteLabel.AutoSize = true;
            this.HeadlineCompleteLabel.Location = new System.Drawing.Point(389, 501);
            this.HeadlineCompleteLabel.Name = "HeadlineCompleteLabel";
            this.HeadlineCompleteLabel.Size = new System.Drawing.Size(0, 13);
            this.HeadlineCompleteLabel.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 544);
            this.Controls.Add(this.HeadlineCompleteLabel);
            this.Controls.Add(this.HeadlineLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Florida Man Prototype";
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ItemPanel.ResumeLayout(false);
            this.ItemPanel.PerformLayout();
            this.UniversalActionPanel.ResumeLayout(false);
            this.UniversalActionPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.FlowLayoutPanel StatusPanel;
        private System.Windows.Forms.Panel ItemPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox UsableItemBox;
        private System.Windows.Forms.ComboBox ItemActionsToBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel UniversalActionPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ObjectLabel;
        private System.Windows.Forms.ComboBox ObjectBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label HeadlineLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ActionsBox;
        private System.Windows.Forms.CheckBox ItemActionToggle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ItemObjectBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label HeadlineCompleteLabel;
    }
}

