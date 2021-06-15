using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FilemanagerDemo.Archivos.Core
{
    /// <summary>
    /// Describe la interfaz para implementar los metodos de firma digital.
    /// - No contempla el manejo de pdf firmados.
    /// </summary>
    public interface IPdfSigner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="certificate">Certificate must containe Public Key, Cert file and Private Key</param>
        void Firmar(System.IO.Stream file, System.IO.Stream _out, Pkcs12Store certificate, PropertiesDocument? properties);
        void Firmar(System.IO.Stream file, System.IO.Stream _out, X509Certificate2 certificate, AsymmetricKeyParameter privateKey,PropertiesDocument? properties);
        int ContarFirmas(System.IO.Stream pdfFile);
    }
}
