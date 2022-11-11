using GraphQL;
using GraphQL.Types;

namespace ApiCepCB.GraphQL.Schemas
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CepQuery>();
        }
    }
}
