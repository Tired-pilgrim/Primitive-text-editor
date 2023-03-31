using METANIT_Dialogs.Services;
using System;

namespace METANIT_Dialogs.Models
{
    public class Model
    {
        IDialogService _dialogService;
        internal Model(IDialogService dialogService)
        {
            _dialogService = dialogService;
            dialogService.LoadTextEvent += (s,e) => LoadTextEvent?.Invoke(this, e); 
        }
        public event EventHandler<string>? LoadTextEvent;
        public bool ExistsPath => _dialogService.ExistsPath;
        public void LoadText() => _dialogService.LoadText();
        public void SaveText(string text) => _dialogService.SaveText(text);
        public void SaveAsText(string text) => _dialogService.SaveAsText(text);
    }
}
