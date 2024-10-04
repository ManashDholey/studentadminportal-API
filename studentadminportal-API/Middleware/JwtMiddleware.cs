using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace studentadminportal_API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly ITokenService _tokenService;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, ITokenService tokenService)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _tokenService = tokenService;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
      {
            var path = context.Request.Path;
            if (path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }
            var endpoint = context.GetEndpoint();
            var isAllowAnonymous = endpoint?.Metadata.Any(x => x.GetType() == typeof(AllowAnonymousAttribute));
            if ((bool)isAllowAnonymous!)
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if (token != null)
                await attachUserToContext(context, userService, token);
            //else
            //{

            //    await ReturnUnauthorizedResponse(context, "Unauthorized: Token is missing");

            //}
            await _next(context);
        }
        private async Task ReturnUnauthorizedResponse(HttpContext context, string message)
        {
            // Set the status code to 401 Unauthorized
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            // Define the response object
            var response = new
            {
                status = StatusCodes.Status401Unauthorized,
                message = message,
                error = "Unauthorized"
            };

            // Set the response content type to JSON
            context.Response.ContentType = "application/json";

            // Write the JSON response
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
        //private void AttachUserToContext(HttpContext context, string token)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.ASCII.GetBytes(_appSettings.Secret ?? "");
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //            ClockSkew = TimeSpan.Zero
        //        }, out SecurityToken validatedToken);
        //        var jwtToken = (JwtSecurityToken)validatedToken;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}
        
        private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                //tokenHandler.ValidateToken(token, new TokenValidationParameters
                //{
                //    ValidateIssuerSigningKey = true,
                //    IssuerSigningKey = new SymmetricSecurityKey(key),
                //    ValidateIssuer = false,
                //    ValidateAudience = false,
                //    // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                //    ClockSkew = TimeSpan.Zero
                //}, out SecurityToken validatedToken);

                //var jwtToken = (JwtSecurityToken)validatedToken;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_appSettings.Secret ?? "");
                var Principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                context.User = Principal;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

                //Attach user to context on successful JWT validation
                context.Items["User"] = await userService.GetById(userId);
            }
            catch (SecurityTokenExpiredException)
            {
                await ReturnUnauthorizedResponse(context, "Unauthorized: Invalid token");
                //Do nothing if JWT validation fails
                // user is not attached to context so the request won't have access to secure routes
            }
            catch (SecurityTokenValidationException)
            {
                await ReturnUnauthorizedResponse(context, "Unauthorized: Invalid token");
            }
            catch (Exception)
            {
                await ReturnUnauthorizedResponse(context, "Unauthorized: Invalid token");
            }
        }
    }
}
