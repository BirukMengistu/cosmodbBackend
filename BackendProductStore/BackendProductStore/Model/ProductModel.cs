using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BackendProductStore.Model
{
    public class ProductModel
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string PartitionKey { get; set; } = null!;
        public string? ArticleNumber { get; set; }

     
        public string? Name { get; set; }

        public decimal Price { get; set; }

    
        public string? Description { get; set; }
       



        /* The product must have an ID,
         * article number, name, price and description.*/
    }

   
}
