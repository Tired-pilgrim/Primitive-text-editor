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
       
        public void LoadText() => _repository.LoadText();
        public void SaveText(string text) => _repository.SaveText(text);
    }
}
