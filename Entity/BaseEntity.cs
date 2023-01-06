using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
