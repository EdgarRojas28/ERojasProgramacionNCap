using System;
using System.Collections.Generic;

namespace DL;

public partial class Plantel
{
    public int IdPlantel { get; set; }

    public string NombreCorto { get; set; } = null!;

    public virtual ICollection<PlantelCarrera> PlantelCarreras { get; set; } = new List<PlantelCarrera>();
}
