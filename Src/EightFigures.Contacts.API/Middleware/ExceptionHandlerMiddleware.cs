using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Authentication;
using System.IdentityModel.Tokens.Jwt;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Service.Enum;
using Microsoft.AspNetCore.Http.Extensions;
using System.ComponentModel.DataAnnotations;
using EightFigures.Contacts.Domain.CustomException;

namespace EightFigures.Contacts.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if(!string.IsNullOrEmpty(authHeader))
                {
                    var token = authHeader.Split(' ')[1];
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token);
                    var tokenS = jsonToken as JwtSecurityToken;
                    var logIn = tokenS.Claims.Where(x => x.Type == PayloadProperty.UserRequest.ToString()).Select(x => x.Value).First();
                    var userId = tokenS.Claims.Where(x => x.Type == PayloadProperty.UserId.ToString()).Select(x => x.Value).First();

                    if (context.Request.Method == "POST")
                    {
                        var bodyAsText = await new StreamReader(context.Request.Body).ReadToEndAsync();
                        var param = JObject.Parse(bodyAsText);
                        param.Add(nameof(BaseDto.UserRequest), logIn);
                        param.Add(nameof(BaseDto.UserId), int.Parse(userId));

                        var result = JsonConvert.SerializeObject(param);

                        context.Request.Body = GenerateStreamFromString(result);
                    }
                    else
                    {
                        if (context.Request.Method == "GET")
                        {
                            QueryBuilder queryBuilder = new QueryBuilder();
                            foreach (var key in context.Request.Query.Keys)
                            {
                                var realValue = context.Request.Query[key];
                                var modifiedValue = HttpUtility.UrlDecode(realValue);
                                queryBuilder.Add(key, modifiedValue);
                            }
                            queryBuilder.Add(PayloadProperty.UserRequest.ToString(), logIn);
                            queryBuilder.Add(PayloadProperty.UserId.ToString(), userId);
                            context.Request.QueryString = queryBuilder.ToQueryString();
                        }
                    }
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)GetErrorCode(ex);

                if(!string.IsNullOrEmpty(ex.Message))
                {
                    var result = JsonConvert.SerializeObject(new
                    {
                        Errors = ex.Message
                    });
                    await response.WriteAsync(result);
                }
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case BaseException _:
                    return ((BaseException)e).StatusCode;
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
