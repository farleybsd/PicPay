﻿global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using PicPay.Simplificado.Api.EndpointFilters;
global using PicPay.Simplificado.Api.EndpointHandlers;
global using PicPay.Simplificado.Api.Erros;
global using PicPay.Simplificado.Api.Extensions;
global using PicPay.Simplificado.Api.Validators;
global using PicPay.Simplificado.Application.Mapper.Interface;
global using PicPay.Simplificado.Application.Request.UsuarioComum.Create;
global using PicPay.Simplificado.Application.Response.Transacaoes;
global using PicPay.Simplificado.Application.Response.UsuarioComum.Create;
global using PicPay.Simplificado.Application.Response.UsuariosLojistas;
global using PicPay.Simplificado.Domain.Core.Interfaces.Commands;
global using PicPay.Simplificado.Domain.Core.Interfaces.Commands.Transferencias;
global using PicPay.Simplificado.Domain.Core.Interfaces.Commands.UsuarrioLojistas;
global using PicPay.Simplificado.Domain.Core.Interfaces.Queries.Interfaces;
global using PicPay.Simplificado.Infrastructure.Extensions.Ioc;
global using PicPay.Simplificado.Service.Ioc;
global using System.ComponentModel.DataAnnotations;
global using System.Text.RegularExpressions;