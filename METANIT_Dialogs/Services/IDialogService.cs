using System;

namespace METANIT_Dialogs.Services
{
    internal interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; set; }   // путь к выбранному файлу
        bool LoadText();  // открытие файла
        bool SaveAsText(string str);  // сохранение файла
        bool SaveText(string str);  // сохранение файла
        bool ExistsPath { get;  set; }
        public event EventHandler<string>? LoadTextEvent;
    }
}
