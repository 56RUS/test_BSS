namespace bss
{
    partial class Form1
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
            this.btnSaveInXml = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveInXml
            // 
            this.btnSaveInXml.Location = new System.Drawing.Point(152, 12);
            this.btnSaveInXml.Name = "btnSaveInXml";
            this.btnSaveInXml.Size = new System.Drawing.Size(122, 47);
            this.btnSaveInXml.TabIndex = 2;
            this.btnSaveInXml.Text = "Сохранить данные из БД в xml-файл";
            this.btnSaveInXml.UseVisualStyleBackColor = true;
            this.btnSaveInXml.Click += new System.EventHandler(this.btnSaveInXml_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(122, 47);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Сохранить данные из xml-файла в БД";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 71);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnSaveInXml);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тест";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSaveInXml;
        private System.Windows.Forms.Button btnSelectFolder;
    }
}

