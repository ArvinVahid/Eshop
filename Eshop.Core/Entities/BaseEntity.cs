namespace Eshop.Core.Entities
{
    public interface IEntity
    {
        
    }
    
    public class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<int>
    {
        
    }
}