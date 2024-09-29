using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Types;

public interface IBaseType
{
    string Id { get; set; }
}

public abstract record BaseType : IBaseType
{
    public string Id { get; set; } = null!;
}
