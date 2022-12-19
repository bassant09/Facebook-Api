using Facebook_Api.Data;
using Facebook_Api.Models;
using Facebook_Api.Services.Authantication_Folder;
using Facebook_Api.Services.Comment_Folder;
using Facebook_Api.Services.Friends_Controller;
using Facebook_Api.Services.Post_Folder;
using Facebook_Api.Services.Repository_Pattern;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer Scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization", 
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthanticationRepository, AuthanticationRepository>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<ICommentServices, CommentService>();
builder.Services.AddScoped<IFriendServices, FriendServices>();
builder.Services.AddScoped<IRepositoryPattern<User>, RepositoryPattern<User>>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
     AddJwtBearer(option =>
     {
         option.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
             GetBytes(builder.Configuration.GetSection("AppSetting:Token").Value)),
             ValidateIssuer = false,
             ValidateAudience = false,

         };
     });
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
