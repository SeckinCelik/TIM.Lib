using TIM.Lib.Data;
using System.ComponentModel.DataAnnotations;
using System;

namespace TIM.Lib.Model
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        [Required]
        [StringLength(30)]
        public string Isbn { get; set; }
    }
}
