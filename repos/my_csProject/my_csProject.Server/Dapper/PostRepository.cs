using System.Data; // �����ͺ��̽� ������ ���� IDbConnection �������̽��� ����
using Dapper; // Dapper ORM ���̺귯���� ����
using MySql.Data.MySqlClient; // MySQL �����ͺ��̽� ������ ���� MySqlConnection Ŭ������ ����

// PostRepository Ŭ������ �Խù�(Post) �����͸� �����ϴ� �������丮 Ŭ�����Դϴ�.
public class PostRepository
{
    // �����ͺ��̽� ���� ���ڿ��� ������ private �ʵ�
    private readonly string _connectionString;

    // ������(Constructor)�� Ŭ������ �ν��Ͻ�ȭ�� �� ȣ��Ǹ�, �����ͺ��̽� ���� ���ڿ��� �ʱ�ȭ�մϴ�.
    public PostRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Connection ������Ƽ�� MySqlConnection �ν��Ͻ��� ��ȯ�մϴ�.
    // �� ������Ƽ�� ���� �����ͺ��̽��� ������ �� �ֽ��ϴ�.
    private MySqlConnection Connection => new MySqlConnection(_connectionString);

    // GetAllPosts �޼���� �����ͺ��̽����� ��� �Խù��� ��ȸ�Ͽ� ��ȯ�մϴ�.
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        // using ���� ����Ͽ� dbConnection�� ���� ��� �� �ڵ����� �ݽ��ϴ�.
        using (var dbConnection = Connection)
        {
            await dbConnection.OpenAsync(); // �����ͺ��̽� ������ ���ϴ�.

            // Dapper�� QueryAsync �޼��带 ����Ͽ� ��� �Խù��� ��ȸ�մϴ�.
            return await dbConnection.QueryAsync<Post>("SELECT * FROM Posts");
        }
    }

    // AddPost �޼���� ���ο� �Խù��� �����ͺ��̽��� �߰��մϴ�.
    public async Task AddPost(Post post)
    {
        // using ���� ����Ͽ� dbConnection�� ���� ��� �� �ڵ����� �ݽ��ϴ�.
        using (var dbConnection = Connection)
        {
            await dbConnection.OpenAsync(); // �����ͺ��̽� ������ ���ϴ�.

            // Dapper�� ExecuteAsync �޼��带 ����Ͽ� �Խù��� �߰��ϴ� SQL ������ �����մϴ�.
            await dbConnection.ExecuteAsync("INSERT INTO Posts (Title, Content) VALUES(@Title, @Content)", post);
        }
    }
}
