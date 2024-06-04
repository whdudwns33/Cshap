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
        public string DoSomething { get; set; }

        // 생성자 사용
        public Car(string carName, string doSomething)
        {
            this.CarName = carName;
            this.DoSomething = doSomething;
        }
    }
}
