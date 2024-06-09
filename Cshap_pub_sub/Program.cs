// See https://aka.ms/new-console-template for more information

using Cshap_pub_sub;

class Program
{
    // 실행
    static void Main(string[] args)
    {
        Event eventPublisher = new Event();
        Console.Write("person 이름 :");
        string personName = Console.ReadLine();
        Console.Write("person 나이 :");
        string personAge = Console.ReadLine();
        Console.Write("person 정보 :");
        string personType = Console.ReadLine();
        Person person = new Person(personName, int.Parse(personAge), personType);

        Console.Write("car 종류 :");
        string carModel = Console.ReadLine();
        Console.Write("car 번호 :");
        string carNumber = Console.ReadLine();
        Car car = new Car(carModel, carNumber);


        // 스위치 케이스로 이벤트 처리
        while (true)
        {
            Console.WriteLine("이벤트 선택: [1: 탑승, 2: 운행, 3: 새로운 정보, 4: 종료]");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // 구독
                    person.Subscribe(eventPublisher);
                    // 이벤트 실행
                    person.DoSomething(eventPublisher, "탑승");
                    // 해제
                    person.Unsubscribe(eventPublisher);
                    break;
                case "2":
                    // 구독
                    car.Subscribe(eventPublisher);
                    // 이벤트 실행
                    car.Drive(eventPublisher, "운행");
                    // 해제
                    car.Unsubscribe(eventPublisher);
                    break;
                case "3":
                    // 새로운 객체 생성
                    person = CreatePerson();
                    car = CreateCar();
                    break;
                case "4":
                    // break가 아니라 return?
                    return;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }

        // person 정보 입력
        // person 인스턴스(객체) 선언 없이 해당 메서드를 호출하기 위해 static 선언
        static Person CreatePerson()
        {
            Console.Write("person 이름 :");
            string personName = Console.ReadLine();
            Console.Write("person 나이 :");
            string personAge = Console.ReadLine();
            Console.Write("person 정보 :");
            string personType = Console.ReadLine();
            return new Person(personName, int.Parse(personAge), personType);
        }

        // car 등록 메서드
        // person 인스턴스(객체) 선언 없이 해당 메서드를 호출하기 위해 static 선언
        static Car CreateCar()
        {
            Console.Write("car 종류 :");
            string carModel = Console.ReadLine();
            Console.Write("car 번호 :");
            string carNumber = Console.ReadLine();
            return new Car(carModel, carNumber);
        }
    }
}
