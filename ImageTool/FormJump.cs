﻿// The navigation form code, primarily list box drawing / filtering.
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class FormJump : Form
    {
        MainForm mainForm;
        string[] rootFolderList;
        string[] folderList;
        Settings settings;

        Font font, nameFont, smallFont, emoFont;

        public FormJump(MainForm mainForm, string[] folderList, string selectedFolder, Settings settings)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.settings = settings;
            rootFolderList = folderList.Select(x => x.ToString()).ToArray();
            this.folderList = folderList;

            font = new Font(Font.Name, 12);
            nameFont = new Font(Font.Name, 10, FontStyle.Bold);
            smallFont = new Font(Font.Name, 7);
            emoFont = new Font("Segoe UI Emoji", 14);

            listBox.Items.AddRange(folderList);
            listBox.SelectedItem = selectedFolder;
        }

        private void applySelect()
        {
            if (listBox.SelectedItem != null)
            {
                mainForm.LoadFolder((string)listBox.SelectedItem);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            applySelect();
            Hide();
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            string folder = folderList[e.Index];

            e.Graphics.FillRectangle(selected ? Brushes.LightSkyBlue : SystemBrushes.ControlLight, e.Bounds);
            var bot = e.Bounds.Y;
            e.Graphics.DrawLine(SystemPens.ControlDarkDark, e.Bounds.X, bot, e.Bounds.Width, bot);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            var stringRect = e.Bounds;
            stringRect.X = 40;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(folder, font, Brushes.Black, stringRect, stringFormat);
            stringRect.X += (int)e.Graphics.MeasureString(folder, font).Width + 5;
            
            // draw (original Falcom) texture name if available
            if (mainForm.Names.ContainsKey(folder))
            {
                string name = mainForm.Names[folder];
                e.Graphics.DrawString(name, nameFont, Brushes.Black, stringRect, stringFormat);
                stringRect.X += (int)e.Graphics.MeasureString(name, nameFont).Width + 5;
            }

            stringRect.Width = listBox.Width - stringRect.X - 104;
            e.Graphics.DrawString(mainForm.Assocs[folder], smallFont, Brushes.Black, stringRect, stringFormat);
            stringRect.Width = e.Bounds.Width;

            if (mainForm.HasOutput[folder])
            {
                stringRect.X = listBox.Width - 56;
                e.Graphics.DrawString("☑", emoFont, Brushes.Black, stringRect, stringFormat);
            }

            if (mainForm.HasRedraw[folder])
            {
                stringRect.X = listBox.Width - 80;
                e.Graphics.DrawString("🖌", emoFont, Brushes.DarkRed, stringRect, stringFormat);
            }

            if (mainForm.HasAlpha[folder])
            {
                stringRect.X = listBox.Width - 104;
                e.Graphics.DrawString("☁️", emoFont, Brushes.Gray, stringRect, stringFormat);
            }

            var s = listBox.ItemHeight;
            if (mainForm.Thumbnails.ContainsKey(folder)) // if a thumbnail couldn't be generated for some reason, don't fail, just don't draw it
            {
                var img = mainForm.Thumbnails[folder];
                var imgRect = new Rectangle(0, e.Bounds.Y, Math.Min(s * img.Width / img.Height, s), s);
                e.Graphics.DrawImage(img, imgRect);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            folderList = rootFolderList.Where(f => 
                f.Contains(textBoxFilter.Text) 
                || (checkBoxSearchAssoc.Checked && mainForm.Assocs[f].Contains(textBoxFilter.Text))
                || (checkBoxSearchNames.Checked && mainForm.Names[f].Contains(textBoxFilter.Text))
            ).ToArray();
            if (checkBoxFilterOutput.CheckState == CheckState.Checked)
            {
                folderList = folderList.Where(f => mainForm.HasOutput[f]).ToArray();
            }
            if (checkBoxFilterOutput.CheckState == CheckState.Indeterminate)
            {
                folderList = folderList.Where(f => !mainForm.HasOutput[f]).ToArray();
            }
            if (checkBoxFilterRedraw.CheckState == CheckState.Checked)
            {
                folderList = folderList.Where(f => mainForm.HasRedraw[f]).ToArray();
            }
            if (checkBoxFilterRedraw.CheckState == CheckState.Indeterminate)
            {
                folderList = folderList.Where(f => !mainForm.HasRedraw[f]).ToArray();
            }
            if (checkBoxFilterAlpha.CheckState == CheckState.Checked)
            {
                folderList = folderList.Where(f => mainForm.HasAlpha[f]).ToArray();
            }
            if (checkBoxFilterAlpha.CheckState == CheckState.Indeterminate)
            {
                folderList = folderList.Where(f => !mainForm.HasAlpha[f]).ToArray();
            }
            listBox.Items.Clear();
            listBox.Items.AddRange(folderList);

            Text = String.Format("Jump to Texture - {0} filtered", listBox.Items.Count);
        }

        private void listBox_Resize(object sender, EventArgs e)
        {
            listBox.Refresh();
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            applySelect();
        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
        }

        private void toolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItem != null)
            {
                Process.Start(settings.FileExplorerCommand, Path.GetFullPath(".\\" + listBox.SelectedItem.ToString()));
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            mainForm.ReloadMetainformation();
            Refresh();
        }

        internal void NavPrev()
        {
            var idx = listBox.SelectedIndex;
            if (idx > 0) listBox.SelectedIndex--;
            applySelect();
        }

        internal void NavNext()
        {
            var idx = listBox.SelectedIndex;
            if (idx < listBox.Items.Count-1) listBox.SelectedIndex++;
            applySelect();
        }
    }
}
