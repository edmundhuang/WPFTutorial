using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace WPFTreeView
{
    /// <summary>
    /// A Help class for getting directory info
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Get all logical drivers from computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrive()
        {
            return Directory.GetLogicalDrives().Select(c => new DirectoryItem { FullPath = c, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// get all content from path
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetFileFolderContent(string fullPath)
        {
            var items=new List<DirectoryItem> ();

            try
            {
                var folder = Directory.GetDirectories(fullPath);

                if (folder.Length > 0)
                    items.AddRange(folder.Select( c => new DirectoryItem { FullPath=c, Type=DirectoryItemType.Folder }));
            }
            catch { }


            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select( c=> new DirectoryItem { FullPath=c, Type=DirectoryItemType.File}));
            }
            catch { }


            return items;
        }



    }
}
