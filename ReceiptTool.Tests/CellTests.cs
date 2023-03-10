namespace ReceiptTool.Tests
{
    public class CellTests
    {
        [Test]
        public void WhenLongEnough_ShouldNotPad()
        {
            //Assign
            string text = "Hello!";
            float offset = 0;
            int padding = -2;
            string expected = "Hello!";

            //Act
            var cell = new Cell(text, offset);
            cell.MinWidth += padding;
            var result = cell.ToString();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void WhenPadding0_ShouldAlignLeft()
        {
            //Assign
            string text = "Hello!";
            float offset = 0;
            int padding = 6;
            string expected = "Hello!      ";

            //Act
            var cell = new Cell(text, offset);
            cell.MinWidth += padding;
            var result = cell.ToString();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void WhenPadding1_ShouldAlignRight()
        {
            //Assign
            string text = "Hello!";
            float offset = 1;
            int padding = 6;
            string expected = "      Hello!";

            //Act
            var cell = new Cell(text, offset);
            cell.MinWidth += padding;
            var result = cell.ToString();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void WhenPadding05_ShouldAlignCenter()
        {
            //Assign
            string text = "Hello!";
            float offset = 0.5f;
            int padding = 6;
            string expected = "   Hello!   ";

            //Act
            var cell = new Cell(text, offset);
            cell.MinWidth += padding;
            var result = cell.ToString();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}