using TIM.Lib.Data;
using System.ComponentModel.DataAnnotations;
using System;

namespace TIM.Lib.Model
{
    public class Member : IEntity
    {
        public Guid Id { get ; set ; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
