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
        else
        {
            //return default tenant 1, this is for testing purposes
            return 1;
        }

        // throw new InvalidOperationException("TenantId no está disponible.");
    }
}

public interface ITenantService
{
    int GetTenantId();
}
