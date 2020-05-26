using ChessGame.Application.Services;
using ChessGame.Domain.Interfaces;
using ChessGame.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddChessServices(this IServiceCollection services)
        {
            services.AddScoped<GameService>();
            services.AddSingleton<IGameRepository, GameRepository>();
        }
    }
}
