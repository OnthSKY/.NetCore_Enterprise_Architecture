using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Personel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
