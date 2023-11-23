namespace VerticalSliceArch.Infrastructure.Services.shared;

using Microsoft.AspNetCore.Http;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetTenantId()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext != null && httpContext.Items.TryGetValue("TenantId", out var tenantId))
        {
            return (int)tenantId;
        }

        throw new InvalidOperationException("TenantId no está disponible.");
    }
}

public interface ITenantService
{
    int GetTenantId();
}
