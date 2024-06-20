namespace Bookstore.features.order_catalog
{
    partial class OrderCatalogScreen
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPages = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dateTimeSearch = new System.Windows.Forms.DateTimePicker();
            this.buttonBack = new System.Windows.Forms.Button();
            this.flowLayoutOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 12;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.Controls.Add(this.flowLayoutPages, 0, 11);
            this.tableLayoutMain.Controls.Add(this.textBoxSearch, 0, 1);
            this.tableLayoutMain.Controls.Add(this.dateTimeSearch, 7, 1);
            this.tableLayoutMain.Controls.Add(this.buttonBack, 0, 0);
            this.tableLayoutMain.Controls.Add(this.flowLayoutOrders, 0, 2);
            this.tableLayoutMain.Controls.Add(this.checkDate, 11, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 12;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutMain.Size = new System.Drawing.Size(700, 400);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // flowLayoutPages
            // 
            this.flowLayoutPages.AutoScroll = true;
            this.tableLayoutMain.SetColumnSpan(this.flowLayoutPages, 12);
            this.flowLayoutPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPages.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPages.Location = new System.Drawing.Point(3, 366);
            this.flowLayoutPages.Name = "flowLayoutPages";
            this.flowLayoutPages.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.flowLayoutPages.Size = new System.Drawing.Size(694, 31);
            this.flowLayoutPages.TabIndex = 0;
            this.flowLayoutPages.WrapContents = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.textBoxSearch, 7);
            this.textBoxSearch.Location = new System.Drawing.Point(3, 39);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(400, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // dateTimeSearch
            // 
            this.dateTimeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.dateTimeSearch, 4);
            this.dateTimeSearch.Location = new System.Drawing.Point(409, 39);
            this.dateTimeSearch.Name = "dateTimeSearch";
            this.dateTimeSearch.Size = new System.Drawing.Size(226, 20);
            this.dateTimeSearch.TabIndex = 1;
            this.dateTimeSearch.ValueChanged += new System.EventHandler(this.DateTimeSearch_ValueChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.AutoEllipsis = true;
            this.tableLayoutMain.SetColumnSpan(this.buttonBack, 2);
            this.buttonBack.Location = new System.Drawing.Point(3, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(110, 27);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "←Книги";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // flowLayoutOrders
            // 
            this.flowLayoutOrders.AutoScroll = true;
            this.tableLayoutMain.SetColumnSpan(this.flowLayoutOrders, 12);
            this.flowLayoutOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutOrders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutOrders.Location = new System.Drawing.Point(3, 69);
            this.flowLayoutOrders.Name = "flowLayoutOrders";
            this.flowLayoutOrders.Padding = new System.Windows.Forms.Padding(16);
            this.tableLayoutMain.SetRowSpan(this.flowLayoutOrders, 9);
            this.flowLayoutOrders.Size = new System.Drawing.Size(694, 291);
            this.flowLayoutOrders.TabIndex = 3;
            this.flowLayoutOrders.WrapContents = false;
            this.flowLayoutOrders.SizeChanged += new System.EventHandler(this.FlowLayoutOrders_SizeChanged);
            // 
            // checkDate
            // 
            this.checkDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDate.AutoSize = true;
            this.checkDate.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkDate.Location = new System.Drawing.Point(641, 42);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(56, 14);
            this.checkDate.TabIndex = 4;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.CheckDate_CheckedChanged);
            // 
            // timerSearch
            // 
            this.timerSearch.Interval = 350;
            this.timerSearch.Tick += new System.EventHandler(this.TimerSearch_Tick);
            // 
            // OrderCatalogScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutMain);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "OrderCatalogScreen";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.OrderCatalogScreen_Load);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DateTimePicker dateTimeSearch;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOrders;
        private System.Windows.Forms.Timer timerSearch;
        private System.Windows.Forms.CheckBox checkDate;
    }
}
