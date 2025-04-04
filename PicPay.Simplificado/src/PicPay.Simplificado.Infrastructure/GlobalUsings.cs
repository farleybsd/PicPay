﻿global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using PicPay.Simplificado.Application.Handler;
global using PicPay.Simplificado.Application.Handler.Command.UsuarioLojistas;
global using PicPay.Simplificado.Application.Handler.Queries.UsuarioComum;
global using PicPay.Simplificado.Application.Mapper;
global using PicPay.Simplificado.Application.Mapper.Interface;
global using PicPay.Simplificado.Domain.Core.Interfaces.Base;
global using PicPay.Simplificado.Domain.Core.Interfaces.Commands;
global using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarrioLojistas;
global using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;
global using PicPay.Simplificado.Domain.Core.Interfaces.Repositories;
global using PicPay.Simplificado.Domain.Core.Interfaces.UnitOfWork;
global using PicPay.Simplificado.Domain.Entidades;
global using PicPay.Simplificado.Infrastructure.Data.Context;
global using PicPay.Simplificado.Infrastructure.Data.Repositories;
global using PicPay.Simplificado.Infrastructure.Data.Repositories.Base;
global using PicPay.Simplificado.Infrastructure.Data.UOfWork;
global using System.Linq.Expressions;
global using System.Reflection;