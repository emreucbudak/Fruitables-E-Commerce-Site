namespace FruitablesAPI.Exceptions
{
    public class BillsNotFoundExceptions : Exception
    {
        public BillsNotFoundExceptions(int id) : base($"{id}' e sahip fatura bulunamadı!")
        {
        }
    }
}
