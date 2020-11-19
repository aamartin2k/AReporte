using AReport.Support.Entity;

namespace AReport.Support.Interface
{
    public interface IEntity
    {
        int Id { get; set; }

        EntityState State { get; set; }
    }
}
