namespace OldPhonePad.Test;

public class UnitTestOldPhone
{
    [Theory] //we could use [Fact] but we will use [Theory] to be able to pass parameters
    [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        [InlineData("7777#", "S")]
        [InlineData("999#", "Z")]
        [InlineData("2#", "A")]
        public void TestOldPhonePad(string Numbers, string ExpectedStr)
        {
            string Current = Program.OldPhonePad(Numbers);
            Assert.Equal(ExpectedStr, Current);
        }
}
