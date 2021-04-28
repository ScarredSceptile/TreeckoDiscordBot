using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeckoV2.Models
{
    public class PokemonStats
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Pokemon")]
        public int PokemonNr { get; set; }
        public Pokemon Pokemon { get; set; }
        // Notated with each generation this is in, like: Gen 1,Gen2, Gen3, Gen4
        public string Generation { get; set; }

        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special_Attack { get; set; }
        public int Special_Defense { get; set; }
        public int Speed { get; set; }
    }
}
