namespace EF2.Api.Data.Abstract
{
    public interface IEntityAuditable
    {
        System.DateTime ModifiedDate { get; set; }
    }
}