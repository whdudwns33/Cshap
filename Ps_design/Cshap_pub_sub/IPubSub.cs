using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshap_pub_sub
{
    public interface ISubscriber
    {
        void HandleSomethingHappened(object sender, string action);
        void Subscribe(Event eventPublisher);
        void Unsubscribe(Event eventPublisher);
    }
}
