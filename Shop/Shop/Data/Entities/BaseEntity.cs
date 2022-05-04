using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Entities
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
