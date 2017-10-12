using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTreeView
{
    public class DirectoryItem
    {
        public DirectoryType DirectoryType { get; set; }

        public bool isExpanded { get; set; }


    }

    public enum DirectoryType
    {
        Drive,
        Folder,
        File
    }
}
