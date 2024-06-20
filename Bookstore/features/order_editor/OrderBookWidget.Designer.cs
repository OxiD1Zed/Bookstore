namespace Bookstore.features.order_editor
{
    partial class OrderBookWidget
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
            this.bookWidget = new Bookstore.features.book_catalog.BookWidget();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.menuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonDeleteBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.menuActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.Controls.Add(this.bookWidget, 0, 0);
            this.tableLayoutMain.Controls.Add(this.numericQuantity, 1, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(361, 75);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // bookWidget
            // 
            this.bookWidget.Book = null;
            this.bookWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookWidget.Location = new System.Drawing.Point(4, 8);
            this.bookWidget.Margin = new System.Windows.Forms.Padding(4, 8, 10, 8);
            this.bookWidget.Name = "bookWidget";
            this.bookWidget.Size = new System.Drawing.Size(274, 59);
            this.bookWidget.TabIndex = 0;
            this.bookWidget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericQuantity.Location = new System.Drawing.Point(291, 27);
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(67, 20);
            this.numericQuantity.TabIndex = 1;
            this.numericQuantity.ValueChanged += new System.EventHandler(this.NumericQuantity_ValueChanged);
            // 
            // menuActions
            // 
            this.menuActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDeleteBook});
            this.menuActions.Name = "menuActions";
            this.menuActions.Size = new System.Drawing.Size(95, 21);
            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(118, 22);
            this.buttonDeleteBook.Text = "Удалить";
            this.buttonDeleteBook.Click += new System.EventHandler(this.ButtonRemoveBook_Click);
            // 
            // OrderBookWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.menuActions;
            this.Controls.Add(this.tableLayoutMain);
            this.Name = "OrderBookWidget";
            this.Size = new System.Drawing.Size(361, 75);
            this.tableLayoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.menuActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private book_catalog.BookWidget bookWidget;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.ContextMenuStrip menuActions;
        private System.Windows.Forms.ToolStripMenuItem buttonDeleteBook;
    }
}
