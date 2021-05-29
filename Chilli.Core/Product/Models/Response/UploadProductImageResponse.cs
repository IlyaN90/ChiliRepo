using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class UploadProductImageResponse
    {
        public UploadProductImageResponse(bool success, string path)
        {
            Success = success;
            Path = path;
        }

        public bool Success { get; set; }
        public string Path { get; set; }
    }
}
