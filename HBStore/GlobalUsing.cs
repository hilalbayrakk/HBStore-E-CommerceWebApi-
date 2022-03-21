global using System;
global using System.Net;
global using System.Text;
global using System.Text.Json.Serialization;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations.Schema;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using FluentValidation;
global using FluentValidation.AspNetCore;

global using HBStore.Security;
global using HBStore.Helper;
global using HBStore.DTO;
global using HBStore.Model;
global using HBStore.Repository;
global using HBStore.Service;
global using HBStore.Context;
global using HBStore.Interface;
global using HBStore.DatabaseBuilder;
global using HBStore.ResponseObjectResults;
