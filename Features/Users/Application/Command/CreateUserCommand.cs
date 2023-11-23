using Dapper;
using MediatR;
using System.Data;
using VerticalSliceArch.Domain.DTOs;

namespace VerticalSliceArch.Application.Features.Users.Command
{
    public class CreateUserCommand : IRequest<int>
    {
       public UserDto UserDto { get; set; }
       public int TenantId { get; set; }
       
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IDbConnection _dbConnection;
            private readonly ITenantHelper _tenantHelper;

            public CreateUserCommandHandler(IDbConnection dbConnection, ITenantHelper tenantHelper)
            {
                _dbConnection = dbConnection;
                _tenantHelper = tenantHelper;
            }

            public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var connectionString = _tenantHelper.GetConnectionString(request.TenantId);
                _dbConnection.ConnectionString = connectionString;
                
                var query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";
                var userId = await _dbConnection.ExecuteScalarAsync<int>(query, new { request.UserDto.Name, request.UserDto.Email });

                return userId;
            }
        }
    }
}
