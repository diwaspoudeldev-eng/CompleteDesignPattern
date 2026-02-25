namespace InterfaceLayer
{
    public interface IValidation<T>
    {
        void Validate(T entity);
    }
}
