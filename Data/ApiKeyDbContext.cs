using Microsoft.EntityFrameworkCore;
using ApiKey.Models;
namespace ApiKey.Data;

public class ApiKeyDbContext: DbContext
{
    public ApiKeyDbContext(DbContextOptions<ApiKeyDbContext> options): base(options)
    {

    }

    public DbSet<ApiKeyModel> ApiKeys { get; set;}
}