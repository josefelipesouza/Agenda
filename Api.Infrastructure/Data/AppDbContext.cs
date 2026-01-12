using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Api.Domain.Entities;

namespace Api.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<AgendaVisitaTecnica> Agendas { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
