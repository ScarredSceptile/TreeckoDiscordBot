using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreeckoV2.Models
{
    public class PokemonAbilities
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        [Required]
        public string Description { get; set; }
        public string Effect { get; set; }
    }
}
