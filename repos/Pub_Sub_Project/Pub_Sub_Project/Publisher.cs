using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Pub_Sub_Project
{
    // Publisher 클래스: 이벤트를 정의하고 발생시키는 클래스
    public class Publisher
    {
        // 이벤트 정의
        public event EventHandler<string> SomethingHappened;

        // 이벤트를 발생시키는 메서드
        public void DoSomething()
        {
            Console.WriteLine("Publisher: Something is happening...");
            Console.Write("Enter a message: ");
            string message = Console.ReadLine();
            // 이벤트 발생
            SomethingHappened?.Invoke(this, message);
        }
    }
}

