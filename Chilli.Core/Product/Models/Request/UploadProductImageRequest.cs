using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class UploadProductImageRequest
    {
        public UploadProductImageRequest(int productId, string base64str)
        {
            ProductId = productId;
            Base64str = base64str;
        }
        public int ProductId { get; set; }
        public string Base64str { get; set; }
    }
}
