using OldPhonePadCodingChallenge;
using NUnit.Framework;

namespace OldPhonePadTestsNet48
{
    [TestFixture]
    public class PhonePadTests
    {

        [Test]
        public void InvalidInputWithZero_ShouldReturnErrorMessage()
        {
            string input = "0#";
            string expected = "Invalid input: '0' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void InvalidInputWithOne_ShouldReturnErrorMessage()
        {
            string input = "1#";
            string expected = "Invalid input: '1' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void InvalidInputWithSpecialCharacters_ShouldReturnErrorMessage()
        {
            string input = "@#";
            string expected = "Invalid input: '@' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInputLongSequence_ShouldReturnCorrectText()
        {
            string input = "7777777777#";
            string expected = "Q";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void InvalidInputWithMixedInvalidCharacters_ShouldReturnErrorMessage()
        {
            string input = "22A*3#";
            string expected = "Invalid input: 'A' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInputWithMultipleBackspaces_ShouldReturnCorrectText()
        {
            string input = "7777***7#";
            string expected = "P";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectText()
        {
            string input = "222 2 22#";
            string expected = "CAB";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInputWithBackspace_ShouldRemovePreviousCharacter()
        {
            string input = "227*#";
            string expected = "B";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInputWithMultiplePresses_ShouldGetToCorrectLetter()
        {
            string input = "33#";
            string expected = "E";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord1()
        {
            string input = "4433555 555666#";
            string expected = "HELLO";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord2()
        {
            string input = "8 88777444666*664#";
            string expected = "TURING";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void InvalidInputWithoutHashAtTheEnd_ShouldReturnErrorMessage()
        {
            string input = "222";
            string expected = "Invalid input: Must end with '#'.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }

        [Test]
        public void InvalidInputWithInvalidCharacters_ShouldReturnErrorMessage()
        {
            string input = "22A#";
            string expected = "Invalid input: 'A' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input));
        }
    }
}
