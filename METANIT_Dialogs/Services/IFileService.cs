using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METANIT_Dialogs.Services
{
    internal interface IFileService
    {
        string Open(string filename);
        void Save(string filename, string Text);
    }
}
