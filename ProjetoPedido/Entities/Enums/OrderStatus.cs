using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Course.Entities.Enums
{
    enum OrderStatus : int
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }
}