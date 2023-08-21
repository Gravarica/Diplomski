using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Native.Repository.Interface;
using Native.Repository;
using System;
using System.Data;
using System.Diagnostics;
using Native.Settings;
using Native.Benchmark;

class Program
{
    static ServiceProvider InitProgramState()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IDatabaseConnection>(new DatabaseConnection(GlobalVariables.connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        services.AddScoped<Benchmark>();

        return services.BuildServiceProvider();
    }

    static void Main()
    {
        using var scope = InitProgramState().CreateScope();

        var benchmark = scope.ServiceProvider.GetService<Benchmark>();

        benchmark?.RunAll();
;    }
}

