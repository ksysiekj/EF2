namespace EF2.Api.Data.Abstract
{
    public interface IEntityActiveable
    {
        bool IsActive { get; set; }
    }
}