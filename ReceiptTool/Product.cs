using System.Text;

namespace ReceiptTool
{
    public class Product
    {
        public Product(string name, float basePrice, int frameCount, float perFramePrice, float finalPrice)
        {
            Name = name;
            BasePrice = basePrice;
            FrameCount = frameCount;
            PerFramePrice = perFramePrice;
            FinalPrice = finalPrice;

            Currency = new USDformat();
        }
        public ICurrencyFormat Currency { get; set; }
        public string Name { get; set; }
        public float BasePrice { get; set; }
        public float PerFramePrice { get; set; }
        public int FrameCount { get; set; }
        public float FinalPrice { get; set; }
        public float UndiscountedPrice
        {
            get
            {
                return BasePrice + PerFramePrice * FrameCount;
            }
        }
        public float Discount
        {
            get
            {
                return FinalPrice / UndiscountedPrice - 1;
            }
        }
        public int[] GetColumns()
        {
            return new int[] { };
        }

        public override string ToString()
        {
            string ProductNameAsString = Name;

            float basePrice = BasePrice;
            string BasePriceAsString = "";
            if (basePrice > 0)
            {
                BasePriceAsString = $"{Currency.Format(BasePrice)} +";
            }

            string FrameCountAsString = FrameCount.ToString();
            string PerFramePriceAsString = Currency.Format(PerFramePrice);

            float discount = Discount * 100;
            string DiscountAsString = "";
            if (discount > 0)
            {
                DiscountAsString = $"+{discount}%";
            }
            else if (discount < 0)
            {
                DiscountAsString = $"-{-discount}%";
            }

            string FinalPriceAsString = Currency.Format(FinalPrice);

            return $"{ProductNameAsString} {BasePriceAsString} {FrameCountAsString}*{PerFramePriceAsString} {DiscountAsString} = {FinalPriceAsString}";
        }

        public Row ToRow()
        {

            string BasePriceAsString = "";
            if (BasePrice > 0)
                BasePriceAsString = Currency.Format(Math.Round(BasePrice, 2));
            string FramePriceAsString = $"{FrameCount}*{Currency.Format(PerFramePrice)}";

            float discount = Discount * 100;
            string DiscountAsString = "";
            if (discount > 0)
                DiscountAsString = $" +{Math.Round(discount, 0)}%";
            else if (discount < 0)
                DiscountAsString = $" -{Math.Round(-discount, 0)}%";

            string FinalPriceAsString = Currency.Format(Math.Round(FinalPrice, 2));

            string BasePlusPerFrameString = "";
            if (BasePrice > 0 && FrameCount > 0)
                BasePlusPerFrameString = " + ";

            return new Row()
                .AddCell(new Cell(Name + " ", 0))
                .AddCell(new Cell(BasePriceAsString, 1))
                .AddCell(new Cell(BasePlusPerFrameString, 1))
                .AddCell(new Cell(FramePriceAsString, 1))
                .AddCell(new Cell(DiscountAsString, 0.5f))
                .AddCell(new Cell(" = ", 1))
                .AddCell(new Cell(FinalPriceAsString, 0))
            ;
        }

    }
}
