using System;
using NUnit.Framework;
using Yahtzee;

namespace YahtzeeTest
{
    [TestFixture]
    public class InputParserTest
    {
        private InputParser _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new InputParser();
        }

        [Test]
        public void ParseInput_WhenCalledWithR_ReturnsReRoll()
        {
            var input = "R134";
            var expected = InputParser.Option.ReRoll;

            var actual = _sut.ParseInput(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseInput_WhenCalledWithQ_ReturnsQuit()
        {
            var input = "Q";
            var expected = InputParser.Option.Quit;

            var actual = _sut.ParseInput(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDiceForReroll_WhenInputStartsWithR_ReadsDiceNumbersFromInput()
        {
            var input = "R134";
            int[] expected = {1, 3, 4};
            
            var actual = _sut.GetDiceForReroll(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSelectedCategory_WhenInputDoesNotStartWithDigit_Throws()
        {
            var input = "Q";

            TestDelegate del = () => _sut.GetSelectedCategory(input);

            Assert.Throws<ArgumentException>(del);
        }

        [TestCase("12")]
        [TestCase("")]
        [TestCase("9812")]
        public void GetSelectedCategory_WhenInputLengthIsNotOne_Throws(string illegalInput)
        {
            TestDelegate del = () => _sut.GetSelectedCategory(illegalInput);

            Assert.Throws<ArgumentException>(del);
        }

        [TestCase("1", YahtzeeCategory.Sum)]
        [TestCase("4", YahtzeeCategory.FourOfAKind)]
        [TestCase("8", YahtzeeCategory.LargeStreet)]
        public void GetSelectedCategory_WhenInputIsValid_ReturnsCategory(string input, YahtzeeCategory expected)
        {
            var actual = _sut.GetSelectedCategory(input);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RestartHandler_TestWithPositive()
        {
            var safetyinput = "5";
            var dicerolls = new[] {1, 2, 3, 4, 5};
            TestDelegate del = () => _sut.RestartHandler(dicerolls, safetyinput);

            Assert.Throws<ScoreBoardException>(del);
        }
    }
}