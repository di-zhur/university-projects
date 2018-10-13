namespace Delta.UI.Forms
{
    partial class CreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.teName = new System.Windows.Forms.TextBox();
            this.teOwner = new System.Windows.Forms.TextBox();
            this.teStep = new System.Windows.Forms.TextBox();
            this.teDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDataLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbDataLoad = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(132, 13);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(181, 20);
            this.teName.TabIndex = 0;
            // 
            // teOwner
            // 
            this.teOwner.Location = new System.Drawing.Point(132, 39);
            this.teOwner.Name = "teOwner";
            this.teOwner.Size = new System.Drawing.Size(181, 20);
            this.teOwner.TabIndex = 1;
            // 
            // teStep
            // 
            this.teStep.Location = new System.Drawing.Point(132, 65);
            this.teStep.Name = "teStep";
            this.teStep.Size = new System.Drawing.Size(62, 20);
            this.teStep.TabIndex = 2;
            // 
            // teDescription
            // 
            this.teDescription.Location = new System.Drawing.Point(132, 91);
            this.teDescription.Multiline = true;
            this.teDescription.Name = "teDescription";
            this.teDescription.Size = new System.Drawing.Size(181, 71);
            this.teDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Автор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Шаг прогноза";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Описание";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(157, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // btnDataLoad
            // 
            this.btnDataLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDataLoad.ImageOptions.Image")));
            this.btnDataLoad.Location = new System.Drawing.Point(132, 168);
            this.btnDataLoad.Name = "btnDataLoad";
            this.btnDataLoad.Size = new System.Drawing.Size(181, 37);
            this.btnDataLoad.TabIndex = 9;
            this.btnDataLoad.Text = "Загрузить данные";
            this.btnDataLoad.Click += new System.EventHandler(this.btnDataLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbDataLoad
            // 
            this.cbDataLoad.AutoSize = true;
            this.cbDataLoad.Enabled = false;
            this.cbDataLoad.Location = new System.Drawing.Point(233, 211);
            this.cbDataLoad.Name = "cbDataLoad";
            this.cbDataLoad.Size = new System.Drawing.Size(81, 17);
            this.cbDataLoad.TabIndex = 11;
            this.cbDataLoad.Text = "Загружено";
            this.cbDataLoad.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 267);
            this.Controls.Add(this.cbDataLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDataLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teDescription);
            this.Controls.Add(this.teStep);
            this.Controls.Add(this.teOwner);
            this.Controls.Add(this.teName);
            this.MaximumSize = new System.Drawing.Size(341, 306);
            this.MinimumSize = new System.Drawing.Size(341, 306);
            this.Name = "CreateForm";
            this.Text = "Создать прогноз";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teName;
        private System.Windows.Forms.TextBox teOwner;
        private System.Windows.Forms.TextBox teStep;
        private System.Windows.Forms.TextBox teDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDataLoad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbDataLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}