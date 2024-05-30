using System;
using System.Collections.Generic;

namespace DiamondStore.Data;

public partial class TblMaterialCategory
{
    public string MaterialId { get; set; } = null!;

    public string? MaterialName { get; set; }

    public virtual ICollection<TblProductMaterial> TblProductMaterials { get; set; } = new List<TblProductMaterial>();
}
