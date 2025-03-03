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
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void InvalidInputWithOne_ShouldReturnErrorMessage()
        {
            string input = "1#";
            string expected = "Invalid input: '1' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void InvalidInputWithSpecialCharacters_ShouldReturnErrorMessage()
        {
            string input = "@#";
            string expected = "Invalid input: '@' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInputLongSequence_ShouldReturnCorrectText()
        {
            string input = "7777777777#";
            string expected = "Q";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void InvalidInputWithMixedInvalidCharacters_ShouldReturnErrorMessage()
        {
            string input = "22A*3#";
            string expected = "Invalid input: 'A' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInputWithMultipleBackspaces_ShouldReturnCorrectText()
        {
            string input = "7777***7#";
            string expected = "P";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectText()
        {
            string input = "222 2 22#";
            string expected = "CAB";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInputWithBackspace_ShouldRemovePreviousCharacter()
        {
            string input = "227*#";
            string expected = "B";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInputWithMultiplePresses_ShouldGetToCorrectLetter()
        {
            string input = "33#";
            string expected = "E";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord1()
        {
            string input = "4433555 555666#";
            string expected = "HELLO";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void ValidInput_ShouldReturnCorrectTextWord2()
        {
            string input = "8 88777444666*664#";
            string expected = "TURING";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        [Test]
        public void InvalidInputWithoutHashAtTheEnd_ShouldReturnFalse()
        {
            string input = "222";
            Assert.IsFalse(Program.IsValidInputFormat(input));
        }

        [Test]
        public void InvalidInputWithInvalidCharacters_ShouldReturnErrorMessage()
        {
            string input = "22A#";
            string expected = "Invalid input: 'A' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "English"));
        }

        // ----------- Spanish Test Cases -----------

        [Test]
        public void Spanish_InvalidInputWithZero_ShouldReturnErrorMessage()
        {
            string input = "0#";
            string expected = "Invalid input: '0' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "Spanish"));
        }

        [Test]
        public void Spanish_ValidInputWithMultiplePresses_ShouldGetToCorrectLetter()
        {
            string input = "777#";
            string expected = "R";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "Spanish"));
        }

        [Test]
        public void Spanish_ValidInputWithSpecialCharacter—_ShouldReturnCorrectText()
        {
            string input = "77777#";
            string expected = "—";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "Spanish"));
        }

        [Test]
        public void Spanish_ValidInputWord_ShouldReturnCorrectText()
        {
            string input = "7 33 77777 2 555 666#";  // "PE—ALO"
            string expected = "PE—ALO";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "Spanish"));
        }

        [Test]
        public void Spanish_ValidInputWithBackspace_ShouldRemovePreviousCharacter()
        {
            string input = "227*#";
            string expected = "B";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "Spanish"));
        }


        // ----------- French Test Cases -----------

        [Test]
        public void French_InvalidInputWithZero_ShouldReturnErrorMessage()
        {
            string input = "0#";
            string expected = "Invalid input: '0' is not a valid character.";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "French"));
        }

        [Test]
        public void French_ValidInputWithMultiplePresses_ShouldGetToCorrectLetter()
        {
            string input = "999#";
            string expected = "Y";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "French"));
        }

        [Test]
        public void French_ValidInputWithAccents_ShouldReturnCorrectText()
        {
            string input = "99999#";
            string expected = "…";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "French"));
        }

        [Test]
        public void French_ValidInputWord_ShouldReturnCorrectText()
        {
            string input = "7 33 555 666 99999#";  // "PELO…"
            string expected = "PELO…";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "French"));
        }

        [Test]
        public void French_ValidInputWithBackspace_ShouldRemovePreviousCharacter()
        {
            string input = "4433555 555666*#";
            string expected = "HELL";
            Assert.AreEqual(expected, Program.OldPhonePad(input, "French"));
        }


    }
}
