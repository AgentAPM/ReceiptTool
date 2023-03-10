namespace ReceiptTool
{
    public interface ICurrencyFormat
    {
        string Format(float amount);
        string Format(double amount);
    }
}
