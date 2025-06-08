// Settings management for PH3 ImageTool
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

using System.Text.Json;

namespace ImageTool
{
    public class Settings
    {
        // File naming configuration
        public string ThumbnailFileName { get; set; } = "thumbnail.png";
        public string OutputImageFileName { get; set; } = "output.png";
        public string OutputSpecFileName { get; set; } = "output_spec.json";
        
        // Metadata file names
        public string AlphaFileName { get; set; } = "alpha.txt";
        public string AssocFileName { get; set; } = "assoc.txt";
        public string NamesFileName { get; set; } = "names.txt";
        
        // File type configuration
        public string ImageFileExtension { get; set; } = ".png";
        public string PostProcessOutputExtension { get; set; } = "itp";
        
        // Application settings
        public string TempDirectoryName { get; set; } = "ImageTool";
        public string FileExplorerCommand { get; set; } = "explorer.exe";
        public string LoadingImageFileName { get; set; } = "loading_image.png";
        
        // Directory settings
        public string DefaultWorkingDirectory { get; set; } = "";
        public string LastUsedDirectory { get; set; } = "";
        
        // UI preferences
        public bool RememberLastDirectory { get; set; } = true;
        
        private static string GetSettingsPath()
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PH3ImageTool"
            );
            Directory.CreateDirectory(path);
            return Path.Combine(path, "settings.json");
        }
        
        public void Save()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(GetSettingsPath(), jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public static Settings Load()
        {
            try
            {
                string settingsPath = GetSettingsPath();
                if (File.Exists(settingsPath))
                {
                    string jsonString = File.ReadAllText(settingsPath);
                    return JsonSerializer.Deserialize<Settings>(jsonString) ?? new Settings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings: {ex.Message}\nUsing defaults.", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return new Settings();
        }
        
        public string GetOutputImagePath(string folder)
        {
            return Path.Combine(folder, OutputImageFileName);
        }
        
        public string GetOutputSpecPath(string folder)
        {
            return Path.Combine(folder, OutputSpecFileName);
        }
        
        public string GetThumbnailPath(string folder)
        {
            return Path.Combine(folder, ThumbnailFileName);
        }
    }
}