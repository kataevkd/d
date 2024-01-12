using Microsoft.EntityFrameworkCore;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Infrastructure.Repos;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<MvdInterface, MvdRepo>();
builder.Services.AddScoped<PfrInterface, PfrRepo>();
builder.Services.AddScoped<PersonInterface, PersonRepo>();
builder.Services.AddScoped<GibddInterface, GibddRepo>();
builder.Services.AddScoped<NalogovayaInterface, NalogovayaRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//�������� �� �������
builder.Services.AddDbContext<ManageInformation.Infrastructure.Data.Context>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin() // ��������� ������ �� ���� ���������� 
           .AllowAnyMethod() // ��������� ����� HTTP ������ 
           .AllowAnyHeader(); // ��������� ����� ��������� 
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//�����
app.UseDeveloperExceptionPage();
//
app.UseAuthorization();

app.MapControllers();

app.Run();
