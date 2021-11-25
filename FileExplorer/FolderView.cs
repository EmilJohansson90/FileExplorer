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
        private string _currentPath = Path.GetFullPath(".");
        private string _currentFileName;
        private string[] _fileArray;

        public void ListInventory()
        {
            while (true)
            {
                Console.Clear();
                if (_viewState == ViewState.List)
                {
                    ListFolder(_currentPath);
                }
                else
                {
                    WriteFile();
                }
            }
        }
        private void ListFolder(string currentPath)
        {
            ColorEdit colorEdit = new ColorEdit();
            _fileArray = Directory.GetFileSystemEntries(currentPath);

            if (_indexNumber >= _fileArray.Length) { _indexNumber = _fileArray.Length - 1; }
            if (_indexNumber < 0) { _indexNumber = 0; }

            for (int i = 0; i < _fileArray.Length; i++)
            {
                if (_indexNumber == i) { colorEdit.ChangeColor(ConsoleColor.Black, ConsoleColor.DarkGray); }

                if (File.Exists(_fileArray[i]))
                {
                    Console.WriteLine($"- {Path.GetFileName(_fileArray[i])}");
                }
                else if (Directory.Exists(_fileArray[i]))
                {
                    Console.WriteLine($"# {Path.GetFileName(_fileArray[i])}");
                }

                colorEdit.ChangeColor(ConsoleColor.White, ConsoleColor.Black);

                _currentFileName = Path.GetFileName(_fileArray[_indexNumber]);
            }

            Console.WriteLine("\n-----------------------------------------\n" +
                "Press backspace to return previous folder.");
            Navigate();
        }

        private void WriteFile()
        {
            string fileOutput = File.ReadAllText($"{_currentPath}\\{_currentFileName}");
            Console.WriteLine($"{fileOutput}\n\n" +
                $"----------------------------------\n" +
                $"Press any key to return to folder.");

            Console.ReadKey();
            _viewState = ViewState.List;
        }

        public void CheckFile(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                _currentPath = filePath;
            }
            else
            {
                Console.Clear();
                WriteFile();
            }
        }

        public void Navigate()
        {
            ConsoleKey input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.DownArrow:
                    Down();
                    break;

                case ConsoleKey.UpArrow:
                    Up();
                    break;

                case ConsoleKey.Spacebar:
                    CheckFile($"{_currentPath}\\{_currentFileName}");
                    break;

                case ConsoleKey.Backspace:
                    _currentPath = Convert.ToString(Directory.GetParent(_currentPath));
                    break;

                default:
                    break;
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
