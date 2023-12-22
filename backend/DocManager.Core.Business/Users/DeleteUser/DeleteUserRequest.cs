using DocManager.Core.Domain.ValueObjects;
using MediatR;

namespace DocManager.Core.Business.Users.DeleteUser;

public record DeleteUserRequest(Guid Id): IRequest<ApplicationResponse>;