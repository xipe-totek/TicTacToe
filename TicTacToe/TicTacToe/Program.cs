﻿using Avalonia;
using System;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Services.Abstract;
using TicTacToe.Services.Implementations;

namespace TicTacToe;

sealed class Program
{
    /// <summary>
    /// Dependency injection service provider
    /// </summary>
    public static ServiceProvider Di { get; set; }
    
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        // Preparing DI
        Di = ConfigureServices()
            .BuildServiceProvider();
        
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    
    // Setting up DI
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IGameLogic, StupidGameLogic>();
        
        return services;
    }
}