﻿using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblGemPriceList
{
    public int Id { get; set; }

    public string? Origin { get; set; }

    public double? CaratWeight { get; set; }

    public string? Color { get; set; }

    public string? Cut { get; set; }

    public string? Clarity { get; set; }

    public double? Price { get; set; }

    public DateTime? EffDate { get; set; }

    public double? Size { get; set; }
}
