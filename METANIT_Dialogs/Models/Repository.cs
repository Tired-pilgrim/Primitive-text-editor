using METANIT_Dialogs.Services;
using System;
using System.Diagnostics;

namespace METANIT_Dialogs.Models
{
    internal class Repository
    {
        /// <summary>Интерфейс сервиса диалогов</summary>
        IDialogService _dialogService;
        /// <summary>Интерфейс файлового сервиса</summary>
        IFileService _fileService;
        public Repository(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }
        /// <summary>Есть ли путь для сохранения в файл</summary>
        public bool ExistsPath { get; private set; } = false;
        private string OldFilePath = string.Empty;
        public void SaveAsText(string text)
        {
            Debug.WriteLine("Сохранить");
            try
            {
                if (_dialogService.SaveFileDialog())
                {
                    ExistsPath = true;  
                    OldFilePath = _dialogService.FilePath;
                    _fileService.Save(_dialogService.FilePath, text);
                }
                else _dialogService.ShowMessage("Документ не сохранён");
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }
        public void SaveText(string text)
        {
            Debug.WriteLine("Сохранить");
            try
            {
                if (!string.IsNullOrEmpty(OldFilePath))
                     _fileService.Save(OldFilePath, text);
                else
                    _dialogService.ShowMessage("Путь сохранения файла не определён!");
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
            }
        }
        public event EventHandler<string>? LoadTextEvent;
        public void LoadText()
        {
            Debug.WriteLine("Открыть");
            try
            {
                if (_dialogService.OpenFileDialog())
                {
                    ExistsPath = true;
                    OldFilePath = _dialogService.FilePath;
                    LoadTextEvent?.Invoke(this, _fileService.Open(_dialogService.FilePath));
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessage(ex.Message);
                //ret = string.Empty;
            }
            //return ret;
        }
    }
}
