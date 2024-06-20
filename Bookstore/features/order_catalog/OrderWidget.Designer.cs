namespace Bookstore.features.order_catalog
{
    partial class OrderWidget
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
            this.labelState = new System.Windows.Forms.Label();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelBooks = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.menuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutMain.SuspendLayout();
            this.menuActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.Controls.Add(this.labelState, 2, 2);
            this.tableLayoutMain.Controls.Add(this.labelComment, 0, 2);
            this.tableLayoutMain.Controls.Add(this.labelLogin, 0, 0);
            this.tableLayoutMain.Controls.Add(this.labelStartDate, 2, 1);
            this.tableLayoutMain.Controls.Add(this.labelBooks, 0, 1);
            this.tableLayoutMain.Controls.Add(this.labelId, 2, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutMain.Size = new System.Drawing.Size(600, 96);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelState.AutoEllipsis = true;
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(423, 66);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(174, 30);
            this.labelState.TabIndex = 5;
            this.labelState.Text = "Состояние:";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComment
            // 
            this.labelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelComment.AutoEllipsis = true;
            this.labelComment.AutoSize = true;
            this.tableLayoutMain.SetColumnSpan(this.labelComment, 2);
            this.labelComment.Location = new System.Drawing.Point(3, 66);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(414, 30);
            this.labelComment.TabIndex = 2;
            this.labelComment.Text = "Комментарий:";
            this.labelComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogin.AutoEllipsis = true;
            this.labelLogin.AutoSize = true;
            this.tableLayoutMain.SetColumnSpan(this.labelLogin, 2);
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(3, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(414, 38);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Заказчик:";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate.AutoEllipsis = true;
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(423, 38);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(174, 28);
            this.labelStartDate.TabIndex = 4;
            this.labelStartDate.Text = "Создана:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBooks
            // 
            this.labelBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBooks.AutoEllipsis = true;
            this.labelBooks.AutoSize = true;
            this.tableLayoutMain.SetColumnSpan(this.labelBooks, 2);
            this.labelBooks.Location = new System.Drawing.Point(3, 38);
            this.labelBooks.Name = "labelBooks";
            this.labelBooks.Size = new System.Drawing.Size(414, 28);
            this.labelBooks.TabIndex = 3;
            this.labelBooks.Text = "Книга 1, книга 2, книга 3, книга 4";
            this.labelBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelId
            // 
            this.labelId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelId.AutoEllipsis = true;
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelId.Location = new System.Drawing.Point(423, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(174, 38);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID:";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuActions
            // 
            this.menuActions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonChange});
            this.menuActions.Name = "menuActions";
            this.menuActions.Size = new System.Drawing.Size(155, 26);
            // 
            // buttonChange
            // 
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(154, 22);
            this.buttonChange.Text = "Редактировать";
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // OrderWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.menuActions;
            this.Controls.Add(this.tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 8, 10, 8);
            this.Name = "OrderWidget";
            this.Size = new System.Drawing.Size(750, 120);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            this.menuActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelBooks;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ContextMenuStrip menuActions;
        private System.Windows.Forms.ToolStripMenuItem buttonChange;
    }
}
