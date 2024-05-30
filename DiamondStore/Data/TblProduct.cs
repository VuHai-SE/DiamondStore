﻿using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblProduct
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? ProductCode { get; set; }

    public string? Description { get; set; }

    public string? CategoryId { get; set; }

    public double? MaterialCost { get; set; }

    public double? GemCost { get; set; }

    public double? ProductionCost { get; set; }

    public double? PriceRate { get; set; }

    public int? ProductSize { get; set; }

    public string? Image { get; set; }

    public bool? Status { get; set; }

    public virtual TblProductCategory? Category { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblProductMaterial> TblProductMaterials { get; set; } = new List<TblProductMaterial>();

    public virtual ICollection<TblGem> Gems { get; set; } = new List<TblGem>();
}
