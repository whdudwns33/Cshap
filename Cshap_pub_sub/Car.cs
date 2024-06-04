using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    class Car
    {
        public string CarName { get; set; }

        // 생성자 사용
        public Car(string carName)
        {
            this.CarName = carName;
        }

        // 이벤트 핸들러
        public void OnSomethingHappened(object sender, string action)
        {
            Person person = sender as Person;
            Console.WriteLine($"{CarName} received a notification: {person.Name} is {action}");
        }
    }
}
