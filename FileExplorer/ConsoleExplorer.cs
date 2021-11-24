using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileExplorer
{
    class ConsoleExplorer
    {
        protected int _indexNumber = 0;

        public void Run()
        {
            FolderView folderView = new FolderView();
            folderView.ListInventory();
        }
    }
}
