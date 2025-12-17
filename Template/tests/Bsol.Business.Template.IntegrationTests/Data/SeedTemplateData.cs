using HandlebarsDotNet.Helpers.Enums;

namespace Bsol.Business.Template.IntegrationTests.Data;

public class SeedTemplateData
{
    public static List<Core.TemplateAggregate.Template> SeedTemplate()
    {
        return [
            new Core.TemplateAggregate.Template(Guid.NewGuid(), "Template 1"),
            new Core.TemplateAggregate.Template(Guid.NewGuid(), "Template 2") ,
            new Core.TemplateAggregate.Template(Guid.NewGuid(), "Template 3")
        ];

    }
}
