using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetTestAppMVC.Features.Auth.Infrastructure.Database.Models;

namespace AspNetTestAppMVC.Data;

class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AuthUser>(options) {

}
