using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace METANIT_Dialogs.Services
{
    internal class DefaultDialogService : IDialogService
    {
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        public string FilePath { get; set; } = string.Empty;
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
        public string OpenFileDialog()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                return  File.ReadAllText(_openFileDialog.FileName, Encoding.UTF8); 
            }
            else
            {
                MessageBox.Show("Документ не загружен");
                return string.Empty;
            }            
        }

        public bool SaveFileDialog(string str)
        {
            if (_saveFileDialog.ShowDialog() == true)
            {
                FilePath = _saveFileDialog.FileName;
                File.WriteAllText(_saveFileDialog.FileName, str, Encoding.UTF8);
                return true;
            }
            else
            {
                MessageBox.Show("Документ не сохранён");
                return false;
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
