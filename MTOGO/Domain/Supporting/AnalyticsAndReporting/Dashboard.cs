using Domain.Shared.ValueObjects;


namespace Domain.Supporting.AnalyticsAndReporting
{
    public class Dashboard
    {
        public Guid DashboardId { get; private set; }
        public int TotalOrders { get; private set; }
        public decimal AverageOrderValue { get; private set; }
        public double AverageDeliveryTime { get; private set; }
        public int OpenOrders { get; private set; }
        public int ClosedOrders { get; private set; }
        private List<OrderMetrics> _orderMetrics = new List<OrderMetrics>();

        public Dashboard()
        {
            DashboardId = Guid.NewGuid();
            OpenOrders = 0;
            ClosedOrders = 0;
        }

        public void UpdateOrderMetrics(OrderMetrics metrics)
        {
            _orderMetrics.Add(metrics);
            TotalOrders++;
            AverageOrderValue = CalculateAverageOrderValue();
            AverageDeliveryTime = CalculateAverageDeliveryTime();

            // Update open and closed orders
            if (metrics.IsOrderOpen)
                OpenOrders++;
            else
                ClosedOrders++;
        }

        private decimal CalculateAverageOrderValue()
        {
            if (TotalOrders == 0) return 0;
            decimal totalValue = 0;
            foreach (var metric in _orderMetrics)
            {
                totalValue += metric.OrderValue.Amount;
            }
            return totalValue / TotalOrders;
        }

        private double CalculateAverageDeliveryTime()
        {
            if (TotalOrders == 0) return 0;
            double totalTime = 0;
            foreach (var metric in _orderMetrics)
            {
                totalTime += metric.DeliveryTime.TotalMinutes;
            }
            return totalTime / TotalOrders;
        }
    }
}
