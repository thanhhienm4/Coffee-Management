namespace Quan_li_quan_cafe
{
    partial class FunctFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctFrom));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.CountFood = new System.Windows.Forms.NumericUpDown();
            this.AddFoodbtn = new System.Windows.Forms.Button();
            this.Foodcbx = new System.Windows.Forms.ComboBox();
            this.Categorycbx = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Costtbx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TotalPricetbx = new System.Windows.Forms.TextBox();
            this.Discoutnmud = new System.Windows.Forms.NumericUpDown();
            this.ChangeTablenud = new System.Windows.Forms.NumericUpDown();
            this.Paybtn = new System.Windows.Forms.Button();
            this.CTbtn = new System.Windows.Forms.Button();
            this.DisCountbtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MenuLvw = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tablefpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountFood)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Discoutnmud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeTablenud)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            resources.ApplyResources(this.adminToolStripMenuItem, "adminToolStripMenuItem");
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            resources.ApplyResources(this.thôngTinTàiKhoảnToolStripMenuItem, "thôngTinTàiKhoảnToolStripMenuItem");
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            resources.ApplyResources(this.thôngTinCáNhânToolStripMenuItem, "thôngTinCáNhânToolStripMenuItem");
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            resources.ApplyResources(this.đăngXuấtToolStripMenuItem, "đăngXuấtToolStripMenuItem");
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CountFood);
            this.panel2.Controls.Add(this.AddFoodbtn);
            this.panel2.Controls.Add(this.Foodcbx);
            this.panel2.Controls.Add(this.Categorycbx);
            this.panel2.Name = "panel2";
            // 
            // CountFood
            // 
            resources.ApplyResources(this.CountFood, "CountFood");
            this.CountFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.CountFood.Name = "CountFood";
            // 
            // AddFoodbtn
            // 
            resources.ApplyResources(this.AddFoodbtn, "AddFoodbtn");
            this.AddFoodbtn.Name = "AddFoodbtn";
            this.AddFoodbtn.UseVisualStyleBackColor = true;
            this.AddFoodbtn.Click += new System.EventHandler(this.AddFoodbtn_Click);
            // 
            // Foodcbx
            // 
            this.Foodcbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Foodcbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Foodcbx.FormattingEnabled = true;
            resources.ApplyResources(this.Foodcbx, "Foodcbx");
            this.Foodcbx.Name = "Foodcbx";
            // 
            // Categorycbx
            // 
            this.Categorycbx.AllowDrop = true;
            this.Categorycbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Categorycbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Categorycbx.FormattingEnabled = true;
            resources.ApplyResources(this.Categorycbx, "Categorycbx");
            this.Categorycbx.Name = "Categorycbx";
            this.Categorycbx.SelectedIndexChanged += new System.EventHandler(this.Categorycbx_SelectedIndexChanged);
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.Costtbx);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.TotalPricetbx);
            this.panel4.Controls.Add(this.Discoutnmud);
            this.panel4.Controls.Add(this.ChangeTablenud);
            this.panel4.Controls.Add(this.Paybtn);
            this.panel4.Controls.Add(this.CTbtn);
            this.panel4.Controls.Add(this.DisCountbtn);
            this.panel4.Name = "panel4";
            // 
            // Costtbx
            // 
            resources.ApplyResources(this.Costtbx, "Costtbx");
            this.Costtbx.Name = "Costtbx";
            this.Costtbx.ReadOnly = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TotalPricetbx
            // 
            resources.ApplyResources(this.TotalPricetbx, "TotalPricetbx");
            this.TotalPricetbx.Name = "TotalPricetbx";
            this.TotalPricetbx.ReadOnly = true;
            this.TotalPricetbx.TextChanged += new System.EventHandler(this.TotalPricetbx_TextChanged);
            // 
            // Discoutnmud
            // 
            resources.ApplyResources(this.Discoutnmud, "Discoutnmud");
            this.Discoutnmud.Name = "Discoutnmud";
            this.Discoutnmud.ValueChanged += new System.EventHandler(this.Discoutnmud_ValueChanged);
            // 
            // ChangeTablenud
            // 
            resources.ApplyResources(this.ChangeTablenud, "ChangeTablenud");
            this.ChangeTablenud.Name = "ChangeTablenud";
            // 
            // Paybtn
            // 
            resources.ApplyResources(this.Paybtn, "Paybtn");
            this.Paybtn.Name = "Paybtn";
            this.Paybtn.UseVisualStyleBackColor = true;
            this.Paybtn.Click += new System.EventHandler(this.Paybtn_Click);
            // 
            // CTbtn
            // 
            resources.ApplyResources(this.CTbtn, "CTbtn");
            this.CTbtn.Name = "CTbtn";
            this.CTbtn.UseVisualStyleBackColor = true;
            this.CTbtn.Click += new System.EventHandler(this.CTbtn_Click);
            // 
            // DisCountbtn
            // 
            resources.ApplyResources(this.DisCountbtn, "DisCountbtn");
            this.DisCountbtn.Name = "DisCountbtn";
            this.DisCountbtn.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.MenuLvw);
            this.panel3.Name = "panel3";
            // 
            // MenuLvw
            // 
            this.MenuLvw.AllowDrop = true;
            resources.ApplyResources(this.MenuLvw, "MenuLvw");
            this.MenuLvw.BackColor = System.Drawing.Color.White;
            this.MenuLvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.MenuLvw.HideSelection = false;
            this.MenuLvw.Name = "MenuLvw";
            this.MenuLvw.UseCompatibleStateImageBehavior = false;
            this.MenuLvw.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // Tablefpnl
            // 
            resources.ApplyResources(this.Tablefpnl, "Tablefpnl");
            this.Tablefpnl.BackColor = System.Drawing.SystemColors.Control;
            this.Tablefpnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tablefpnl.Name = "Tablefpnl";
            // 
            // FunctFrom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tablefpnl);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FunctFrom";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CountFood)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Discoutnmud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeTablenud)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown CountFood;
        private System.Windows.Forms.Button AddFoodbtn;
        private System.Windows.Forms.ComboBox Foodcbx;
        private System.Windows.Forms.ComboBox Categorycbx;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button CTbtn;
        private System.Windows.Forms.Button DisCountbtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown Discoutnmud;
        private System.Windows.Forms.NumericUpDown ChangeTablenud;
        private System.Windows.Forms.Button Paybtn;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel Tablefpnl;
        private System.Windows.Forms.ListView MenuLvw;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TotalPricetbx;
        private System.Windows.Forms.TextBox Costtbx;
    }
}