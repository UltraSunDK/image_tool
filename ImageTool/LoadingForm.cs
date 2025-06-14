﻿// Form shown on program startup.
//
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class LoadingForm : Form
    {
        public LoadingForm(Settings settings)
        {
            InitializeComponent();
            progressBar.Maximum = 1000;
            
            // Try to load loading image from file if available
            try
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", settings.LoadingImageFileName);
                if (File.Exists(imagePath))
                {
                    labelLoading.Image = Image.FromFile(imagePath);
                }
                else
                {
                    // No loading image available, just show text
                    labelLoading.Image = null;
                }
            }
            catch
            {
                // Error loading image, just show text
                labelLoading.Image = null;
            }
        }

        internal void SetProgress(float v)
        {
            progressBar.Value = (int)(1000 * v);
        }
    }
}
