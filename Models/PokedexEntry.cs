using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeckoV2.Models
{
    class PokedexEntry
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Pokemon")]
        public int PokemonNr { get; set; }
        public Pokemon Pokemon { get; set; }
        [Required]
        public string Description { get; set; }
        public string Game { get; set; }
    }
}
