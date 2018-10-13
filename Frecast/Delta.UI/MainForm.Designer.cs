namespace Delta.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnCreate = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnResult = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefreshGrid = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelItem = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUpdateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridFrecast = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFrecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barBtnCreate,
            this.barBtnResult,
            this.barBtnRefreshGrid,
            this.barBtnDelItem,
            this.barBtnUpdateItem,
            this.barButtonItem5,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(799, 141);
            // 
            // barBtnCreate
            // 
            this.barBtnCreate.Caption = "Создать";
            this.barBtnCreate.Id = 1;
            this.barBtnCreate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnCreate.ImageOptions.Image")));
            this.barBtnCreate.Name = "barBtnCreate";
            this.barBtnCreate.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnCreate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCreate_ItemClick);
            // 
            // barBtnResult
            // 
            this.barBtnResult.Caption = "Результат";
            this.barBtnResult.Enabled = false;
            this.barBtnResult.Id = 2;
            this.barBtnResult.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnResult.ImageOptions.Image")));
            this.barBtnResult.Name = "barBtnResult";
            this.barBtnResult.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnResult.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnResult_ItemClick);
            // 
            // barBtnRefreshGrid
            // 
            this.barBtnRefreshGrid.Caption = "Обновить";
            this.barBtnRefreshGrid.Id = 3;
            this.barBtnRefreshGrid.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRefreshGrid.ImageOptions.Image")));
            this.barBtnRefreshGrid.Name = "barBtnRefreshGrid";
            this.barBtnRefreshGrid.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnRefreshGrid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefreshGrid_ItemClick);
            // 
            // barBtnDelItem
            // 
            this.barBtnDelItem.Caption = "Удалить";
            this.barBtnDelItem.Enabled = false;
            this.barBtnDelItem.Id = 4;
            this.barBtnDelItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDelItem.ImageOptions.Image")));
            this.barBtnDelItem.Name = "barBtnDelItem";
            this.barBtnDelItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnDelItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelItem_ItemClick);
            // 
            // barBtnUpdateItem
            // 
            this.barBtnUpdateItem.Caption = "Изменить";
            this.barBtnUpdateItem.Enabled = false;
            this.barBtnUpdateItem.Id = 5;
            this.barBtnUpdateItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnUpdateItem.ImageOptions.Image")));
            this.barBtnUpdateItem.Name = "barBtnUpdateItem";
            this.barBtnUpdateItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnUpdateItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUpdateItem_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Справка";
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ошибки ";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Главная";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnCreate);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnResult);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnRefreshGrid);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnDelItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnUpdateItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Действия";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Сервис";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Функции";
            // 
            // gridFrecast
            // 
            this.gridFrecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFrecast.Location = new System.Drawing.Point(13, 148);
            this.gridFrecast.MainView = this.gridView1;
            this.gridFrecast.MenuManager = this.ribbonControl1;
            this.gridFrecast.Name = "gridFrecast";
            this.gridFrecast.Size = new System.Drawing.Size(774, 269);
            this.gridFrecast.TabIndex = 1;
            this.gridFrecast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridFrecast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridFrecast_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridFrecast;
            this.gridView1.Name = "gridView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 429);
            this.Controls.Add(this.gridFrecast);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Text = "Прогноз";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFrecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridFrecast;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barBtnCreate;
        private DevExpress.XtraBars.BarButtonItem barBtnResult;
        private DevExpress.XtraBars.BarButtonItem barBtnRefreshGrid;
        private DevExpress.XtraBars.BarButtonItem barBtnDelItem;
        private DevExpress.XtraBars.BarButtonItem barBtnUpdateItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}