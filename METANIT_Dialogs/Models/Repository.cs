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
        public string RText { get; set; }
        public Repository(IDialogService dialogService, IFileService fileService)
        {
            _dialogService = dialogService;
            _fileService = fileService;
        }
        public void SaveText(string text)
        {
            Debug.WriteLine("Сохранить");
            try
            {
                if (_dialogService.SaveFileDialog())
                    _fileService.Save(_dialogService.FilePath, text);
                else _dialogService.ShowMessage("Документ не сохранён");
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
