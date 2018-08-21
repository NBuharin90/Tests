using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Interview_Maxima_Task6
{

public class Progarm
{
    SomeEventHandler someEvent;

    readonly object someEventLock = new object();

    public event SomeEventHandler SomeEvent
    {
        add
        {
            lock (someEventLock)
            {
                someEvent += value;
            }
        }
        remove
        {
            lock (someEventLock)
            {
                someEvent -= value;
            }
        }
    }

    protected virtual void OnSomeEvent(EventArgs e)
    {
        SomeEventHandler handler;
        lock (someEventLock)
        {
            handler = someEvent;
        }
        if (handler != null)
        {
            handler(this, e);
        }
    }
    }

    public delegate void SomeEventHandler(object sender, EventArgs args);
}
