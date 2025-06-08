// Copyright(C) 2022 Peter Thoman / PH3 GmbH
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

using System.IO;

namespace ImageTool
{
    internal static class Program
    {
        public readonly static string VERSION = "1.0.0";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            
            // Load settings
            var settings = Settings.Load();
            
            // Determine working directory
            string workingDir = null;
            if(args.Length > 0) 
            {
                workingDir = args[0];
            }
            else if(settings.RememberLastDirectory && !string.IsNullOrEmpty(settings.LastUsedDirectory) && Directory.Exists(settings.LastUsedDirectory))
            {
                workingDir = settings.LastUsedDirectory;
            }
            else if(!string.IsNullOrEmpty(settings.DefaultWorkingDirectory) && Directory.Exists(settings.DefaultWorkingDirectory))
            {
                workingDir = settings.DefaultWorkingDirectory;
            }
            
            // If no valid directory found, prompt user to select one
            if (string.IsNullOrEmpty(workingDir) || !Directory.Exists(workingDir))
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select the folder containing your image directories";
                    folderDialog.ShowNewFolderButton = false;
                    
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        workingDir = folderDialog.SelectedPath;
                        // Save this as the last used directory
                        settings.LastUsedDirectory = workingDir;
                        settings.Save();
                    }
                    else
                    {
                        // User cancelled, exit application
                        return;
                    }
                }
            }
            
            Directory.SetCurrentDirectory(workingDir);
            var folderlist = Directory.GetDirectories(".").Select(x => x.Replace(".\\", "")).ToArray();
            Array.Sort(folderlist);
            
            if (folderlist.Length == 0)
            {
                MessageBox.Show("No subdirectories found in the selected folder. Please ensure the folder contains image directories.", 
                    "No Images Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Application.Run(new MainForm(folderlist, settings));
        }

        // This is a workaround regarding some of the most inane API design I've ever encountered in a widespread product.
        // If you load an "Image" from a file directly, then that file handle will be kept open for the lifetime of the image. That's obviously not what you want.
        // If you load it from a stream, then, if you do not keep that stream open, you will seemingly randomly get "Out of Memory" exceptions when performing some subset of operations on the image.
        // So we load it from a stream as a bitmap and manually deep copy from that.
        public static Image ReadImageFromFile(string fn)
        {
            using (FileStream fs = new FileStream(fn, FileMode.Open))
            {
                using (Bitmap bmp = new Bitmap(fs)) {
                    return new Bitmap(bmp);
                }
            }
        }
    }
}