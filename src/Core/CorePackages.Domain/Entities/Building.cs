using CorePackages.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackages.Domain.Entities;

public class Building : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Room> Rooms { get; set; }
    public ICollection<Depot> Depots { get; set; }
}
