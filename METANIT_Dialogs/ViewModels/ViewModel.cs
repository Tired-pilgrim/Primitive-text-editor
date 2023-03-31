using METANIT_Dialogs.Commands;
using METANIT_Dialogs.Models;

namespace METANIT_Dialogs.ViewModels
{
    internal class ViewModel: ViewModelBase
    {
        protected override void OnPropertyChanged(string? PropertyName)
        {
            base.OnPropertyChanged(PropertyName);
            if (PropertyName == nameof(Text) )
            {
                ChangedText = true;
                SaveTextCommand.RaiseCanExecuteChanged();
                SaveAsTextCommand.RaiseCanExecuteChanged();
            }
        }
        Model _model;
        private bool ChangedText;
        public RelayCommand OpenTextCommand { get; }

        //Проверяем наличие текста, изменился ли он с момента последнего сохранения,
        //а также существование пути для сохранения в файл
        private bool CanSaveTextCommandEcxecute() =>
            !string.IsNullOrWhiteSpace(Text)&& ChangedText && _model.ExistsPath;
        private bool CanSaveAsTextCommandEcxecute() => !string.IsNullOrWhiteSpace(Text);
        public RelayCommand SaveTextCommand { get; }
        public RelayCommand SaveAsTextCommand { get; }
        public RelayCommand ClearTextCommand { get; }
        public ViewModel(Model model )
        {
            _model = model;
            model.LoadTextEvent += (s, e) => Text = e;
            SaveTextCommand = new RelayCommand(() => 
                { model.SaveText(Text); ChangedText = false; }, CanSaveTextCommandEcxecute);
            SaveAsTextCommand = new RelayCommand(() =>
                { model.SaveAsText(Text); ChangedText = false; }, CanSaveAsTextCommandEcxecute);
            OpenTextCommand = new RelayCommand(() =>
                { model.LoadText(); ChangedText = false; });
            ClearTextCommand = new RelayCommand(() => Text = string.Empty, CanSaveAsTextCommandEcxecute);
        }
        private string _text =  string.Empty;
        public string Text
        {
            get => _text;
            set => Set(ref _text, ref value);
        }
    }
}
