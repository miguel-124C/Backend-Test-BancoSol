using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Bsol.Business.Template.SharedKernel.Audit;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Core.TemplateAggregate;

public class Template(string name) : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = Guard.Against.NullOrEmpty(name);

    public Template(Guid id, string name) : this(name)
    {
        Name = name;
        Id = id;
    }
}
