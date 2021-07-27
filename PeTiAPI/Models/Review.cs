using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
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

        //Navigation properties 
        public Guid PetSitterId { get; set; }
        public PetSitter PetSitter { get; set; }}
}
