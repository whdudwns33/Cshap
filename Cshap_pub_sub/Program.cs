// See https://aka.ms/new-console-template for more information

using Cshap_pub_sub;

class Program
{
    // 이벤트 선언
    public event EventHandler<string> SomethingHappened;

    // 실행
    static void Main(string[] args)
    {
        // Person 객체 생성
        Console.Write("Person의 이름을 입력하세요 : ");
        string name = Console.ReadLine();
        Console.Write("Person의 나이를 입력하세요 : ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Person의 type을 입력하세요 : ");
        string type = Console.ReadLine();

        Person person = new Person(name, age, type);

        // Car 객체 생성
        Car car = new Car("MyCar");

        // 이벤트 핸들러 연결을 Person 클래스의 메서드를 통해 구독
        person.Subscribe(car.OnSomethingHappened);

        // Person이 어떤 행동을 할 때 Car가 반응함
        person.DoSomething("running");

        // 대기
        Console.ReadLine();
    }
}
