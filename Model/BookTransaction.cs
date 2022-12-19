using TIM.Lib.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TIM.Lib.Model
{
    public class BookTransaction : IEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset BorrowDate { get; set; }
        public DateTimeOffset ExpectedReturnDate { get; set; }
        public DateTimeOffset? ActualReturnDate { get; set; }


        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
