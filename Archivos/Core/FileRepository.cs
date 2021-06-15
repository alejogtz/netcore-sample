using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Archivos.Core
{
    public interface FileRepository
    {
        void Create(FileInfo file);
        void Delete(string name);
        void Delete(DeleteEspecification delete);
        FileInfo Read(string name);
        FileInfo Read();
    }
}
