using DocManager.Core.Business.Users.AddUser;
using DocManager.Core.Domain.Repositories;
using DocManager.Core.Domain.ValueObjects;
using MediatR;

namespace DocManager.Core.Business.Users.DeleteUser;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserRequest, ApplicationResponse>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ApplicationResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id == Guid.Empty)
            throw new ArgumentNullException(nameof(request));

        await _userRepository.DeleteUserAsync(request.Id, cancellationToken);
        return ApplicationResponse.Succeed();
    }
    
}