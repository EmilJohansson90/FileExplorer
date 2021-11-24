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

                if (_viewState == ViewState.List)
                {
                    for (int i = 0; i < fileArray.Length; i++)
                    {
                        if (_indexNumber == i)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (File.Exists(fileArray[i]))
                        {
                            Console.WriteLine($"- {Path.GetFileName(fileArray[i])}");
                        }
                        else if (Directory.Exists(fileArray[i]))
                        {
                            Console.WriteLine($"# {Path.GetFileName(fileArray[i])}");
                        }

                        _currentFileName = Path.GetFileName(fileArray[i]);
                    }                    
                } else
                {
                    Console.WriteLine(File.ReadAllText($"{_currentFileName}"));
                    Console.WriteLine("\n\nTryck på valfri tangent för att gå tillbaka till listan");
                    Console.ReadKey();
                    _viewState = ViewState.List;
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
