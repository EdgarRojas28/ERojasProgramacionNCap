using System;
using System.Collections.Generic;

namespace DL;

public partial class PlantelCarrera
{
    public int IdPlantelCarrera { get; set; }

    public int IdPlantel { get; set; }

    public int IdCarrera { get; set; }

    public virtual Carrera IdCarreraNavigation { get; set; } = null!;

    public virtual Plantel IdPlantelNavigation { get; set; } = null!;
}
