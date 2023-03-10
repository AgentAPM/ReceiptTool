using System.Text;

namespace ReceiptTool
{
    public class Cell
    {
        public Cell(string content, float padding, char filler = ' ')
        {
            Content = content;
            Padding = padding;
            Filler = filler;
            MinWidth = Content.Length;
        }
        public string Content { get; set; }
        public float Padding { get; set; }
        public char Filler { get; set; }
        public int Width
        {
            get
            {
                return Math.Max(Content.Length, MinWidth);
            }
        }
        public int MinWidth { get; set; }
        public override string ToString()
        {
            return Cell.PadString(Content, Padding, MinWidth, Filler);
        }
        public string ToString(int minWidth)
        {
            MinWidth = minWidth;
            return ToString();
        }

        public static string PadString(string content, float padding, int minWidth, char filler)
        {
            int width = Math.Max(content.Length, minWidth);
            int left = (int)(padding * (width - content.Length));
            return content.PadLeft(content.Length + left, filler).PadRight(width, filler);
        }
    }
    public class Row
    {
        public List<Cell> Cells { get; private set; }
        public Row()
        {
            Cells = new List<Cell>();
        }
        public Row(string[] cells, float[] paddings, char[] fillers)
        {

        }
        public Row(Cell[] cells)
        {
            Cells = new List<Cell>(cells);
        }

        public Row AddCell(Cell cell)
        {
            Cells.Add(cell);
            return this;
        }
        public Row AddCell(string content, float padding, char filler)
        {
            AddCell(new Cell(content, padding, filler));
            return this;
        }
        public Row AddCell(string content, float padding)
        {
            AddCell(new Cell(content, padding));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var cell in Cells)
            {
                sb.Append(cell.ToString());
            }
            return sb.ToString();
        }
        public string ToString(int[] columnWidths)
        {
            if (columnWidths.Length == 1)
            {
                return ToString(columnWidths[0]);
            }
            else if (columnWidths.Length == Cells.Count)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Cells.Count; i++)
                {
                    var cell = Cells[i];
                    var width = columnWidths[i];

                    sb.Append(cell.ToString(width));
                }
                return sb.ToString();
            }
            else
                throw new Exception($"Number of parameters {columnWidths.Length} doesn't match the number of cells {Cells.Count}.");
        }
        public string ToString(int width)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Cells.Count; i++)
            {
                var cell = Cells[i];

                sb.Append(cell.ToString(width));
            }
            return sb.ToString();
        }
    }

}
