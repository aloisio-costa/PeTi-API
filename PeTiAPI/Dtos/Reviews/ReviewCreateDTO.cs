using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Dtos.Reviews
{
    public class ReviewCreateDTO
    {
        [Required]
        [JsonProperty("title")]
        [StringLength(20, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Title { get; set; }
        [Required]
        [JsonProperty("body")]
        [StringLength(300, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Body { get; set; }
        [Required]
        [JsonProperty("rating")]
        public int Rating { get; set; }
        public Guid PetSitterId { get; set; }
    }
}
