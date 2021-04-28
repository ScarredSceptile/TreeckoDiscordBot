using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreeckoV2.Models
{
    public class DiscordGuild
    {
        [Key]
        public ulong ID { get; set; }
        [MaxLength(3)]
        public string Prefix { get; set; }
    }
}
