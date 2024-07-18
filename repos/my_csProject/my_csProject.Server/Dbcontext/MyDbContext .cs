using Microsoft.EntityFrameworkCore;

/// <summary>
/// MyDbContext 클래스는 Entity Framework Core를 사용하여 데이터베이스와 상호작용하는 컨텍스트 클래스입니다.
/// </summary>
public class MyDbContext : DbContext
{
    /// <summary>
    /// Posts 테이블을 나타내는 DbSet입니다. Post 엔터티의 컬렉션을 관리합니다.
    /// </summary>
    public DbSet<Post> Posts { get; set; }

    /// <summary>
    /// MyDbContext 생성자입니다. DbContextOptions<MyDbContext>를 매개변수로 받아 베이스 클래스의 생성자에 전달합니다.
    /// </summary>
    /// <param name="options">데이터베이스 연결 및 기타 설정을 포함하는 DbContextOptions입니다.</param>
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// 모델을 생성할 때 추가적인 설정을 수행합니다. 데이터베이스 테이블과 엔터티 간의 매핑을 정의합니다.
    /// </summary>
    /// <param name="modelBuilder">모델을 구성하는 데 사용되는 ModelBuilder 객체입니다.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 베이스 클래스의 OnModelCreating 메서드를 호출합니다.
        base.OnModelCreating(modelBuilder);

        // 여기에서 추가적인 모델 설정을 할 수 있습니다.
        // 예를 들어, 엔터티 구성, 관계 설정, 시드 데이터 추가 등을 할 수 있습니다.
        // 예시: modelBuilder.Entity<Post>().Property(p => p.Title).IsRequired();
    }
}
