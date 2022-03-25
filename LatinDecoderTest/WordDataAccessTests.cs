using LatinDecoderDAL;
using System.Collections.Generic;
using Xunit;

namespace LatinDecoderTest
{
    public class WordDataAccessTests
    {
        private readonly WordDataAccess _sut;

        public WordDataAccessTests()
        {
            _sut = new WordDataAccess("./Resources/forms.txt");
        }


        [Fact]
        public void TestEmptyToken()
        {
            string token = "";
            List<string> matchesExpected = new List<string>();
            List<string> matchesActual = _sut.GetWordListSentence(token);

            Assert.Equal(matchesExpected, matchesActual);
        }

        [Fact]
        public void TestLongDash()
        {
            string token = "iun—m";
            List<string> matchesExpected = new List<string>()
            {
                "iuncum",
                "iungam",
                "iuniam",
                "iunium"
            };
            List<string> matchesActual = _sut.GetWordListSentence(token);

            matchesExpected.Sort();
            matchesActual.Sort();

            Assert.Equal(matchesExpected, matchesActual);
        }

        [Fact]
        public void TestJustDashes()
        {
            string token = "--------------------";
            List<string> matchesExpected = new List<string>()
            {
                "circumfundebanturque",
                "circumscriptionesque",
                "circumspectantiumque",
                "duoetuicensimanosque",
                "formidolosissimumque",
                "innumerabilitatemque",
                "magnificentissimique",
                "margariticandicantia",
                "munificentissimusque",
                "pollicitationibusque",
                "praeterequitantesque",
                "quintadecimanorumque"
            };

            List<string> matchesActual = _sut.GetWordListSentence(token);

            matchesExpected.Sort();
            matchesActual.Sort();

            Assert.Equal(matchesExpected, matchesActual);
        }

        [Fact]
        public void TestShortDashWithLongDash()
        {
            string token = "iun—-m";
            List<string> matchesExpected = new List<string>()
            {
                "iunceam",
                "iunceum",
                "iunctam",
                "iunctim",
                "iunctum",
                "iunicum"
            };

            List<string> matchesActual = _sut.GetWordListSentence(token);

            matchesExpected.Sort();
            matchesActual.Sort();

            Assert.Equal(matchesExpected, matchesActual);
        }


        [Theory]
        [MemberData(nameof(TestData1))]
        public void TestSingleWordTheory(List<string> expected, string token)
        {
            List<string> actual = _sut.GetWordListSentence(token);
            actual.Sort();
            expected.Sort();
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData1()
        {
            yield return new object[] { new List<string>() { "iuncum", "iungam", "iuniam", "iunium" }, "iun--m" };
            yield return new object[] { new List<string>() { "lauder", "pauper" }, "-au-er" };
            yield return new object[] { new List<string>() { "expedio", "experio", "impedio", "imperio", "inpedio", "inperio", "reperio", "sepelio" }, "--pe-io" };
        }

        [Theory]
        [MemberData(nameof(TestData2))]
        public void TestMultipleWordTheory(List<string> expected, string token)
        {
            List<string> actual = _sut.GetWordListSentence(token);
            actual.Sort();
            expected.Sort();
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData2()
        {
            yield return new object[] { new List<string>() { "iuncum lauder", "iuncum pauper", "iungam lauder", "iungam pauper", "iuniam lauder", "iuniam pauper", "iunium lauder", "iunium pauper" }, "iun--m -au-er" };
            yield return new object[] { new List<string>() { "iuncum pauper abacta", "iuncum pauper abacti", "iuncum pauper abacto", "iungam pauper abacta", "iungam pauper abacti", "iungam pauper abacto", "iuniam pauper abacta", "iuniam pauper abacti", "iuniam pauper abacto", "iunium pauper abacta", "iunium pauper abacti", "iunium pauper abacto" }, "iun--m paup-r abact-" };
        }



    }

}
