namespace UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Servicos
{
    public interface IEntitySerializationServices<T>
         where T : class
    {
        T Deserialize(string text);
        string Serialize(T entity);
    }

}
