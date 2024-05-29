using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblMaterialPriceList
{
    public string MaterialId { get; set; } = null!;

    public string? MaterialName { get; set; }

    public double? UnitPrice { get; set; }

    public DateTime? EffDate { get; set; }

    public virtual ICollection<TblProductMaterial> TblProductMaterials { get; set; } = new List<TblProductMaterial>();
}
