// Settings dialog form for PH3 ImageTool
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

namespace ImageTool
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        private TextBox textBoxThumbnail;
        private TextBox textBoxOutputImage;
        private TextBox textBoxOutputSpec;
        private TextBox textBoxAlpha;
        private TextBox textBoxAssoc;
        private TextBox textBoxNames;
        private TextBox textBoxImageExt;
        private TextBox textBoxPostProcExt;
        private TextBox textBoxTempDir;
        private TextBox textBoxExplorer;
        private TextBox textBoxLoadingImage;
        private TextBox textBoxDefaultDir;
        private CheckBox checkBoxRememberDir;
        private Button buttonSave;
        private Button buttonCancel;
        private Button buttonRestoreDefaults;
        
        public SettingsForm(Settings currentSettings)
        {
            settings = currentSettings;
            InitializeControls();
            LoadSettingsToUI();
        }
        
        private void InitializeControls()
        {
            this.Text = "ImageTool Settings";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(500, 600);
            
            var lblY = 20;
            var txtY = 40;
            var spacing = 50;
            
            // File naming section
            var lblFileNaming = new Label
            {
                Text = "File Naming Configuration:",
                Location = new Point(20, lblY),
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblFileNaming);
            
            lblY += 25;
            txtY += 25;
            
            // Thumbnail file
            CreateLabelAndTextBox("Thumbnail File Name:", ref lblY, ref txtY, out _, out textBoxThumbnail);
            
            // Output files
            CreateLabelAndTextBox("Output Image File Name:", ref lblY, ref txtY, out _, out textBoxOutputImage);
            CreateLabelAndTextBox("Output Spec File Name:", ref lblY, ref txtY, out _, out textBoxOutputSpec);
            
            // Metadata section
            lblY += 10;
            var lblMetadata = new Label
            {
                Text = "Metadata File Names:",
                Location = new Point(20, lblY),
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblMetadata);
            
            lblY += 25;
            txtY += 25;
            
            CreateLabelAndTextBox("Alpha File Name:", ref lblY, ref txtY, out _, out textBoxAlpha);
            CreateLabelAndTextBox("Association File Name:", ref lblY, ref txtY, out _, out textBoxAssoc);
            CreateLabelAndTextBox("Names File Name:", ref lblY, ref txtY, out _, out textBoxNames);
            
            // File type section
            lblY += 10;
            var lblFileType = new Label
            {
                Text = "File Type Configuration:",
                Location = new Point(20, lblY),
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblFileType);
            
            lblY += 25;
            txtY += 25;
            
            CreateLabelAndTextBox("Image File Extension:", ref lblY, ref txtY, out _, out textBoxImageExt);
            CreateLabelAndTextBox("Post-Process Extension:", ref lblY, ref txtY, out _, out textBoxPostProcExt);
            
            // Application section
            lblY += 10;
            var lblApplication = new Label
            {
                Text = "Application Settings:",
                Location = new Point(20, lblY),
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblApplication);
            
            lblY += 25;
            txtY += 25;
            
            CreateLabelAndTextBox("Temp Directory Name:", ref lblY, ref txtY, out _, out textBoxTempDir);
            CreateLabelAndTextBox("File Explorer Command:", ref lblY, ref txtY, out _, out textBoxExplorer);
            CreateLabelAndTextBox("Loading Image File Name:", ref lblY, ref txtY, out _, out textBoxLoadingImage);
            
            // Directory section
            lblY += 10;
            var lblDirectory = new Label
            {
                Text = "Directory Settings:",
                Location = new Point(20, lblY),
                Font = new Font(Font, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblDirectory);
            
            lblY += 25;
            txtY += 25;
            
            CreateLabelAndTextBox("Default Working Directory:", ref lblY, ref txtY, out _, out textBoxDefaultDir);
            
            // Remember directory checkbox
            checkBoxRememberDir = new CheckBox
            {
                Text = "Remember last used directory",
                Location = new Point(20, txtY + 10),
                AutoSize = true
            };
            this.Controls.Add(checkBoxRememberDir);
            
            // Buttons
            buttonSave = new Button
            {
                Text = "Save",
                Location = new Point(300, 530),
                Size = new Size(80, 25)
            };
            buttonSave.Click += ButtonSave_Click;
            this.Controls.Add(buttonSave);
            
            buttonCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(390, 530),
                Size = new Size(80, 25)
            };
            buttonCancel.Click += (s, e) => this.Close();
            this.Controls.Add(buttonCancel);
            
            buttonRestoreDefaults = new Button
            {
                Text = "Restore Defaults",
                Location = new Point(20, 530),
                Size = new Size(120, 25)
            };
            buttonRestoreDefaults.Click += ButtonRestoreDefaults_Click;
            this.Controls.Add(buttonRestoreDefaults);
        }
        
        private void CreateLabelAndTextBox(string labelText, ref int lblY, ref int txtY, 
            out Label label, out TextBox textBox)
        {
            label = new Label
            {
                Text = labelText,
                Location = new Point(20, lblY),
                AutoSize = true
            };
            this.Controls.Add(label);
            
            textBox = new TextBox
            {
                Location = new Point(220, txtY - 3),
                Size = new Size(250, 20)
            };
            this.Controls.Add(textBox);
            
            lblY += 30;
            txtY += 30;
        }
        
        private void LoadSettingsToUI()
        {
            textBoxThumbnail.Text = settings.ThumbnailFileName;
            textBoxOutputImage.Text = settings.OutputImageFileName;
            textBoxOutputSpec.Text = settings.OutputSpecFileName;
            textBoxAlpha.Text = settings.AlphaFileName;
            textBoxAssoc.Text = settings.AssocFileName;
            textBoxNames.Text = settings.NamesFileName;
            textBoxImageExt.Text = settings.ImageFileExtension;
            textBoxPostProcExt.Text = settings.PostProcessOutputExtension;
            textBoxTempDir.Text = settings.TempDirectoryName;
            textBoxExplorer.Text = settings.FileExplorerCommand;
            textBoxLoadingImage.Text = settings.LoadingImageFileName;
            textBoxDefaultDir.Text = settings.DefaultWorkingDirectory;
            checkBoxRememberDir.Checked = settings.RememberLastDirectory;
        }
        
        private void SaveUIToSettings()
        {
            settings.ThumbnailFileName = textBoxThumbnail.Text;
            settings.OutputImageFileName = textBoxOutputImage.Text;
            settings.OutputSpecFileName = textBoxOutputSpec.Text;
            settings.AlphaFileName = textBoxAlpha.Text;
            settings.AssocFileName = textBoxAssoc.Text;
            settings.NamesFileName = textBoxNames.Text;
            settings.ImageFileExtension = textBoxImageExt.Text;
            settings.PostProcessOutputExtension = textBoxPostProcExt.Text;
            settings.TempDirectoryName = textBoxTempDir.Text;
            settings.FileExplorerCommand = textBoxExplorer.Text;
            settings.LoadingImageFileName = textBoxLoadingImage.Text;
            settings.DefaultWorkingDirectory = textBoxDefaultDir.Text;
            settings.RememberLastDirectory = checkBoxRememberDir.Checked;
        }
        
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBoxThumbnail.Text) ||
                string.IsNullOrWhiteSpace(textBoxOutputImage.Text) ||
                string.IsNullOrWhiteSpace(textBoxOutputSpec.Text) ||
                string.IsNullOrWhiteSpace(textBoxAlpha.Text) ||
                string.IsNullOrWhiteSpace(textBoxAssoc.Text) ||
                string.IsNullOrWhiteSpace(textBoxNames.Text) ||
                string.IsNullOrWhiteSpace(textBoxImageExt.Text) ||
                string.IsNullOrWhiteSpace(textBoxPostProcExt.Text) ||
                string.IsNullOrWhiteSpace(textBoxTempDir.Text) ||
                string.IsNullOrWhiteSpace(textBoxExplorer.Text) ||
                string.IsNullOrWhiteSpace(textBoxLoadingImage.Text))
            {
                MessageBox.Show("All fields must be filled.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveUIToSettings();
            settings.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void ButtonRestoreDefaults_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to restore default settings?", 
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                settings = new Settings();
                LoadSettingsToUI();
            }
        }
    }
}