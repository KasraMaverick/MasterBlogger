using System.Data;

namespace _0_Framework.Domain
{
    public class DomainBase<T>
    {
        public long Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DomainBase()
        {
            CreatedDate = DateTime.Now; 
        }
    }
}
