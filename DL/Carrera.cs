using System;
using System.Collections.Generic;

namespace DL;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PlantelCarrera> PlantelCarreras { get; set; } = new List<PlantelCarrera>();
}
