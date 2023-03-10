namespace ReceiptTool
{
    public class PLNformat : ICurrencyFormat
    {
        public string Format(float amount)
        {
            return amount.ToString("0.00zł");

        }
        public string Format(double amount)
        {
            return amount.ToString("0.00zł");
        }
    }
}
