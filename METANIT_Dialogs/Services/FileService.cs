using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METANIT_Dialogs.Services
{
    internal class FileService : IFileService
    {
        public string Open(string filename)
        {
           return File.ReadAllText(filename, Encoding.UTF8);  
        }

        public void Save(string filename, string Text)
        {
           File.WriteAllText(filename, Text, Encoding.UTF8);    
        }
    }
}
