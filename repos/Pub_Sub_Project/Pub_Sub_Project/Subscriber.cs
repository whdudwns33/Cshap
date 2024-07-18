using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub_Sub_Project
{
    // Subscriber 클래스: 이벤트를 처리하는 클래스
    public class Subscriber
    {
        // Message를 담기 위함
        MessageData messageData = new MessageData();

        // 이벤트 처리 메서드
        public void OnSomethingHappened(object sender, string message)
        {
            Console.WriteLine(message);
            messageData.Message = message;
            Console.WriteLine($"messageData: {messageData.Message}");
        }
    }
}
