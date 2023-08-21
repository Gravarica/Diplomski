// See https://aka.ms/new-console-template for more information
using EntityFramework_Benchmark.Repository.IRepository;
using EntityFramework_Benchmark.Repository;
using EntityFramework_Benchmark.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using EntityFramework_Benchmark.Benchmark;

class Program
{
    public static IServiceProvider InitProgramState ()
    {
        var services = new ServiceCollection();

        services.AddDbContext<BenchmarkDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        services.AddScoped<Benchmark>();

        return services.BuildServiceProvider();
    }

    static void Main(string[] args)
    {

        using var scope = InitProgramState().CreateScope();

        var benchmark = scope.ServiceProvider.GetService<Benchmark>();

        benchmark.ExecuteSecondReadQuery();
    }
}
