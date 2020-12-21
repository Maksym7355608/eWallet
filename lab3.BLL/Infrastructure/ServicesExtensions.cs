using lab3.DAL.EF;
using lab3.DAL.Interfaces;
using lab3.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab3.BLL.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
