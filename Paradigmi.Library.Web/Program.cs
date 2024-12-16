using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Application.Options;
using Paradigmi.Library.Application.Services;
using Paradigmi.Library.Models.Context;
using Paradigmi.Library.Models.Repositories;
using System.Text;
using FluentValidation.AspNetCore;
using Paradigmi.Library.Models.Repositories.Abstractions;
using Microsoft.OpenApi.Models;
using Paradigmi.Library.Web.Results;
using System.Text.Json.Serialization;
using Paradigmi.Library.Web.Extensions;
using Paradigmi.Library.Application.Token;
using Paradigmi.Library.Models.Extensions;
using Paradigmi.Library.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services
    .AddWebServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
