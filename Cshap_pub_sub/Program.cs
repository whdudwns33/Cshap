// See https://aka.ms/new-console-template for more information

using Cshap_pub_sub;

class Program
{
    // 실행
    static void Main(string[] args)
    {
        Event eventPublisher = new Event();
        Console.WriteLine("person 정보 입력 이름, 나이, 정보 [운전수 | 승객]");
        string personName = Console.ReadLine();
        string personAge = Console.ReadLine();
        string personType= Console.ReadLine();
        // 사람 정보 등록
        Person person = new Person(personName, int.Parse(personAge), personType);

        // 자동차 정보
        Console.WriteLine("car 정보 입력 [BUS | TAXI], ");
        string carModel = Console.ReadLine();
        string carName = Console.ReadLine();
        Car car = new Car(carModel, carName);

        // 구독
        person.Subscribe(eventPublisher);
        car.Subscribe(eventPublisher);

        // 이벤트 발생
        person.DoSomething(eventPublisher, "탑승");
        car.Drive(eventPublisher, "운행");

        // 구독 해제
        person.Unsubscribe(eventPublisher);
        car.Unsubscribe(eventPublisher);

        Console.ReadLine();

        // 코드 결과 예시
        /*
         *Person 이벤트
        33세 운전수인 aa은 탑승을(를) 합니다.
        Bus 현대은 탑승을(를) 합니다.
        
        Car 이벤트
        33세 운전수인 aa은 운행을(를) 합니다.
        Bus 현대은 운행을(를) 합니다. 
        
        1. 이벤트 구독-해제의 순서, 타이밍 문제 해결 필요 (switch case 등으로 해결 필요) 
        2. Event 자체 이해 필요 (문법 공부 필요)
         */
    }

}
