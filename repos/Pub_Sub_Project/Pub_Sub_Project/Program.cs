using Pub_Sub_Project;
using System;

namespace EventHandlingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Publisher와 Subscriber 인스턴스 생성
            var publisher = new Publisher();
            var subscriber = new Subscriber();

            // 이벤트 구독: Subscriber의 메서드를 이벤트 핸들러로 추가
            publisher.SomethingHappened += subscriber.OnSomethingHappened;

            // 이벤트 발생
            publisher.DoSomething();
        }
    }
}
