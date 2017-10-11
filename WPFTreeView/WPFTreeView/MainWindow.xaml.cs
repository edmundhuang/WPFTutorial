using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using System.IO;

namespace WPFTreeView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem();

                item.Header = drive;
                item.Tag = drive;

                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
                        var item = (TreeViewItem)sender;

            //If the item on contains the dummy data

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            var fullPath=(string) item.Tag;

            #region add folder
            var folderList = new List<string>();

            try
            {
                var folder = Directory.GetDirectories(fullPath);

                if (folder.Length > 0)
                    folderList.AddRange(folder);
            }
            catch { }


            folderList.ForEach(filePath =>
                {
                    var subItem = new TreeViewItem()
                    {
                        Header =new FileInfo(filePath).Name,
                        Tag = filePath
                    };

                    subItem.Items.Add(null);

                    subItem.Expanded += Folder_Expanded;

                    item.Items.Add(subItem);
                });

            #endregion

#region add file
            var fileList = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    fileList.AddRange(fs);
            }
            catch { }


            fileList.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = new FileInfo(filePath).Name,
                    Tag = filePath
                };

                item.Items.Add(subItem);
            });

#endregion
        }
    }
}
