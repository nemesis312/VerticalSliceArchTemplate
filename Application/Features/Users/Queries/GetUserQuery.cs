using System.Data;
using Dapper;
using MediatR;

namespace VerticalSliceArch.Application.Features.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
        {
            private readonly IDbConnection _dbConnection;

            public GetUserQueryHandler(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var query = "SELECT Id, Name, Email FROM Users WHERE Id = @UserId";
                var user = await _dbConnection.QueryFirstOrDefaultAsync<UserDto>(query, new { request.UserId });

                return user;
            }
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Otros campos
    }
}