namespace Task_20_03
{
    internal class Program { }
}
//   Создайте программу для управления статусом заказа в интернет-магазине.Используйте перечислениеOrderStatus со значениями:
//• New(новый)
//• Processing(в обработке)
//• Shipped(отправлен)
//• Delivered(доставлен)
//• Cancelled(отменён)
//Напишите метод, который меняет статус заказа.Если заказ уже доставлен или отменён, запретите изменение статуса.Выводите сообщение при каждом изменении статуса (например,
//"Заказ переведён в статус: Отправлен")


namespace OrderStatusManagement
{
    // Перечисление возможных статусов заказа
    public enum OrderStatus
    {
        New,            // Новый
        Processing,     // В обработке
        Shipped,        // Отправлен
        Delivered,      // Доставлен
        Cancelled       // Отменён
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаём заказ с начальным статусом "New"
            Order order = new Order();
            Console.WriteLine($"Текущий статус заказа: {order.Status}");

            // Пробуем менять статус заказа
            order.ChangeStatus(OrderStatus.Processing);
            order.ChangeStatus(OrderStatus.Shipped);
            order.ChangeStatus(OrderStatus.Delivered);

            // Пробуем изменить статус после доставки (должно появиться сообщение об ошибке)
            order.ChangeStatus(OrderStatus.Cancelled);

            // Создадим другой заказ и попробуем отменить его
            Order anotherOrder = new Order();
            anotherOrder.ChangeStatus(OrderStatus.Cancelled);

            // Пробуем изменить статус после отмены (должно появиться сообщение об ошибке)
            anotherOrder.ChangeStatus(OrderStatus.Processing);
        }
    }

    class Order
    {
        public OrderStatus Status { get; private set; }

        public Order()
        {
            Status = OrderStatus.New; // Устанавливаем начальный статус "Новый"
        }

        // Метод для изменения статуса заказа
        public void ChangeStatus(OrderStatus newStatus)
        {
            // Проверяем, можно ли изменить статус
            if (Status == OrderStatus.Delivered || Status == OrderStatus.Cancelled)
            {
                Console.WriteLine($"Ошибка: нельзя изменить статус заказа. Текущий статус: '{Status}' (заказ уже доставлен или отменён).");
                return;
            }

            // Меняем статус и выводим сообщение
            Console.WriteLine($"Заказ переведён в статус: {newStatus}");
            Status = newStatus;
        }
    }
}
