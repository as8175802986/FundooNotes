using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Collab
{
    public class CollabratorPostModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-z0-9]+(.[a-z0-9]+)?@[a-z]+[.][a-z]{3}$",
        ErrorMessage = "Please enter correct email address")]
        public string CollabEmail { get; set; }
    }
}
