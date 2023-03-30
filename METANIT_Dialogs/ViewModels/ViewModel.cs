using METANIT_Dialogs.Commands;
using METANIT_Dialogs.Services;
using System;
using System.Diagnostics;

namespace METANIT_Dialogs.ViewModels
{
    internal class ViewModel: ViewModelBase
    {
        protected override void OnPropertyChanged(string? PropertyName)
        {
            base.OnPropertyChanged(PropertyName);
            if (PropertyName == nameof(Text) )
            {
                Debug.WriteLine(Text);
            }
        }
        /// <summary>Интерфейс файлового сервиса</summary>
        IFileService fileService;
        /// <summary>Интерфейс сервиса диалогов</summary>
        IDialogService dialogService;
        public RelayCommand OpenTextCommand { get; }
        public RelayCommand SaveTextCommand { get; }
        public ViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.fileService = fileService;
            this.dialogService = dialogService;
            SaveTextCommand = new RelayCommand(SaveText);
            OpenTextCommand = new RelayCommand(OpenText);
        }
        private string _text;
        public string Text
        {
            get => _text;
            set => Set(ref _text, ref value);
        }
        private void SaveText() 
        {
            Debug.WriteLine("Сохранить");
            try
            {
                if (dialogService.SaveFileDialog())
                    fileService.Save(dialogService.FilePath, Text);
                else dialogService.ShowMessage("Документ не сохранён");
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

        private void OpenText() 
        {
            Debug.WriteLine("Открыть");
            try
            {
                if (dialogService.OpenFileDialog())
                {
                    Text = fileService.Open(dialogService.FilePath);                    
                }
            }
            catch (Exception ex)
            {
                dialogService.ShowMessage(ex.Message);
            }
        }

    }
}
