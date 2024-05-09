using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IViewSelectedBlogUseCase
{
    Blog? Execute(Guid blogId);
}