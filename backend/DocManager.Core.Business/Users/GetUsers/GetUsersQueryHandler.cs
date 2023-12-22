using DocManager.Core.Domain.Repositories;
using DocManager.Core.Domain.ValueObjects;
using MediatR;

namespace DocManager.Core.Business.Users.GetUsers;

public class GetUsersQueryHandler: IRequestHandler<GetUsersRequest, ApplicationResponse<IList<GetUsersResponseItem>>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ApplicationResponse<IList<GetUsersResponseItem>>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersAsync(cancellationToken);
        return ApplicationResponse.Succeed(user.Select(u => new GetUsersResponseItem(u)).ToList() as IList<GetUsersResponseItem>);
    }
    
}

public record GetUsersRequest(): IRequest<ApplicationResponse<IList<GetUsersResponseItem>>>;