using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static TreeckoV2.Data.Enums;

namespace TreeckoV2.Models
{
    class PokemonMoves
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public MoveCategory Category { get; set; }
        public int PowerPoints { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public string Description { get; set; }
        public string PrimaryEffect { get; set; }
        public string SecondaryEffect { get; set; }
        //Is in percent
        public int SecondaryEffectRate { get; set; }
    }
}
