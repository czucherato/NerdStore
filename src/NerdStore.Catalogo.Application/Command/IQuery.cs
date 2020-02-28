namespace NerdStore.Catalogo.Application.Command
{
    public interface IQuery<T>
    {
        T Executar();
    }
}