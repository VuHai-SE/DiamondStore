﻿using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblMembership
{
    public double? MinSpend { get; set; }

    public double? MaxSpend { get; set; }

    public double? DiscountRate { get; set; }

    public string? Ranking { get; set; }
}
