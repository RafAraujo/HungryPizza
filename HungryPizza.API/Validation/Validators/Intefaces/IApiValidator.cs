namespace HungryPizza.API.Validation.Validators.Intefaces
{
    public interface IApiValidator<T>
    {
        IApiValidationResult Validate(T instance);
    }
}
