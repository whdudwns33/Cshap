using Microsoft.EntityFrameworkCore;

/// <summary>
/// MyDbContext Ŭ������ Entity Framework Core�� ����Ͽ� �����ͺ��̽��� ��ȣ�ۿ��ϴ� ���ؽ�Ʈ Ŭ�����Դϴ�.
/// </summary>
public class MyDbContext : DbContext
{
    /// <summary>
    /// Posts ���̺��� ��Ÿ���� DbSet�Դϴ�. Post ����Ƽ�� �÷����� �����մϴ�.
    /// </summary>
    public DbSet<Post> Posts { get; set; }

    /// <summary>
    /// MyDbContext �������Դϴ�. DbContextOptions<MyDbContext>�� �Ű������� �޾� ���̽� Ŭ������ �����ڿ� �����մϴ�.
    /// </summary>
    /// <param name="options">�����ͺ��̽� ���� �� ��Ÿ ������ �����ϴ� DbContextOptions�Դϴ�.</param>
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// ���� ������ �� �߰����� ������ �����մϴ�. �����ͺ��̽� ���̺�� ����Ƽ ���� ������ �����մϴ�.
    /// </summary>
    /// <param name="modelBuilder">���� �����ϴ� �� ���Ǵ� ModelBuilder ��ü�Դϴ�.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ���̽� Ŭ������ OnModelCreating �޼��带 ȣ���մϴ�.
        base.OnModelCreating(modelBuilder);

        // ���⿡�� �߰����� �� ������ �� �� �ֽ��ϴ�.
        // ���� ���, ����Ƽ ����, ���� ����, �õ� ������ �߰� ���� �� �� �ֽ��ϴ�.
        // ����: modelBuilder.Entity<Post>().Property(p => p.Title).IsRequired();
    }
}
