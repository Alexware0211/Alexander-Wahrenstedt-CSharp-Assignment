using Infrastructure.Interfaces;

namespace Infrastructure.Helpers;

public class UniqueIdGenerator : IUniqueIdGenerator
{
    public static string GenerateID()
    {
        return Guid.NewGuid().ToString();
    }
}
