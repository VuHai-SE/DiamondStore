using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblProductMaterial
{
    public string ProductId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public double? Weight { get; set; }

    public virtual TblMaterialPriceList Material { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;
}
