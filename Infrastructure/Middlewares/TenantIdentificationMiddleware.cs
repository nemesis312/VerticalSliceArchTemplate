namespace VerticalSliceArch.Infrastructure.Middlewares;

public class TenantIdentificationMiddleware
{
    private readonly RequestDelegate _next;

    public TenantIdentificationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Aquí extraes el TenantId de la solicitud
        if (context.Request.Headers.TryGetValue("X-TenantId", out var tenantIdValue))
        {
            if (int.TryParse(tenantIdValue, out var tenantId))
            {
                // Almacena el TenantId en el contexto de la solicitud
                context.Items["TenantId"] = tenantId;
            }
            else
            {
                // Maneja casos donde el TenantId no es válido
                // Por ejemplo, puedes devolver un error o establecer un TenantId por defecto
            }
        }

        // Llama al siguiente middleware en la cadena
        await _next(context);
    }
}
