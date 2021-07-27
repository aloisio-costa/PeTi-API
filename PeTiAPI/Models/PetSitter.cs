using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Models
{
    public class PetSitter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("title")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("User")]
        [StringLength(30, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string User { get; set; }
        [Required]
        [JsonProperty("description")]
        [StringLength(2000, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Description { get; set; }
        [Required]
        [JsonProperty("location")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Location { get; set; }
        [Required]
        [JsonProperty("price")]
        public double Price { get; set; }
        public string PhotoFileName { get; set; }

        //Navigation Properties
        public List<Review> Reviews { get; set; }

    }
}
