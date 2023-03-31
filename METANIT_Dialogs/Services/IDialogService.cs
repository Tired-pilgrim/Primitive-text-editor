namespace METANIT_Dialogs.Services
{
    internal interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; set; }   // путь к выбранному файлу
        string OpenFileDialog();  // открытие файла
        bool SaveFileDialog(string str);  // сохранение файла
    }
}
