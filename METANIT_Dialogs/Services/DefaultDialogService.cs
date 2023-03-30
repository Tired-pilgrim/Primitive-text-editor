using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace METANIT_Dialogs.Services
{
    internal class DefaultDialogService : IDialogService
    {
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        public string FilePath { get; set; }
        private readonly string TextFolder = Environment.CurrentDirectory + @"\Документы\";
        public DefaultDialogService() 
        {
            Directory.CreateDirectory(TextFolder);
            _openFileDialog = new()
            {
                Filter = "Текст(*.txt)|*.txt| Все файлы (*.*)|*.*",
                FileName = "Документ",
                DefaultExt = ".txt",
                InitialDirectory = TextFolder
            };
            _saveFileDialog = new()
            {
                Filter = "Текст(*.txt)|*.txt| Все файлы (*.*)|*.*",
                FileName = "Документ",
                DefaultExt = ".txt",
                InitialDirectory = TextFolder
            };

        }
        public bool OpenFileDialog()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                FilePath = _openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            if (_saveFileDialog.ShowDialog() == true)
            {
                FilePath = _saveFileDialog.FileName;
                return true;
            }
            return false;
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
