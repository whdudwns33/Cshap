using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// 웹 애플리케이션 빌더 생성
var builder = WebApplication.CreateBuilder(args);

// 서비스 컨테이너에 서비스 등록
builder.Services.AddControllers(); // 컨트롤러 서비스 등록
builder.Services.AddEndpointsApiExplorer(); // API Explorer 서비스 등록
builder.Services.AddSwaggerGen(); // Swagger 문서 생성 서비스 등록

// DbContext를 서비스에 등록
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 2, 0))));

// PostRepository를 서비스 컨테이너에 추가
builder.Services.AddScoped<PostRepository>();

// 애플리케이션 빌드
var app = builder.Build();

// 정적 파일 및 기본 파일 사용 설정
app.UseDefaultFiles();
app.UseStaticFiles();

// HTTP 요청 파이프라인 구성
if (app.Environment.IsDevelopment())
{
    // 개발 환경에서 Swagger 및 Swagger UI 사용 설정
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS 리디렉션 설정
app.UseHttpsRedirection();

// 권한 부여 사용 설정
app.UseAuthorization();

// 컨트롤러 매핑
app.MapControllers();

// Fallback 페이지 설정
app.MapFallbackToFile("/index.html");

// 애플리케이션 시작 시 데이터베이스 마이그레이션 적용
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();
}

// 애플리케이션 실행
app.Run();
