using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Favohit.WebApi.Models
{
    public class Album : IValidatableObject
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Backdrop { get; set; }

        [Required]
        public string Band { get; set; }
        
        [Required]
        public IList<Music> Musics { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            if(this.Musics == null || this.Musics.Count == 0)
            {
                result.Add(new ValidationResult("Album must be contain at least one music"));
            }

            foreach (var item in this.Musics)
            {
                Validator.TryValidateObject(item, new ValidationContext(item), result);
            }
         
            return result;
        }
    }
}
