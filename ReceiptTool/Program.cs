/* TODO
 * 
 * */

namespace ReceiptTool
{
    public class Program
    {
        public Program() 
        {
            
        }
        public static void Main(string[] args)
        {
            var receipt = new Receipt("Paragon z Biedronki",new PLNformat())
                //.AddTitle("Paragon z Biedronki")
                .AddProduct("Big Milk 1L",0f,1,12.94f,12.94f)
                .AddProduct("Lody Śnieżka",0f,6,1.95f,7.80f)
                .AddProduct("Chleb Tostowy",0f,2,3.69f,7.38f)
                .AddProduct("Nutella",0f,2,13.59f,18.30f)
                .AddProduct("Mleko 1L",0f,3,3.69f,11.07f)
                .AddProduct("Płatki Cheerrios",0f,1,6.81f,4.99f)
                //.AddSeparator()
                //.AddTotal()
                //.AddTotalDiscount()
                //.AddFinalTotal()
            ;
            Console.WriteLine(receipt.ToString());

        }
    }
}