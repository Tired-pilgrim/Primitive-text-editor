using METANIT_Dialogs.Commands;
using METANIT_Dialogs.Models;
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
                //_model.MText = Text;
            }
        }
        Model _model;
        
        public RelayCommand OpenTextCommand { get; }
        public RelayCommand SaveTextCommand { get; }
        public ViewModel(Model model )
        {
            model.LoadTextEvent += (s, e) => Text = e;
            SaveTextCommand = new RelayCommand(() =>model.SaveText(Text));
            OpenTextCommand = new RelayCommand(() =>model.LoadText());
        }
        private string _text;
        public string Text
        {
            get => _text;
            set => Set(ref _text, ref value);
        }
    }
}
