using System.Data;
using MediatR;
using VerticalSliceArch.Domain.DTOs;

namespace VerticalSliceArch.Features.TimeConvertion.Application.Queries;

public class GetTimeConversionQuery : IRequest<TimeDto>
{
    public int Id { get; set; }

    public class GetTimeConversionQueryHandler : IRequestHandler<GetTimeConversionQuery, TimeDto>
    {
        private readonly IDbConnection _dbConnection;

        public GetTimeConversionQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
 
        public async Task<TimeDto> Handle(GetTimeConversionQuery request, CancellationToken cancellationToken)
        {
            // Código para obtener el resultado de la base de datos (comentado por ahora)
            /*
            var query = "SELECT Hours, Minutes, Seconds FROM TimeConversions WHERE Id = @Id";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<TimeResult>(query, new { request.Id });
            return result;
            */

            // Simulación de datos de retorno
            return new TimeDto { Hours = 1, Minutes = 40, Seconds = 30 }; // Datos ficticios
        }
    }
}
