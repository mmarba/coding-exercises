using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reverser
{
    [TestClass]
    public class ReverseTest
    {
        private static Reverser _reverser;

        [ClassInitialize]
        public static void ReverseTestInitialize(TestContext testContext)
        {
            _reverser = new Reverser(new char[]{ '!', ',', '.', ';', '?', ' ' });
        }

        [TestMethod]
        public void GivenEmptyStringWhenReverseThenEmptyString()
        {
            //Act
            var result = _reverser.Reverse("");

            //Assert
            Assert.AreEqual(string.Empty, result, "Empty string not correctly reversed.");
        }

        [TestMethod]
        public void GivenWordWhenReverseThenWordReversed()
        {
            //Act
            var result = _reverser.Reverse("abc");

            //Assert
            Assert.AreEqual("cba", result, "Word not correctly reversed.");
        }

        [TestMethod]
        public void GivenOneLetterWordWhenReverseThenSameWordReturned()
        {
            //Act
            var result = _reverser.Reverse("A");

            //Assert
            Assert.AreEqual("A", result, "Word not correctly reversed.");
        }

        [TestMethod]
        public void GivenSpaceSeparatedSentenceWhenReverseThenWordsReversed()
        {
            //Act
            var result = _reverser.Reverse("abc def huj f op");

            //Assert
            Assert.AreEqual("cba fed juh f po", result, "Words not correctly reversed.");
        }

        [TestMethod]
        public void GivenStartAndEndSpaceWhenReverseThenWordsReversedHasStartAndEndSpace()
        {
            //Act
            var result = _reverser.Reverse(" abc ghi ");

            //Assert
            Assert.AreEqual(" cba ihg ", result, "Words not correctly reversed.");
        }

        [TestMethod]
        public void GivenStartSpaceWhenReverseThenWordsReversedHasStartSpace()
        {
            //Act
            var result = _reverser.Reverse(" abc ghi");

            //Assert
            Assert.AreEqual(" cba ihg", result, "Words not correctly reversed.");
        }

        [TestMethod]
        public void GivenEndSpaceWhenReverseThenWordsReversedHasEndSpace()
        {
            //Act
            var result = _reverser.Reverse("abc ghi ");

            //Assert
            Assert.AreEqual("cba ihg ", result, "Words not correctly reversed.");
        }

        [TestMethod]
        public void GivenMultipleSeparatorsWhenReverseThenWordsReversed()
        {
            //Act
            var result = _reverser.Reverse("?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ");

            //Assert
            Assert.AreEqual("?cba fed, juh!de ,f.as?gr po.q.yt, iea;uoi;tr lk ", result, "Words with multple separators not correctly reversed.");
        }

        [TestMethod]
        public void GivenEmptySeparatorListWhenReverseThenWholeSentenceReversed()
        {
            //Arrange
            var reverser = new Reverser(new char[] { });

            //Act
            var result = reverser.Reverse("?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ");

            //Assert
            Assert.AreEqual(" lk tr;uoi;iea ,yt.q.po gr?as.f, de!juh ,fed cba?", result, "Word with no separators not correctly reversed.");
        }

        [TestMethod]
        public void GivenSameSeparatorSetAndDifferentParseOrdersWhenReverseThenSameResult()
        {
            //Arrange
            // Create first reverser with a given set of separator chars
            var reverserA = new Reverser(new char[] { '!', ',', '.', ';', '?', ' ' });

            // Create second reverser with same set of separator chars but different parsing order
            var reverserB = new Reverser(new char[] { ' ', ',', '?', ';', '.', '!' });

            var sentence = "?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ";

            //Act
            var resultA = reverserA.Reverse(sentence);
            var resultB = reverserB.Reverse(sentence);

            //Assert
            Assert.AreEqual(resultA , resultB, "Reverse yields different result depending on parsing order.");
        }
    }
}
