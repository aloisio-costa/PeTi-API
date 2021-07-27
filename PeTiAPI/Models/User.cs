using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("name")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Name { get; set; }
        [Required]
        [JsonProperty("email")]
        [StringLength(100, ErrorMessage = "{0} Cannot be more than {1} characters long")]
        public string Email { get; set; }
        [Required]
        [JsonIgnore] public string Password { get; set; }
    }
}
