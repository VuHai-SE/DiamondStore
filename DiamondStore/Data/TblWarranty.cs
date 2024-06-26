﻿using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblWarranty
{
    public string WarrantyId { get; set; } = null!;

    public string? OrderDetailId { get; set; }

    public DateTime? WarrantyStartDate { get; set; }

    public DateTime? WarrantyEndDate { get; set; }

    public virtual TblOrderDetail? OrderDetail { get; set; }
}
