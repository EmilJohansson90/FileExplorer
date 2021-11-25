using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileExplorer
{
    class FolderView : ConsoleExplorer
    {
        private string _currentFileName;

        public void ListInventory()
        {
            while (true)
            {                
                Console.Clear();
                string[] fileArray = Directory.GetFileSystemEntries(".");

                for (int i = 0; i < fileArray.Length; i++)
                {
                    if(_indexNumber == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }                   

                    if (File.Exists(fileArray[i]))
                    {
                        Console.WriteLine($"- {Path.GetFileName(fileArray[i])}");
                    }
                    else if (Directory.Exists(fileArray[i]))
                    {
                        Console.WriteLine($"# {Path.GetFileName(fileArray[i])}");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                }

                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.DownArrow && _indexNumber < fileArray.Length)
                {
                    Down();
                }
                else if (input == ConsoleKey.UpArrow && _indexNumber > 0)
                {
                    Up();
                } else if(input == ConsoleKey.Spacebar)
                {
                    _viewState = ViewState.FileView;
                }
            }
        }

        public string CurrentFileName
        {
            get
            {
                return _currentFileName;
            }
        }
    }
}
