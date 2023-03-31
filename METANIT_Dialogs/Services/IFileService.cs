namespace METANIT_Dialogs.Services
{
    internal interface IFileService
    {
        string Open(string filename);
        void Save(string filename, string Text);
    }
}
