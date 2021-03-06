using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Dtos
{
    public class PetSitterCreateDTO
    {
        [Required]
        [JsonProperty("title")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Title { get; set; }
        public string User { get; set; }
        [Required]
        [JsonProperty("description")]
        [StringLength(2000, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Description { get; set; }
        [Required]
        [JsonProperty("location")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Location { get; set; }
        public string PhotoFileName { get; set; }
        [Required]
        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
