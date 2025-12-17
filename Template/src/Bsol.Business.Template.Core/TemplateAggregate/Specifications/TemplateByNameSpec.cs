using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Bsol.Business.Template.Core.TemplateAggregate.Specifications;

public class TemplateByNameSpec : Specification<Template>, ISingleResultSpecification<Template>
{
    public TemplateByNameSpec(string name)
    {
        Query.Where(Template => Template.Name.ToUpper().Equals(name.ToUpper()));
    }
}
