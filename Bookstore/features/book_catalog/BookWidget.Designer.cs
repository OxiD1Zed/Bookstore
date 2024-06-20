namespace Bookstore.features.book_catalog
{
    partial class BookWidget
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.menuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonAddBook = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonChangeBook = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDeleteBook = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutMain.SuspendLayout();
            this.menuActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.Controls.Add(this.labelAuthor, 0, 1);
            this.tableLayoutMain.Controls.Add(this.labelPrice, 1, 0);
            this.tableLayoutMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMain.Size = new System.Drawing.Size(576, 96);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAuthor.AutoEllipsis = true;
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAuthor.Location = new System.Drawing.Point(3, 57);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(368, 39);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Автор";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPrice
            // 
            this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrice.AutoEllipsis = true;
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(377, 0);
            this.labelPrice.Name = "labelPrice";
            this.tableLayoutMain.SetRowSpan(this.labelPrice, 2);
            this.labelPrice.Size = new System.Drawing.Size(196, 96);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(368, 57);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Название";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuActions
            // 
            this.menuActions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddBook,
            this.buttonChangeBook,
            this.buttonDeleteBook});
            this.menuActions.Name = "menuActions";
            this.menuActions.Size = new System.Drawing.Size(181, 92);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(180, 22);
            this.buttonAddBook.Text = "Добавить";
            this.buttonAddBook.Click += new System.EventHandler(this.ButtonAddBookInOrder_Click);
            // 
            // buttonChangeBook
            // 
            this.buttonChangeBook.Name = "buttonChangeBook";
            this.buttonChangeBook.Size = new System.Drawing.Size(180, 22);
            this.buttonChangeBook.Text = "Редактировать";
            this.buttonChangeBook.Click += new System.EventHandler(this.ButtonChangeBook_Click);
            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(180, 22);
            this.buttonDeleteBook.Text = "Удалить";
            this.buttonDeleteBook.Click += new System.EventHandler(this.ButtonDeleteBook_Click);
            // 
            // BookWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.menuActions;
            this.Controls.Add(this.tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 8, 10, 8);
            this.Name = "BookWidget";
            this.Size = new System.Drawing.Size(576, 96);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.menuActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.ContextMenuStrip menuActions;
        private System.Windows.Forms.ToolStripMenuItem buttonAddBook;
        private System.Windows.Forms.ToolStripMenuItem buttonChangeBook;
        private System.Windows.Forms.ToolStripMenuItem buttonDeleteBook;
    }
}
