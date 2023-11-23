
public class TenantHelper : ITenantHelper
{
    private readonly IConfiguration _configuration;

    public TenantHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString(int tenantId)
    {
        //TODO: Implementar la lógica para obtener el connection string y deberia ser centralizado por ejemplo en la DB.
        string serverName, catalog;

        switch (tenantId)
        {
            case 1:
                serverName = "TestServer";
                catalog = "Tenant1Catalog";
                break;
            case 2:
                serverName = "DefaultServer";
                catalog = "DefaultCatalog";
                break;
            default:
                throw new ArgumentException("Invalid tenant ID");
        }

        // Construye la cadena de conexión. Asegúrate de almacenar y manejar
        // las credenciales y otros detalles de conexión de forma segura.
        return $"Server={serverName};Database={catalog};Integrated Security=SSPI;";
    }
}

public interface ITenantHelper
{
    string GetConnectionString(int tenantId);
}