using CoreBusiness;

namespace UseCases.ReactionTypeUseCases;

public interface IGetReactionTypeByActivityNameUseCase
{
    ReactionType? Execute(string name);
}