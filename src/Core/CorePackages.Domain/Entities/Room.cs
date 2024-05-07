using CorePackages.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackages.Domain.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; }

    // Foreign key for Building
    public int BuildingId { get; set; }
    // Navigation property for building
    public Building Building { get; set; }
}
