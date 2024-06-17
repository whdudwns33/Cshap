using Cs_pr01.Model; // Post 모델 클래스를 사용하기 위한 네임스페이스
using MySql.Data.MySqlClient; // MySQL과 connect 위한 using
using System;
using System.Collections.Generic;
using System.Configuration; // ConfigurationManager를 사용하여 설정 파일에서 연결 문자열을 가져오기 위한 네임스페이스
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_pr01.Sql
{
    public class BoardContext
    {
        // JAVA JDBC 같은 느낌이 강함
        // 설정 파일에서 연결 문자열을 가져와 connectionString 변수에 저장
        private string connectionString = ConfigurationManager.ConnectionStrings["board"].ConnectionString;

        // 모든 게시물(Post)을 가져오는 메서드
        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>(); // 게시물을 저장할 리스트 초기화

            // MySQL 데이터베이스에 연결
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // 데이터베이스 연결 열기
                // 데이터베이스에서 모든 게시물을 선택하는 SQL 명령어
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Posts", connection);

                // SQL 명령어를 실행하고 결과를 읽음
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // 결과를 반복하여 각 행을 Post 객체로 변환하고 리스트에 추가
                    while (reader.Read())
                    {
                        Post post = new Post
                        {
                            PostID = reader.GetInt32("PostID"), // PostID 열의 값을 가져와서 설정
                            Title = reader.GetString("Title"), // Title 열의 값을 가져와서 설정
                            Content = reader.GetString("Content"), // Content 열의 값을 가져와서 설정
                            CreatedAt = reader.GetDateTime("CreatedAt") // CreatedAt 열의 값을 가져와서 설정
                        };
                        posts.Add(post); // 리스트에 Post 객체 추가
                    }
                }
            }

            return posts; // 게시물 리스트 반환
        }

        // 새로운 게시물을 추가하는 메서드
        public void AddPost(Post post)
        {
            // MySQL 데이터베이스에 연결
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // 데이터베이스 연결 열기
                // 새로운 게시물을 삽입하는 SQL 명령어
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Posts (Title, Content) VALUES (@Title, @Content)", connection);
                // SQL 명령어에 매개변수 추가 및 설정
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Content", post.Content);
                cmd.ExecuteNonQuery(); // SQL 명령어 실행
            }
        }
    }
}
