namespace PR11_OrlovME
{
    partial class Controller_mainform
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartstopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartstopButton
            // 
            this.StartstopButton.Location = new System.Drawing.Point(315, 12);
            this.StartstopButton.Name = "StartstopButton";
            this.StartstopButton.Size = new System.Drawing.Size(75, 23);
            this.StartstopButton.TabIndex = 0;
            this.StartstopButton.Text = "play/pause";
            this.StartstopButton.UseVisualStyleBackColor = true;
            this.StartstopButton.Click += new System.EventHandler(this.StartstopButton_Click);
            this.StartstopButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Controller_mainform_KeyPress);
            this.StartstopButton.Leave += new System.EventHandler(this.StartstopButton_Leave);
            // 
            // Controller_mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 331);
            this.Controls.Add(this.StartstopButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 370);
            this.MinimumSize = new System.Drawing.Size(460, 370);
            this.Name = "Controller_mainform";
            this.Text = "Танчики - ОрловМЕ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_mainform_FormClosing);
            this.Load += new System.EventHandler(this.myform_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Controller_mainform_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartstopButton;
    }
}

