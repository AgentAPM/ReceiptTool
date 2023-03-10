namespace ReceiptTool
{
    public class USDformat : ICurrencyFormat
    {
        public string Format(float amount)
        {
            return "$" + amount;
        }
        public string Format(double amount)
        {
            return "$" + amount;
        }
    }
}
