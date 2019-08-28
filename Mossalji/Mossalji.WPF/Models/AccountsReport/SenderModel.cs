using Mossalji.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mossalji.WPF.Models
{
    public class SenderModel
    {
        public Sender Sender { get; set; }

        public double Paid { get => Sender.Orders.Where(o => o.FinancialStatus == Data.Enums.FinancialStatus.Paid).Sum(s=>s.Value); }

        public double PendingWithDriver { get => Sender.Orders.Where(o => o.FinancialStatus == Data.Enums.FinancialStatus.PendingDriver).Sum(s => s.Value); }

        public double PendingWithMossalji { get => Sender.Orders.Where(o => o.FinancialStatus == Data.Enums.FinancialStatus.PendingApp).Sum(s => s.Value); }

        public double Total { get => Paid + PendingWithDriver + PendingWithMossalji; }
    }
}
