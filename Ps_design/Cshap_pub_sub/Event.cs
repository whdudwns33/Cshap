using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    public class Event
    {
        public event Action<object, string> SomethingHappened;

        // 이벤트 트리거 메서드
        public void OnSomethingHappened(string action)
        {
            if (SomethingHappened != null)
            {
                SomethingHappened(this, action);
            }
        }
    }
}
