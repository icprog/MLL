namespace Mulaolao.Class
{
    partial class FormChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChild));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolReview = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolExport = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolMaintain = new System.Windows.Forms.ToolStripButton();
            this.toolLibrary = new System.Windows.Forms.ToolStripButton();
            this.toolStorage = new System.Windows.Forms.ToolStripButton();
            this.toolcopy = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.toolAdd,
            this.toolDelete,
            this.toolUpdate,
            this.toolReview,
            this.toolPrint,
            this.toolExport,
            this.toolSave,
            this.toolCancel,
            this.toolMaintain,
            this.toolLibrary,
            this.toolStorage,
            this.toolcopy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSelect
            // 
            this.toolSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolSelect.Image")));
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(46, 22);
            this.toolSelect.Text = "查询";
            this.toolSelect.Click += new System.EventHandler(this.toolSelect_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(46, 22);
            this.toolAdd.Text = "新增";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(46, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolUpdate
            // 
            this.toolUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolUpdate.Image")));
            this.toolUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdate.Name = "toolUpdate";
            this.toolUpdate.Size = new System.Drawing.Size(46, 22);
            this.toolUpdate.Text = "更改";
            this.toolUpdate.Click += new System.EventHandler(this.toolUpdate_Click);
            // 
            // toolReview
            // 
            this.toolReview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolReview.Image = ((System.Drawing.Image)(resources.GetObject("toolReview.Image")));
            this.toolReview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReview.Name = "toolReview";
            this.toolReview.Size = new System.Drawing.Size(46, 22);
            this.toolReview.Text = "送审";
            this.toolReview.Click += new System.EventHandler(this.toolReview_Click);
            // 
            // toolPrint
            // 
            this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(46, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolExport
            // 
            this.toolExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolExport.Image = ((System.Drawing.Image)(resources.GetObject("toolExport.Image")));
            this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExport.Name = "toolExport";
            this.toolExport.Size = new System.Drawing.Size(46, 22);
            this.toolExport.Text = "导出";
            this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(46, 22);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(46, 22);
            this.toolCancel.Text = "取消";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // toolMaintain
            // 
            this.toolMaintain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolMaintain.Image = ((System.Drawing.Image)(resources.GetObject("toolMaintain.Image")));
            this.toolMaintain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMaintain.Name = "toolMaintain";
            this.toolMaintain.Size = new System.Drawing.Size(46, 22);
            this.toolMaintain.Text = "维护";
            this.toolMaintain.Click += new System.EventHandler(this.toolMaintain_Click);
            // 
            // toolLibrary
            // 
            this.toolLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolLibrary.Image = ((System.Drawing.Image)(resources.GetObject("toolLibrary.Image")));
            this.toolLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLibrary.Name = "toolLibrary";
            this.toolLibrary.Size = new System.Drawing.Size(46, 22);
            this.toolLibrary.Text = "出库";
            this.toolLibrary.Click += new System.EventHandler(this.toolLibrary_Click);
            // 
            // toolStorage
            // 
            this.toolStorage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStorage.Image = ((System.Drawing.Image)(resources.GetObject("toolStorage.Image")));
            this.toolStorage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStorage.Name = "toolStorage";
            this.toolStorage.Size = new System.Drawing.Size(46, 22);
            this.toolStorage.Text = "入库";
            this.toolStorage.Click += new System.EventHandler(this.toolStorage_Click);
            // 
            // toolcopy
            // 
            this.toolcopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolcopy.Image = ((System.Drawing.Image)(resources.GetObject("toolcopy.Image")));
            this.toolcopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolcopy.Name = "toolcopy";
            this.toolcopy.Size = new System.Drawing.Size(46, 22);
            this.toolcopy.Text = "复制";
            this.toolcopy.Click += new System.EventHandler(this.toolcopy_Click);
            // 
            // FormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 261);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormChild";
            this.Text = "FormChild";
            this.Load += new System.EventHandler(this.FormChild_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton toolSelect;
        public System.Windows.Forms.ToolStripButton toolAdd;
        public System.Windows.Forms.ToolStripButton toolDelete;
        public System.Windows.Forms.ToolStripButton toolUpdate;
        public System.Windows.Forms.ToolStripButton toolReview;
        public System.Windows.Forms.ToolStripButton toolPrint;
        public System.Windows.Forms.ToolStripButton toolSave;
        public System.Windows.Forms.ToolStripButton toolCancel;
        public System.Windows.Forms.ToolStripButton toolExport;
        public System.Windows.Forms.ToolStripButton toolMaintain;
        public System.Windows.Forms.ToolStripButton toolcopy;
        public System.Windows.Forms.ToolStripButton toolLibrary;
        public System.Windows.Forms.ToolStripButton toolStorage;
    }
}