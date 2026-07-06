namespace Kohya_lora_trainer
{
    partial class FormInstaller
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstaller));
            btnInstall = new Button();
            label1 = new Label();
            label2 = new Label();
            cbxUsePy = new CheckBox();
            toolTip1 = new ToolTip(components);
            cbxUseLatestTorch = new CheckBox();
            cbxPythonVersion = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnInstall
            // 
            btnInstall.Font = new Font("Yu Gothic UI", 12F);
            btnInstall.Location = new Point(182, 12);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(134, 42);
            btnInstall.TabIndex = 0;
            btnInstall.Text = "インストール";
            btnInstall.UseVisualStyleBackColor = true;
            btnInstall.Click += btnInstall_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9F);
            label1.Location = new Point(32, 141);
            label1.Name = "label1";
            label1.Size = new Size(432, 150);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 308);
            label2.Name = "label2";
            label2.Size = new Size(394, 90);
            label2.TabIndex = 2;
            label2.Text = "7回Enter押す、数字キーの1を押してからEnter押す\r\n注意:日本語環境では選択のためにカーソルキーを押すと落ちます。\r\n数字キーの0、1、2……で選択できますので、そちらを使ってください。\r\n\r\naccelerateの設定後(venv) 〇:\\〇〇\\sd-scripts>とでたらインストール完了です。\r\n完了後、GUIを再起動してください。";
            // 
            // cbxUsePy
            // 
            cbxUsePy.AutoSize = true;
            cbxUsePy.Location = new Point(85, 85);
            cbxUsePy.Name = "cbxUsePy";
            cbxUsePy.Size = new Size(202, 19);
            cbxUsePy.TabIndex = 3;
            cbxUsePy.Text = "「python」の代わりに「py」を使用する";
            toolTip1.SetToolTip(cbxUsePy, "ターミナルにpythonとだけ表示されて何も起きないか\r\nPythonバージョンを指定する場合にチェックをつけてください");
            cbxUsePy.UseVisualStyleBackColor = true;
            // 
            // cbxUseLatestTorch
            // 
            cbxUseLatestTorch.AutoSize = true;
            cbxUseLatestTorch.Checked = true;
            cbxUseLatestTorch.CheckState = CheckState.Checked;
            cbxUseLatestTorch.Location = new Point(85, 60);
            cbxUseLatestTorch.Name = "cbxUseLatestTorch";
            cbxUseLatestTorch.Size = new Size(365, 19);
            cbxUseLatestTorch.TabIndex = 6;
            cbxUseLatestTorch.Text = "Torch 2.6.0(CUDA 12.4)の代わりに 2.9.1(CUDA 13.0)をインストールする";
            toolTip1.SetToolTip(cbxUseLatestTorch, "Volta, Pascal以前のGPU使用者はチェックを外す");
            cbxUseLatestTorch.UseVisualStyleBackColor = true;
            // 
            // cbxPythonVersion
            // 
            cbxPythonVersion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPythonVersion.FormattingEnabled = true;
            cbxPythonVersion.Items.AddRange(new object[] { "3.10", "3.11", "3.12", "3.13" });
            cbxPythonVersion.Location = new Point(277, 109);
            cbxPythonVersion.Name = "cbxPythonVersion";
            cbxPythonVersion.Size = new Size(96, 23);
            cbxPythonVersion.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 112);
            label3.Name = "label3";
            label3.Size = new Size(186, 15);
            label3.TabIndex = 5;
            label3.Text = "Pythonバージョン(pyを使用する場合)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 426);
            label4.Name = "label4";
            label4.Size = new Size(301, 60);
            label4.TabIndex = 7;
            label4.Text = "インストール中のエラーや操作ミスなどで\r\n失敗したらsd-scriptsフォルダを消去してからやり直してください。\r\naccelerateの操作ミスであればGUIを再起動してから、\r\nツール>ユーティリティからaccelerate configを実行してください。";
            // 
            // FormInstaller
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(485, 507);
            Controls.Add(label4);
            Controls.Add(cbxUseLatestTorch);
            Controls.Add(label3);
            Controls.Add(cbxPythonVersion);
            Controls.Add(cbxUsePy);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnInstall);
            Font = new Font("Yu Gothic UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormInstaller";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "簡易インストーラ";
            Load += FormInstaller_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CheckBox cbxUsePy;
        private ToolTip toolTip1;
        private ComboBox cbxPythonVersion;
        private Label label3;
        private CheckBox cbxUseLatestTorch;
        private Label label4;
    }
}