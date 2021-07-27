using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Models
{
    public class ServiceRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("petType")]
        [StringLength(20, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string PetType { get; set; }
        [Required]
        [JsonProperty("breed")]
        [StringLength(20, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Breed { get; set; }
        [Required]
        [JsonProperty("location")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Location { get; set; }
        [Required]
        public string Service { get; set; }
        [JsonProperty("note")]
        [StringLength(300, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Note { get; set; }
        public string PhotoFileName { get; set; }

    }
}
