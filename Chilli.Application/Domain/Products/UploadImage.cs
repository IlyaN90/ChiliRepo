using Chilli.Application.ImageHelper;
using Chilli.Application.Validaiton;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.Domain.Products
{
    public class UploadImage : IUploadImage
    {
        private readonly IProductRepository _repository;
        private readonly IImageValidator _validator;
        public UploadImage(IProductRepository repository, IImageValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<UploadProductImageResponse> UploadImageDb(UploadProductImageRequest request)
        {
            bool probablyBase64String = _validator.IsBase64String(request.Base64str);
            if (probablyBase64String)
            {
                string path = ImageHelperService.SaveImage(request);
                if (path.Length > 5) 
                {
                    var media = await _repository.UploadProductImageAsync(request, path);
                    if (media != null)
                    {
                        return new UploadProductImageResponse(true, media.Path);
                    }
                    return new UploadProductImageResponse(false, "något gått fel med att spara imagePath till databasen");
                }
                return new UploadProductImageResponse(false, "något gått fel med att spara bilden");
            }
            return new UploadProductImageResponse(false, "skicka in en valid base64sträng");
        }
    }
}
