using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    // Person 클래스 정의
    class Person : ISubscriber
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }

        // 생성자
        public Person(string name, int age, string type)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
        }

        public void DoSomething(Event publisher, string action)
        {
            Console.WriteLine($"Person 이벤트");
            // 이벤트 트리거
            publisher.OnSomethingHappened(action);
        }

        // 구독 메서드
        public void Subscribe(Event eventPublisher)
        {
            eventPublisher.SomethingHappened += HandleSomethingHappened;
        }
        // 구독 해제 메서드
        public void Unsubscribe(Event eventPublisher)
        {
            eventPublisher.SomethingHappened += HandleSomethingHappened;
        }

        // 이벤트 핸들러 메서드
        // sender의 역할
        // 이벤트 핸들러 메서드
        public void HandleSomethingHappened(object sender, string action)
        {
            Console.WriteLine($"{Age}세 {Type}인 {Name}은 {action}을(를) 합니다.");
        }
    }
 }
