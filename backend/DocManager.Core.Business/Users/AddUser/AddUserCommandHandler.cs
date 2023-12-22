using DocManager.Core.Domain.Repositories;
using DocManager.Core.Domain.ValueObjects;
using MediatR;

namespace DocManager.Core.Business.Users.AddUser;

public class AddUserCommandHandler: IRequestHandler<AddUserRequest, ApplicationResponse<AddUserResponse>>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ApplicationResponse<AddUserResponse>> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                throw new ArgumentNullException(nameof(request), "Username and Password are mandatory");

            var user = await _userRepository.CreateUserAsync(request.Username, request.Password, request.IsAdmin,
                cancellationToken);
            return ApplicationResponse<AddUserResponse>.Succeed(new AddUserResponse(user.Username, user.CreatedAt));
        }
        catch (Exception e)
        {
            return ApplicationResponse<AddUserResponse>.Fail("UnknownError", e.Message);
        }
    }
    
}