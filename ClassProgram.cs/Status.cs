    using System;

    namespace Pedido{

        enum OrderStatus : int{
        
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }
        class Order{
            public int Id {get; set;}
            public DateTime Moment{get; set;}
            public OrderStatus Status {get; set;}

            public override string ToString(){
                return Id + ", " + Moment + ", " + Status;
            }
        }
        class Program{
        static void Main(string[] args){

                Order order = new Order{
                    Id = 1080,
                    Moment = DateTime.Now,
                    Status = OrderStatus.Shipped
                };
                System.Console.WriteLine(order);

                string txt = OrderStatus.PendingPayment.ToString();

                OrderStatus os = Enum.Parse<OrderStatus>("Delivered");

                System.Console.WriteLine(txt);
                System.Console.WriteLine(os);
                System.Console.WriteLine(order.Status.ToString());
            }
        }
    }