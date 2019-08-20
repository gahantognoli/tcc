using Newtonsoft.Json;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos;

namespace UNIFAFIBE.TCC._4Sales.Infra.Serialization.Servicos
{
    public class JSONSerializationServices<T> : IEntitySerializationServices<T>
        where T : class
    {
        public T Deserialize(string text)
        {
            return JsonConvert.DeserializeObject<T>(text,
              new JsonSerializerSettings()
              {
                  ContractResolver = new AllPropertiesResolver(),
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                  Culture = new System.Globalization.CultureInfo("pt-BR")
              }); 
        }

        public string Serialize(T entity)
        {
            return JsonConvert.SerializeObject(entity,
               new JsonSerializerSettings()
               {
                   ContractResolver = new AllPropertiesResolver(),
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                   Culture = new System.Globalization.CultureInfo("pt-BR")
               });
        }
    }
}
