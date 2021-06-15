using FilemanagerDemo.Archivos.Core;
using System;
using System.IO;

namespace FilemanagerDemo.Archivos.Infraestructure
{
    public class LocalFileRepository : FileRepository
    {
        public void Create(FileInfo file)
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

        public FileInfo Read(string name)
        {
            throw new NotImplementedException();
        }

        public FileInfo Read()
        {
            throw new NotImplementedException();
        }
    }
}
