namespace Conversiecalculator
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ConversieHistory")]
    public partial class ConversieHistory
    {
        public int Id { get; set; }

        public double InputValues { get; set; }

        [StringLength(10)]
        public string FromValues { get; set; }

        [StringLength(10)]
        public string ToValues { get; set; }

        public double Results { get; set; }
    }
}
