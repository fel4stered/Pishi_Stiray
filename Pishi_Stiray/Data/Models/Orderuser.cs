using System;
using System.Collections.Generic;

namespace Pishi_Stiray.Data.Models;

public partial class Orderuser
{
    public int OrderId { get; set; }

    public int OrderStatus { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public string OrderPickupPoint { get; set; } = null!;

    public int PointOfIssue { get; set; }

    public string? FullNameClient { get; set; }

    public string ReceiptCode { get; set; } = null!;

    public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;

    public virtual ICollection<Product> ProductArticleNumbers { get; } = new List<Product>();
}
