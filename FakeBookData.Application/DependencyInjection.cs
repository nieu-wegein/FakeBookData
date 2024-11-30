using FakeBookData.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            return services.AddScoped<IBookService, BookService>();
        }
    }
}
