using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    class Car : ISubscriber
    {
        public string Model { get; set; }
        public string Type { get; set; }

        // 생성자
        public Car(string model, string type)
        {
            this.Model = model;
            this.Type = type;
        }

        public void Drive(Event publisher, string action)
        {
            Console.WriteLine($"Car 이벤트");
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
            eventPublisher.SomethingHappened -= HandleSomethingHappened;
        }

        // 이벤트 핸들러 메서드
        public void HandleSomethingHappened(object sender, string action)
        {
            Console.WriteLine($"{Type} {Model}은 {action}을(를) 합니다.");
        }


        
    }
}
