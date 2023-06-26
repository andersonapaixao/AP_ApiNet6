using AP_ApiNet6.Domain.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Infra.Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _filePath;

        public SavePersonImage()
        {
            _filePath = "/temp/testeImagem";
        }

        public string Save(string imageBase64)
        {
            var fileExt = imageBase64.Substring(imageBase64.IndexOf('/') + 1, 
                          imageBase64.IndexOf(";") - imageBase64.IndexOf("/") - 1); // png ou jpg

            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);
            var imgBytes = Convert.FromBase64String(base64Code);
            var fileName = Guid.NewGuid().ToString() + "." + fileExt;
            using (var imageFile = new FileStream(_filePath + "/" + fileName, FileMode.Create))
            {
                imageFile.Write(imgBytes,0,imgBytes.Length);
                imageFile.Flush();
            }
            return _filePath + "/" + fileName;
        }
    }
}
