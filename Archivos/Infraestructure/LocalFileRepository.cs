using FilemanagerDemo.Archivos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Archivos.Infraestructure
{
    public class LocalFileRepository : FileRepository
    {
        public void Create(File file)
        {
            System.IO.File.WriteAllBytes("../../emptyFile.txt", new byte[] { });
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteEspecification delete)
        {
            throw new NotImplementedException();
        }

        public File Read(string name)
        {
            throw new NotImplementedException();
        }

        public File Read()
        {
            throw new NotImplementedException();
        }
    }
}
