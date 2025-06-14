﻿namespace ImageTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonSaveOutput = new System.Windows.Forms.Button();
            this.buttonLoadOutputSpec = new System.Windows.Forms.Button();
            this.buttonNavPrev = new System.Windows.Forms.Button();
            this.buttonNavNext = new System.Windows.Forms.Button();
            this.buttonSaveAndNext = new System.Windows.Forms.Button();
            this.buttonNavJump = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonClearOutput = new System.Windows.Forms.Button();
            this.buttonAlphaFix = new System.Windows.Forms.Button();
            this.buttonRestoreInputs = new System.Windows.Forms.Button();
            this.buttonITP = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonChangeDir = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1584, 704);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1584, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip_Paint);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonSaveOutput
            // 
            this.buttonSaveOutput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSaveOutput.Location = new System.Drawing.Point(469, 3);
            this.buttonSaveOutput.Name = "buttonSaveOutput";
            this.buttonSaveOutput.Size = new System.Drawing.Size(81, 23);
            this.buttonSaveOutput.TabIndex = 3;
            this.buttonSaveOutput.Text = "Save Output";
            this.buttonSaveOutput.UseVisualStyleBackColor = true;
            this.buttonSaveOutput.Click += new System.EventHandler(this.buttonSaveOutput_Click);
            // 
            // buttonLoadOutputSpec
            // 
            this.buttonLoadOutputSpec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonLoadOutputSpec.Location = new System.Drawing.Point(643, 3);
            this.buttonLoadOutputSpec.Name = "buttonLoadOutputSpec";
            this.buttonLoadOutputSpec.Size = new System.Drawing.Size(123, 23);
            this.buttonLoadOutputSpec.TabIndex = 4;
            this.buttonLoadOutputSpec.Text = "Load Output Spec";
            this.buttonLoadOutputSpec.UseVisualStyleBackColor = true;
            this.buttonLoadOutputSpec.Click += new System.EventHandler(this.buttonLoadOutputSpec_Click);
            // 
            // buttonNavPrev
            // 
            this.buttonNavPrev.Location = new System.Drawing.Point(12, 3);
            this.buttonNavPrev.Name = "buttonNavPrev";
            this.buttonNavPrev.Size = new System.Drawing.Size(53, 23);
            this.buttonNavPrev.TabIndex = 5;
            this.buttonNavPrev.Text = "< Prev";
            this.buttonNavPrev.UseVisualStyleBackColor = true;
            this.buttonNavPrev.Click += new System.EventHandler(this.buttonNavPrev_Click);
            // 
            // buttonNavNext
            // 
            this.buttonNavNext.Location = new System.Drawing.Point(71, 3);
            this.buttonNavNext.Name = "buttonNavNext";
            this.buttonNavNext.Size = new System.Drawing.Size(53, 23);
            this.buttonNavNext.TabIndex = 6;
            this.buttonNavNext.Text = "Next >";
            this.buttonNavNext.UseVisualStyleBackColor = true;
            this.buttonNavNext.Click += new System.EventHandler(this.buttonNavNext_Click);
            // 
            // buttonSaveAndNext
            // 
            this.buttonSaveAndNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSaveAndNext.Location = new System.Drawing.Point(556, 3);
            this.buttonSaveAndNext.Name = "buttonSaveAndNext";
            this.buttonSaveAndNext.Size = new System.Drawing.Size(81, 23);
            this.buttonSaveAndNext.TabIndex = 7;
            this.buttonSaveAndNext.Text = "Save && Next";
            this.buttonSaveAndNext.UseVisualStyleBackColor = true;
            this.buttonSaveAndNext.Click += new System.EventHandler(this.buttonSaveAndNext_Click);
            // 
            // buttonNavJump
            // 
            this.buttonNavJump.Location = new System.Drawing.Point(130, 3);
            this.buttonNavJump.Name = "buttonNavJump";
            this.buttonNavJump.Size = new System.Drawing.Size(127, 23);
            this.buttonNavJump.TabIndex = 8;
            this.buttonNavJump.Text = "Texture Navigation";
            this.buttonNavJump.UseVisualStyleBackColor = true;
            this.buttonNavJump.Click += new System.EventHandler(this.buttonNavJump_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(1469, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(103, 23);
            this.buttonHelp.TabIndex = 9;
            this.buttonHelp.Text = "Help && About";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonClearOutput
            // 
            this.buttonClearOutput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClearOutput.Location = new System.Drawing.Point(772, 3);
            this.buttonClearOutput.Name = "buttonClearOutput";
            this.buttonClearOutput.Size = new System.Drawing.Size(106, 23);
            this.buttonClearOutput.TabIndex = 10;
            this.buttonClearOutput.Text = "Clear Output [!]";
            this.buttonClearOutput.UseVisualStyleBackColor = true;
            this.buttonClearOutput.Click += new System.EventHandler(this.buttonClearOutput_Click);
            // 
            // buttonAlphaFix
            // 
            this.buttonAlphaFix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAlphaFix.Location = new System.Drawing.Point(919, 3);
            this.buttonAlphaFix.Name = "buttonAlphaFix";
            this.buttonAlphaFix.Size = new System.Drawing.Size(144, 23);
            this.buttonAlphaFix.TabIndex = 11;
            this.buttonAlphaFix.Text = "Fix Alpha In Upscales [!]";
            this.buttonAlphaFix.UseVisualStyleBackColor = true;
            this.buttonAlphaFix.Click += new System.EventHandler(this.buttonAlphaFix_Click);
            // 
            // buttonRestoreInputs
            // 
            this.buttonRestoreInputs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRestoreInputs.Location = new System.Drawing.Point(1069, 3);
            this.buttonRestoreInputs.Name = "buttonRestoreInputs";
            this.buttonRestoreInputs.Size = new System.Drawing.Size(97, 23);
            this.buttonRestoreInputs.TabIndex = 12;
            this.buttonRestoreInputs.Text = "Restore Inputs";
            this.buttonRestoreInputs.UseVisualStyleBackColor = true;
            this.buttonRestoreInputs.Click += new System.EventHandler(this.buttonRestoreInputs_Click);
            // 
            // buttonITP
            // 
            this.buttonITP.Location = new System.Drawing.Point(263, 3);
            this.buttonITP.Name = "buttonITP";
            this.buttonITP.Size = new System.Drawing.Size(103, 23);
            this.buttonITP.TabIndex = 13;
            this.buttonITP.Text = "Postprocessing";
            this.buttonITP.UseVisualStyleBackColor = true;
            this.buttonITP.Click += new System.EventHandler(this.buttonITP_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(1360, 3);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(103, 23);
            this.buttonSettings.TabIndex = 14;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonChangeDir
            // 
            this.buttonChangeDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeDir.Location = new System.Drawing.Point(1220, 3);
            this.buttonChangeDir.Name = "buttonChangeDir";
            this.buttonChangeDir.Size = new System.Drawing.Size(134, 23);
            this.buttonChangeDir.TabIndex = 15;
            this.buttonChangeDir.Text = "Change Directory";
            this.buttonChangeDir.UseVisualStyleBackColor = true;
            this.buttonChangeDir.Click += new System.EventHandler(this.buttonChangeDir_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.buttonChangeDir);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonITP);
            this.Controls.Add(this.buttonRestoreInputs);
            this.Controls.Add(this.buttonAlphaFix);
            this.Controls.Add(this.buttonClearOutput);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonNavJump);
            this.Controls.Add(this.buttonSaveAndNext);
            this.Controls.Add(this.buttonNavNext);
            this.Controls.Add(this.buttonNavPrev);
            this.Controls.Add(this.buttonLoadOutputSpec);
            this.Controls.Add(this.buttonSaveOutput);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PH3 ImageTool";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Button buttonSaveOutput;
        private Button buttonLoadOutputSpec;
        private Button buttonNavPrev;
        private Button buttonNavNext;
        private Button buttonSaveAndNext;
        private Button buttonNavJump;
        private Button buttonHelp;
        private Button buttonClearOutput;
        private Button buttonAlphaFix;
        private Button buttonRestoreInputs;
        private Button buttonITP;
        private Button buttonSettings;
        private Button buttonChangeDir;
    }
}