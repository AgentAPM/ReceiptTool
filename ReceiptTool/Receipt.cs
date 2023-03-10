using System.Text;

namespace ReceiptTool
{
    public class Receipt
    {
        public delegate void ProductAdded(object sender, string[] args);
        public event ProductAdded OnProductAdded;
        public Receipt(string title, ICurrencyFormat currency)
        {
            Title = title;
            Products = new List<Product>();
            Currency = currency;
        }
        private string Title { get; set; }
        private List<Product> Products { get; set; }
        private ICurrencyFormat Currency { get; set; }
        public Receipt AddProduct(string name, float basePrice, int frameCount, float perFramePrice, float finalPrice)
        {
            var product = new Product(name, basePrice, frameCount, perFramePrice, finalPrice);
            product.Currency = Currency;

            Products.Add(product);
            return this;
        }

        public override string ToString()
        {
            //analize structure
            var totalWidth = 0;
            var rows = new Row[Products.Count];
            int[] columnWidths = null;

            var totalPrice = 0f;
            var totalFinalPrice = 0f;

            for (int i = 0; i < Products.Count; i++)
            {
                var product = Products[i];
                var row = product.ToRow();

                if (columnWidths == null)
                {
                    columnWidths = new int[row.Cells.Count];
                    Array.Fill(columnWidths, 0);
                }
                else
                {
                    if (columnWidths.Length != row.Cells.Count) throw new Exception("Cell count mismatch");
                }

                for (int j = 0; j < row.Cells.Count; j++)
                {
                    var cell = row.Cells[j];
                    if (cell.Width > columnWidths[j])
                    {
                        totalWidth += cell.Width - columnWidths[j];
                        columnWidths[j] = cell.Width;
                    }
                }

                totalPrice += product.UndiscountedPrice;
                totalFinalPrice += product.FinalPrice;

                rows[i] = row;
            }
            //build the receipt
            var sb = new StringBuilder();

            sb.AppendLine(
                Cell.PadString($" {Title} ", 0.5f, totalWidth, '~')
            );

            foreach (var row in rows)
            {
                sb.AppendLine(row.ToString(columnWidths));
            }

            sb.AppendLine(
                "".PadRight(totalWidth, '-')
            );
            sb.AppendLine(new Row()
                .AddCell("total:", 0)
                .AddCell("", 0)
                .AddCell("", 0)
                .AddCell("", 0)
                .AddCell("", 0)
                .AddCell("", 0)
                .AddCell(Currency.Format(totalFinalPrice), 0)
            .ToString(columnWidths));

            return sb.ToString();
        }
    }
}
