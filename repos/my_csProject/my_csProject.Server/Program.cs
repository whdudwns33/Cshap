using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// �� ���ø����̼� ���� ����
var builder = WebApplication.CreateBuilder(args);

// ���� �����̳ʿ� ���� ���
builder.Services.AddControllers(); // ��Ʈ�ѷ� ���� ���
builder.Services.AddEndpointsApiExplorer(); // API Explorer ���� ���
builder.Services.AddSwaggerGen(); // Swagger ���� ���� ���� ���

// DbContext�� ���񽺿� ���
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 2, 0))));

// PostRepository�� ���� �����̳ʿ� �߰�
builder.Services.AddScoped<PostRepository>();

// ���ø����̼� ����
var app = builder.Build();

// ���� ���� �� �⺻ ���� ��� ����
app.UseDefaultFiles();
app.UseStaticFiles();

// HTTP ��û ���������� ����
if (app.Environment.IsDevelopment())
{
    // ���� ȯ�濡�� Swagger �� Swagger UI ��� ����
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS ���𷺼� ����
app.UseHttpsRedirection();

// ���� �ο� ��� ����
app.UseAuthorization();

// ��Ʈ�ѷ� ����
app.MapControllers();

// Fallback ������ ����
app.MapFallbackToFile("/index.html");

// ���ø����̼� ���� �� �����ͺ��̽� ���̱׷��̼� ����
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}

// ���ø����̼� ����
app.Run();
