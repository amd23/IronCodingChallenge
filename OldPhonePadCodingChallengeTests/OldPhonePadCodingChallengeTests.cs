using NUnit.Framework;
using OldPhonePadCodingChallenge;

namespace OldPhonePadTestsNet48
{
    [TestFixture]
    public class PhonePadTests
    {
        [Test]
        public void ValidInput_ShouldReturnCorrectText()
        {
            string input = "222 2 22#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("CAB", result);
        }

        [Test]
        public void InputWithBackspace_ShouldRemovePreviousCharacter()
        {
            string input = "227*#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("B", result);
        }

        [Test]
        public void InputWithMultiplePresses_ShouldGetToCorrectLetter()
        {
            string input = "33#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("E", result);
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord1()
        {
            string input = "4433555 555666#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord2()
        {
            string input = "8 88777444666*664#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("TURING", result);
        }

        [Test]
        public void InputWithoutHashAtTheEnd_ShouldReturnError()
        {
            string input = "222";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("Invalid input: Must end with '#'", result);
        }

        [Test]
        public void InputWithInvalidCharacters_ShouldReturnError()
        {
            string input = "22A#";
            string result = Program.OldPhonePad(input);
            Assert.AreEqual("Invalid input: 'A' is not allowed.", result);
        }
    }
}
