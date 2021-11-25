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
        protected ViewState _viewState;

        public ConsoleExplorer()
        {
            _viewState = ViewState.List;
        }
        
        public void Run()
        {
            FolderView folderView = new FolderView();
            folderView.ListInventory();
        }

        public void Up()
        {
            _indexNumber--;
        }

        public void Down()
        {
            _indexNumber++;
        }
    }
}
