using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    class Person
    {
        // 속성 정의
        public string Name { get; set; }
        public int Age { get; set; }
        public string type { get; set; }
        
        // 생성자
        public Person(string name, int age, string type) 
        { 
            this.Name = name;
            this.Age = age;
            this.type = type;
        }


    }
}
