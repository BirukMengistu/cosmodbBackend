using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BackendProductStore.Model
{
    public class Product
    {

       
  
        public string? ArticleNumber { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }
  

    }
}
