using System.Data;
using MediatR;
using VerticalSliceArch.Features.TimeConvertion.Infrastructure.Services;
using VerticalSliceArch.Infrastructure.Services;

namespace VerticalSliceArch.Features.TimeConvertion.Application.Command;

public class SaveTimeConvertionCommand : IRequest<int>
{
    public int Seconds { get; set; }
    public int TenantId { get; set; }
    
    public class SaveTimeConvertionCommandHandler : IRequestHandler<SaveTimeConvertionCommand, int>
    {
        private readonly ITimeConversionService _timeConversionService;
        private readonly IDbConnection _dbConnection;
        
        public SaveTimeConvertionCommandHandler(ITimeConversionService timeConversionService, IDbConnection dbConnection)
        {
            _timeConversionService = timeConversionService;
            _dbConnection = dbConnection;
        }
        
        public async Task<int> Handle(SaveTimeConvertionCommand request, CancellationToken cancellationToken)
        {
            var result = _timeConversionService.ConvertSeconds(request.Seconds);

            // Código para guardar el resultado en la base de datos (comentado por ahora)
            /*
            var query = "INSERT INTO TimeConversions (Hours, Minutes, Seconds) VALUES (@Hours, @Minutes, @Seconds); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.ExecuteScalarAsync<int>(query, result);
            return id;
            */

            // Simulación del ID generado
            return 1; // Simular un ID generado por la base de datos
        }
    }
}