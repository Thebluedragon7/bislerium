using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ReactionTypeUseCases;

public class GetReactionTypeByActivityNameUseCase : IGetReactionTypeByActivityNameUseCase
{
    private readonly IReactionTypeRepository _reactionTypeRepository;

    public GetReactionTypeByActivityNameUseCase(IReactionTypeRepository reactionTypeRepository)
    {
        this._reactionTypeRepository = reactionTypeRepository;
    }
    
    public ReactionType? Execute(string name)
    {
        return _reactionTypeRepository.GetReactionTypeByActivityName(name);
    }
}