using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_pr01.Model
{
    // poco class : 특별한 변수나 메서드 없이 테이블 등의 데이터 구조를 나타내는 클래스. 프레임워크나 라이브러리에 종속되지 않음

    // DataTable : ADO.NET에서 데이터 저장 및 조작을 위해 제공하는 클래스.
    // 주로 데이터베이스의 테이블을 메모리 내에서 표현하고 조작하는 데 사용.

    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
