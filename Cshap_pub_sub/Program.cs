// See https://aka.ms/new-console-template for more information

class Program
{
    // 이벤트 선언
    public event EventHandler<string> SomethingHappened;

    // 실행
    static void Main(string[] args)
    {
        Console.Write("Person의 이름을 입력하세요 : ");
        string name = Console.ReadLine();
        Console.Write("Person의 나이를 입력하세요 : ");
        string age = Console.ReadLine();
        Console.Write("Person의 type을 입력하세요 : ");

    }


    // Publisher
    public void onSonmethingHappend(object sender, string something)
    {
        SomethingHappened?.Invoke(this, something);
    }


}
