using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class ReactionTypeSqlRepository : IReactionTypeRepository
{
    private readonly BisleriumContext _db;

    public ReactionTypeSqlRepository(BisleriumContext db)
    {
        _db = db;
    }
    
    public ReactionType? GetReactionTypeByActivityName(string name)
    {
        return _db.ReactionTypes.FirstOrDefault(rt => rt.Activity == name);
    }
}