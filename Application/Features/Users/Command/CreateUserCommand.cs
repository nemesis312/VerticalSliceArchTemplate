using Dapper;
using MediatR;
using System.Data;

namespace VerticalSliceArch.Application.Features.Users.Command
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        // Otros campos relevantes

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IDbConnection _dbConnection;

            public CreateUserCommandHandler(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";
                var userId = await _dbConnection.ExecuteScalarAsync<int>(query, new { request.Name, request.Email });

                return userId;
            }
        }
    }
}
