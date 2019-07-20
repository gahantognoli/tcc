using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace UNIFAFIBE.TCC._4Sales.Infra.Serialization.Servicos
{
    public class AllPropertiesResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            //property.HasMemberAttribute = true;
            property.Ignored = false;

            //property.ShouldSerialize = instance =>
            // {
            //     return true;
            // };

            return property;
        }
    }
}
