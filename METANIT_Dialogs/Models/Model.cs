using System;

namespace METANIT_Dialogs.Models
{
    public class Model
    {
        
        Repository _repository;
        internal Model(Repository repository)
        {
            _repository = repository;
            repository.LoadTextEvent += (s,e) => LoadTextEvent?.Invoke(this, e); 
        }
        public event EventHandler<string>? LoadTextEvent;
        public bool ExistsPath => _repository.ExistsPath;
        public void LoadText() => _repository.LoadText();
        public void SaveText(string text) => _repository.SaveText(text);
        public void SaveAsText(string text) => _repository.SaveAsText(text);
    }
}
