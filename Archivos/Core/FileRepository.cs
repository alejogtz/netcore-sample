using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Archivos.Core
{
    public interface FileRepository
    {
        void Create(File file);
        void Delete(string name);
        void Delete(DeleteEspecification delete);
        File Read(string name);
        File Read();
    }
}
