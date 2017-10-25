namespace WPFTreeView
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 文件、文件夹完整路径
        /// </summary>
        public string FullPath { get; set; }
    }

    public enum DirectoryItemType
    {
        /// <summary>
        /// 逻辑盘
        /// </summary>
        Drive,

        /// <summary>
        /// 文件夹
        /// </summary>
        Folder,

        /// <summary>
        /// 文件
        /// </summary>
        File
    }
}
