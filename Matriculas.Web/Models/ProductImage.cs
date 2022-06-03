using System;
using System.ComponentModel.DataAnnotations;

namespace Matriculas.Web.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Display(Name = "Image")] 
        public Guid ImageId { get; set; }
        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
           
            ? "$https://matriculasweb20220520201641.azurewebsites.net/images/noimage.png"
                        : $"https://matriculasdemo1.blob.core.windows.net/products/{ImageId}";
    }
}
