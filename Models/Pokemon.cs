using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeckoV2.Models
{
    public class Pokemon
    {
        [Key]
        public int DexNr { get; set; }
        [Required]
        public string Name { get; set; }
        public string japName { get; set; }
        public string Type { get; set; }
        public string Classification { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Pic { get; set; }
        public string PicShiny { get; set; }
    }
}
