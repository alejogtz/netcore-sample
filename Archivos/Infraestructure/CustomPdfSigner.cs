using FilemanagerDemo.Archivos.Core;
using iText.Forms;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Signatures;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static iText.Signatures.PdfSigner;

namespace FilemanagerDemo.Archivos.Infraestructure
{
    public class CustomPdfSigner : IPdfSigner
    {


        private IList<string> GetSignatures(Stream pdfFile)
        {
            pdfFile.Position = 0;
            PdfReader reader = new PdfReader(pdfFile);
            PdfDocument pdfDoc = new PdfDocument(reader);
            SignatureUtil signatureUtil = new SignatureUtil(pdfDoc);

            IList<string> names = signatureUtil.GetSignatureNames();
            foreach (string name in names)
            {
                PdfPKCS7 pkcs7 = signatureUtil.ReadSignatureData(name);
                bool integrity = pkcs7.VerifySignatureIntegrityAndAuthenticity();
            }
            pdfDoc.Close();
            reader.Close();
            return names;
        }
        public int ContarFirmas(Stream pdfFile)
        {
            IList<string> names = GetSignatures(pdfFile);
            return names.Count;


        }
        public IList<string> GetFirmantes(Stream pdfFile)
        {
            return GetSignatures(pdfFile);
        }

        public void Firmar(Stream file, Stream _out, Pkcs12Store pk12, PropertiesDocument properties)
        {
            string alias = null;
            foreach (string Alias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(Alias))
                {
                    alias = Alias;
                    break;
                }
            }

            var pk = pk12.GetKey(alias).Key;
            PdfReader reader = new PdfReader(file);
            string digestAlgorithm = DigestAlgorithms.SHA256;

            Org.BouncyCastle.X509.X509Certificate[] bouncyCert = pk12.GetCertificateChain(alias).Select(o => o.Certificate).ToArray();

            StampingProperties stampProp = new StampingProperties();
            stampProp.PreserveEncryption();
            stampProp.UseAppendMode();

            IExternalSignature signature = new PrivateKeySignature(pk, digestAlgorithm);

            PdfSigner signer = new PdfSigner(reader, _out, stampProp);
            PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
            if (properties != null)
            {
                if (properties.Page > signer.GetDocument().GetNumberOfPages())
                    throw new Exception("¡Max number of pages exedeed!");

                appearance.SetLayer2Text("");
                appearance.SetReason(properties.Reason ?? "");
                appearance.SetLocation(properties.Location ?? "");
                appearance.SetContact(properties.Contact ?? "");
                appearance.SetPageNumber(properties.Page);
                appearance.SetPageRect(new iText.Kernel.Geom.Rectangle(properties.X ?? 10, properties.Y ?? 10, 50, 50));
                appearance.SetRenderingMode(PdfSignatureAppearance.RenderingMode.GRAPHIC);
                appearance.SetSignatureGraphic(ImageDataFactory.Create(Convert.FromBase64String(properties.image ?? "")));
            }

            signer.SignDetached(signature, bouncyCert, null, null, null, 0, CryptoStandard.CADES);
            signer.GetDocument().Close();
            reader.Close();
        }

        public void Firmar(Stream file, Stream _out, X509Certificate2 certificate, AsymmetricKeyParameter privateKey, PropertiesDocument? properties)
        {
            throw new System.NotImplementedException();
        }

    }
}
