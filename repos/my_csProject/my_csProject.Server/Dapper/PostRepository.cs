using System.Data; // 데이터베이스 연결을 위한 IDbConnection 인터페이스를 포함
using Dapper; // Dapper ORM 라이브러리를 포함
using MySql.Data.MySqlClient; // MySQL 데이터베이스 연결을 위한 MySqlConnection 클래스를 포함

// PostRepository 클래스는 게시물(Post) 데이터를 관리하는 리포지토리 클래스입니다.
public class PostRepository
{
    // 데이터베이스 연결 문자열을 저장할 private 필드
    private readonly string _connectionString;

    // 생성자(Constructor)는 클래스가 인스턴스화될 때 호출되며, 데이터베이스 연결 문자열을 초기화합니다.
    public PostRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Connection 프로퍼티는 MySqlConnection 인스턴스를 반환합니다.
    // 이 프로퍼티를 통해 데이터베이스에 연결할 수 있습니다.
    private MySqlConnection Connection => new MySqlConnection(_connectionString);

    // GetAllPosts 메서드는 데이터베이스에서 모든 게시물을 조회하여 반환합니다.
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        // using 문을 사용하여 dbConnection을 열고 사용 후 자동으로 닫습니다.
        using (var dbConnection = Connection)
        {
            await dbConnection.OpenAsync(); // 데이터베이스 연결을 엽니다.

            // Dapper의 QueryAsync 메서드를 사용하여 모든 게시물을 조회합니다.
            return await dbConnection.QueryAsync<Post>("SELECT * FROM Posts");
        }
    }

    // AddPost 메서드는 새로운 게시물을 데이터베이스에 추가합니다.
    public async Task AddPost(Post post)
    {
        // using 문을 사용하여 dbConnection을 열고 사용 후 자동으로 닫습니다.
        using (var dbConnection = Connection)
        {
            await dbConnection.OpenAsync(); // 데이터베이스 연결을 엽니다.

            // Dapper의 ExecuteAsync 메서드를 사용하여 게시물을 추가하는 SQL 쿼리를 실행합니다.
            await dbConnection.ExecuteAsync("INSERT INTO Posts (Title, Content) VALUES(@Title, @Content)", post);
        }
    }
}
