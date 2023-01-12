using System.ComponentModel.DataAnnotations.Schema;

namespace DroneApi.Entities
{
    public abstract class Entitity<TId>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TId Id
        {
            get;
            set;
        }
    }
}
