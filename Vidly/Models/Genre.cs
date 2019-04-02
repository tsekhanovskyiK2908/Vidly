using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public static readonly byte Action = 1;
        public static readonly byte Comedy = 2;
        public static readonly byte Family = 3;
        public static readonly byte Romance = 4;

    }
}