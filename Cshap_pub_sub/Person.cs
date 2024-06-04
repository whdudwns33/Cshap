using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    // Person 클래스 정의
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }

        // 이벤트 선언
        public event EventHandler<string> SomethingHappened;

        // 생성자
        public Person(string name, int age, string type)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
        }

        // 메서드
        public void DoSomething(string action)
        {
            Console.WriteLine($"{Name} is doing something: {action}");
            // 이벤트 트리거
            SomethingHappened?.Invoke(this, action);
        }

        // 구독 메서드
        public void Subscribe(EventHandler<string> eventHandler)
        {
            SomethingHappened += eventHandler;
        }
    }
    }
