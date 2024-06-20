namespace Bookstore.features.auth
{
    partial class AuthScreen
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
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonSigin = new System.Windows.Forms.Button();
            this.buttonReg = new System.Windows.Forms.Button();
            this.errorValidatingLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorValidatingPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidatingLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidatingPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 6;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutMain.Controls.Add(this.labelPassword, 1, 2);
            this.tableLayoutMain.Controls.Add(this.labelLogin, 1, 1);
            this.tableLayoutMain.Controls.Add(this.textBoxLogin, 2, 1);
            this.tableLayoutMain.Controls.Add(this.textBoxPassword, 2, 2);
            this.tableLayoutMain.Controls.Add(this.buttonSigin, 3, 3);
            this.tableLayoutMain.Controls.Add(this.buttonReg, 1, 3);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 5;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.Size = new System.Drawing.Size(380, 175);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(66, 70);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 35);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Пароль:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(66, 35);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(57, 35);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин:";
            this.labelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.textBoxLogin, 3);
            this.textBoxLogin.Location = new System.Drawing.Point(129, 42);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(183, 20);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.textBoxPassword, 3);
            this.textBoxPassword.Location = new System.Drawing.Point(129, 77);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(183, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonSigin
            // 
            this.buttonSigin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.buttonSigin, 2);
            this.buttonSigin.Location = new System.Drawing.Point(192, 108);
            this.buttonSigin.Name = "buttonSigin";
            this.buttonSigin.Size = new System.Drawing.Size(120, 29);
            this.buttonSigin.TabIndex = 4;
            this.buttonSigin.Text = "Войти";
            this.buttonSigin.UseVisualStyleBackColor = true;
            this.buttonSigin.Click += new System.EventHandler(this.ButtonSigin_Click);
            // 
            // buttonReg
            // 
            this.buttonReg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.SetColumnSpan(this.buttonReg, 2);
            this.buttonReg.Location = new System.Drawing.Point(66, 108);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(120, 29);
            this.buttonReg.TabIndex = 5;
            this.buttonReg.Text = "Регистрация";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.ButtonReg_Click);
            // 
            // errorValidatingLogin
            // 
            this.errorValidatingLogin.BlinkRate = 350;
            this.errorValidatingLogin.ContainerControl = this;
            // 
            // errorValidatingPassword
            // 
            this.errorValidatingPassword.BlinkRate = 350;
            this.errorValidatingPassword.ContainerControl = this;
            // 
            // AuthScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutMain);
            this.MinimumSize = new System.Drawing.Size(380, 175);
            this.Name = "AuthScreen";
            this.Size = new System.Drawing.Size(380, 175);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidatingLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidatingPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonSigin;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.ErrorProvider errorValidatingLogin;
        private System.Windows.Forms.ErrorProvider errorValidatingPassword;
    }
}
