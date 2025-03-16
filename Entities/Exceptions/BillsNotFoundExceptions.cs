using Entities.Exceptions;

namespace FruitablesAPI.Exceptions
{
    public sealed class BillsNotFoundExceptions : NotFoundExceptions
    {
        public BillsNotFoundExceptions(int id) : base($"{id}' e sahip fatura bulunamadı!")
        {
        }
    }
}
