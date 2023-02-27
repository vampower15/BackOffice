using Test_Office.ConnectionContext;
using WebApplication1.Interface;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqlConnectionContext>(); //New Add
builder.Services.AddScoped<IOffice, OfficeRepo>(); // New Add
builder.Services.AddControllers();


//Add Policy for CORS (Cross-Origin Resourse Sharing) for Add WebApp (FrontEnd)
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); // " " ไว้สำหรับใส่ url เข้ามา  
}));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Important ***
//ใส่ Policyแล้ว ต้อง Useing for Add WebApp (FrontEnd)
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
