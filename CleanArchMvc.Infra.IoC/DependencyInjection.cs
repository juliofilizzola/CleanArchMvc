using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration config) {
        service.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
        );

        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<ICategoryService, CategoryService>();
        service.AddAutoMapper(typeof(DomainToDtoMappingProfile));

        return service;
    }
}