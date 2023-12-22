using DocManager.Core.Domain.ValueObjects;
using MediatR;

namespace DocManager.Core.Business.Users.AddUser;

public record AddUserRequest(string Username, string Password, bool IsAdmin = false): IRequest<ApplicationResponse<AddUserResponse>>;