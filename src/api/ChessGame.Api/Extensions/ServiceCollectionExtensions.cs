using ChessGame.Application.Dtos;
using ChessGame.Application.Services;
using ChessGame.Domain;
using ChessGame.Infrastructure.Repositories;
using ChessGame.Infrastructure.Session;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IPlayerSession, PlayerSession>();
        }
    }
}
