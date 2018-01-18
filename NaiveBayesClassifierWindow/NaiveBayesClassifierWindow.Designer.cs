namespace NaiveBayesClassifierWindow
{
    partial class NaiveBayesClassifierWindow
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonImportTrainingData = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextTrainingData = new System.Windows.Forms.RichTextBox();
            this.SelectClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonSettingTrainingData = new System.Windows.Forms.Button();
            this.ButtonGenerateModel = new System.Windows.Forms.Button();
            this.TextTestData = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonImportTestData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectTestOption = new System.Windows.Forms.ComboBox();
            this.LabelFold = new System.Windows.Forms.Label();
            this.TextFold = new System.Windows.Forms.TextBox();
            this.LabelPercentage = new System.Windows.Forms.Label();
            this.TextPercentage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextOutput = new System.Windows.Forms.RichTextBox();
            this.ButtonClassify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Training Set：";
            // 
            // ButtonImportTrainingData
            // 
            this.ButtonImportTrainingData.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonImportTrainingData.Location = new System.Drawing.Point(441, 9);
            this.ButtonImportTrainingData.Name = "ButtonImportTrainingData";
            this.ButtonImportTrainingData.Size = new System.Drawing.Size(75, 23);
            this.ButtonImportTrainingData.TabIndex = 2;
            this.ButtonImportTrainingData.Text = "Import";
            this.ButtonImportTrainingData.UseVisualStyleBackColor = true;
            this.ButtonImportTrainingData.Click += new System.EventHandler(this.ButtonImportTrainingData_ClickAsync);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            this.OpenFileDialog.Filter = "Attribute-Relation File Format|*.arff|All File|*.*";
            this.OpenFileDialog.Title = "Import File";
            // 
            // TextTrainingData
            // 
            this.TextTrainingData.AutoWordSelection = true;
            this.TextTrainingData.DetectUrls = false;
            this.TextTrainingData.EnableAutoDragDrop = true;
            this.TextTrainingData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTrainingData.Location = new System.Drawing.Point(16, 35);
            this.TextTrainingData.Name = "TextTrainingData";
            this.TextTrainingData.Size = new System.Drawing.Size(500, 300);
            this.TextTrainingData.TabIndex = 3;
            this.TextTrainingData.Text = "";
            this.TextTrainingData.WordWrap = false;
            // 
            // SelectClass
            // 
            this.SelectClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectClass.Enabled = false;
            this.SelectClass.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectClass.FormattingEnabled = true;
            this.SelectClass.Location = new System.Drawing.Point(646, 35);
            this.SelectClass.MaxDropDownItems = 100;
            this.SelectClass.Name = "SelectClass";
            this.SelectClass.Size = new System.Drawing.Size(121, 26);
            this.SelectClass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(522, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Class：";
            // 
            // ButtonSettingTrainingData
            // 
            this.ButtonSettingTrainingData.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ButtonSettingTrainingData.Location = new System.Drawing.Point(522, 9);
            this.ButtonSettingTrainingData.Name = "ButtonSettingTrainingData";
            this.ButtonSettingTrainingData.Size = new System.Drawing.Size(114, 23);
            this.ButtonSettingTrainingData.TabIndex = 4;
            this.ButtonSettingTrainingData.Text = "Setting Data";
            this.ButtonSettingTrainingData.UseVisualStyleBackColor = true;
            this.ButtonSettingTrainingData.Click += new System.EventHandler(this.ButtonSettingTrainingData_Click);
            // 
            // ButtonGenerateModel
            // 
            this.ButtonGenerateModel.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ButtonGenerateModel.Location = new System.Drawing.Point(913, 126);
            this.ButtonGenerateModel.Name = "ButtonGenerateModel";
            this.ButtonGenerateModel.Size = new System.Drawing.Size(114, 23);
            this.ButtonGenerateModel.TabIndex = 7;
            this.ButtonGenerateModel.Text = "Generate Model";
            this.ButtonGenerateModel.UseVisualStyleBackColor = true;
            this.ButtonGenerateModel.Click += new System.EventHandler(this.ButtonGenerateModel_Click);
            // 
            // TextTestData
            // 
            this.TextTestData.AutoWordSelection = true;
            this.TextTestData.DetectUrls = false;
            this.TextTestData.EnableAutoDragDrop = true;
            this.TextTestData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTestData.Location = new System.Drawing.Point(16, 364);
            this.TextTestData.Name = "TextTestData";
            this.TextTestData.Size = new System.Drawing.Size(500, 150);
            this.TextTestData.TabIndex = 8;
            this.TextTestData.Text = "";
            this.TextTestData.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Test Set：";
            // 
            // ButtonImportTestData
            // 
            this.ButtonImportTestData.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonImportTestData.Location = new System.Drawing.Point(441, 338);
            this.ButtonImportTestData.Name = "ButtonImportTestData";
            this.ButtonImportTestData.Size = new System.Drawing.Size(75, 23);
            this.ButtonImportTestData.TabIndex = 10;
            this.ButtonImportTestData.Text = "Import";
            this.ButtonImportTestData.UseVisualStyleBackColor = true;
            this.ButtonImportTestData.Click += new System.EventHandler(this.ButtonImportTestData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(522, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Test Option：";
            // 
            // SelectTestOption
            // 
            this.SelectTestOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectTestOption.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTestOption.FormattingEnabled = true;
            this.SelectTestOption.Items.AddRange(new object[] {
            "Use Test Set",
            "Cross-Validation",
            "Percentage Split"});
            this.SelectTestOption.Location = new System.Drawing.Point(646, 69);
            this.SelectTestOption.MaxDropDownItems = 100;
            this.SelectTestOption.Name = "SelectTestOption";
            this.SelectTestOption.Size = new System.Drawing.Size(153, 26);
            this.SelectTestOption.TabIndex = 12;
            this.SelectTestOption.SelectedIndexChanged += new System.EventHandler(this.SelectTestOption_SelectedIndexChanged);
            // 
            // LabelFold
            // 
            this.LabelFold.AutoSize = true;
            this.LabelFold.Enabled = false;
            this.LabelFold.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFold.Location = new System.Drawing.Point(805, 68);
            this.LabelFold.Name = "LabelFold";
            this.LabelFold.Size = new System.Drawing.Size(71, 23);
            this.LabelFold.TabIndex = 13;
            this.LabelFold.Text = "Folds：";
            // 
            // TextFold
            // 
            this.TextFold.Font = new System.Drawing.Font("Consolas", 10F);
            this.TextFold.Location = new System.Drawing.Point(927, 68);
            this.TextFold.Name = "TextFold";
            this.TextFold.Size = new System.Drawing.Size(100, 23);
            this.TextFold.TabIndex = 14;
            this.TextFold.Text = "10";
            // 
            // LabelPercentage
            // 
            this.LabelPercentage.AutoSize = true;
            this.LabelPercentage.Enabled = false;
            this.LabelPercentage.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPercentage.Location = new System.Drawing.Point(805, 94);
            this.LabelPercentage.Name = "LabelPercentage";
            this.LabelPercentage.Size = new System.Drawing.Size(116, 23);
            this.LabelPercentage.TabIndex = 15;
            this.LabelPercentage.Text = "Percentage：";
            // 
            // TextPercentage
            // 
            this.TextPercentage.Enabled = false;
            this.TextPercentage.Font = new System.Drawing.Font("Consolas", 10F);
            this.TextPercentage.Location = new System.Drawing.Point(927, 97);
            this.TextPercentage.Name = "TextPercentage";
            this.TextPercentage.Size = new System.Drawing.Size(100, 23);
            this.TextPercentage.TabIndex = 16;
            this.TextPercentage.Text = "66";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(522, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Output：";
            // 
            // TextOutput
            // 
            this.TextOutput.AutoWordSelection = true;
            this.TextOutput.DetectUrls = false;
            this.TextOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextOutput.Location = new System.Drawing.Point(526, 185);
            this.TextOutput.Name = "TextOutput";
            this.TextOutput.ReadOnly = true;
            this.TextOutput.Size = new System.Drawing.Size(501, 329);
            this.TextOutput.TabIndex = 18;
            this.TextOutput.Text = "";
            this.TextOutput.WordWrap = false;
            // 
            // ButtonClassify
            // 
            this.ButtonClassify.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClassify.Location = new System.Drawing.Point(526, 126);
            this.ButtonClassify.Name = "ButtonClassify";
            this.ButtonClassify.Size = new System.Drawing.Size(75, 23);
            this.ButtonClassify.TabIndex = 19;
            this.ButtonClassify.Text = "Classify";
            this.ButtonClassify.UseVisualStyleBackColor = true;
            this.ButtonClassify.Click += new System.EventHandler(this.ButtonClassify_Click);
            // 
            // NaiveBayesClassifierWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 532);
            this.Controls.Add(this.ButtonClassify);
            this.Controls.Add(this.TextOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextPercentage);
            this.Controls.Add(this.LabelPercentage);
            this.Controls.Add(this.TextFold);
            this.Controls.Add(this.LabelFold);
            this.Controls.Add(this.SelectTestOption);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonImportTestData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextTestData);
            this.Controls.Add(this.ButtonGenerateModel);
            this.Controls.Add(this.ButtonSettingTrainingData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectClass);
            this.Controls.Add(this.TextTrainingData);
            this.Controls.Add(this.ButtonImportTrainingData);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NaiveBayesClassifierWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NaiveBayesClassifier";
            this.Load += new System.EventHandler(this.NaiveBayesClassifierWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonImportTrainingData;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.RichTextBox TextTrainingData;
        private System.Windows.Forms.ComboBox SelectClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonSettingTrainingData;
        private System.Windows.Forms.Button ButtonGenerateModel;
        private System.Windows.Forms.RichTextBox TextTestData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonImportTestData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SelectTestOption;
        private System.Windows.Forms.Label LabelFold;
        private System.Windows.Forms.TextBox TextFold;
        private System.Windows.Forms.Label LabelPercentage;
        private System.Windows.Forms.TextBox TextPercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox TextOutput;
        private System.Windows.Forms.Button ButtonClassify;
    }
}

