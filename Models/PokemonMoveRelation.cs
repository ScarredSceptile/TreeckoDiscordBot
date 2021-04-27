using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeckoV2.Models
{
    [Keyless]
    class PokemonMoveRelation
    {
        [ForeignKey("Pokemon")]
        public int PokemonNr { get; set; }
        public Pokemon Pokemon { get; set; }
        [ForeignKey("Move")]
        public int MoveId { get; set; }
        public PokemonMoves Move { get; set; }

        public string Games { get; set; }
    }
}
