using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IReactionTypeRepository
{
    ReactionType? GetReactionTypeByActivityName(string name);
}