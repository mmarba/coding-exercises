using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reverser
{
    [TestClass]
    public class ReverseSentenceTest
    {
        private static Reverser _reverser;

        [ClassInitialize]
        public static void ReverseSentenceTestInitialize(TestContext testContext)
        {
            _reverser = new Reverser(new char[] { '!', ',', '.', ';', '?', ' ' });
        }

        [TestMethod]
        public void GivenEmptyStringWhenReverseSentenceThenEmptyString()
        {
            //Act
            var result = _reverser.ReverseSentence("");

            //Assert
            Assert.AreEqual(string.Empty, result, "Empty sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenSingleSentenceWordWhenReverseSentenceThenSameWordReturned()
        {
            //Act
            var result = _reverser.ReverseSentence("abc");

            //Assert
            Assert.AreEqual("abc", result, "Sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenSpaceSeparatedSentenceWhenReverseSentenceThenSentenceReversed()
        {
            //Act
            var result = _reverser.ReverseSentence("abc def huj f op");

            //Assert
            Assert.AreEqual("op f huj def abc", result, "Sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenStartAndEndSpaceWhenReverseSentenceThenSentenceReversed()
        {
            //Act
            var result = _reverser.ReverseSentence(" abc ghi ");

            //Assert
            Assert.AreEqual(" ghi abc ", result, "Sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenStartSpaceWhenReverseSentenceThenSentenceReversed()
        {
            //Act
            var result = _reverser.ReverseSentence(" abc ghi");

            //Assert
            Assert.AreEqual("ghi abc ", result, "Sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenEndSpaceWhenReverseSentenceThenSentenceReversed()
        {
            //Act
            var result = _reverser.ReverseSentence("abc ghi ");

            //Assert
            Assert.AreEqual(" ghi abc", result, "Sentence not correctly reversed.");
        }

        [TestMethod]
        public void GivenMultipleSeparatorsWhenReverseSentenceThenSentenceReversed()
        {
            //Act
            var result = _reverser.ReverseSentence("?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ");

            //Assert
            Assert.AreEqual(" kl rt;iou;aei ,ty.q.op rg?sa.f, ed!huj ,def abc?", result, "Sentence with multple separators not correctly reversed.");
        }

        [TestMethod]
        public void GivenNaturalLanguageSentenceWhenReverseSentenceThenSentenceReversed()
        {
            //Arrange

            var reverser = new Reverser(new char[] { '!', ',', '.', ';', '?', ' ', '\''});

            //Act
            var result = reverser.ReverseSentence("Topant de cap en una i altra soca, avançant d'esma pel camí de l'aigua, se'n ve la vaca tota sola. És cega.");

            //Assert
            Assert.AreEqual(".cega És .sola tota vaca la ve n'se ,aigua'l de camí pel esma'd avançant ,soca altra i una en cap de Topant", result, "Sentence with multple separators not correctly reversed.");
        }

        [TestMethod]
        public void GivenEmptySeparatorListWhenReverseSentenceThenSameSentenceReturned()
        {
            //Arrange
            var reverser = new Reverser(new char[] { });
            var sentence = "?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ";

            //Act
            var result = reverser.ReverseSentence(sentence);

            //Assert
            Assert.AreEqual(sentence, result, "Single-word sentence with no separators was reversed.");
        }

        [TestMethod]
        public void GivenSameSeparatorSetAndDifferentParseOrdersWhenReverseSentenceThenSameResult()
        {
            //Arrange
            // Create first reverser with a given set of separator chars
            var reverserA = new Reverser(new char[] { '!', ',', '.', ';', '?', ' ' });

            // Create second reverser with same set of separator chars but different parsing order
            var reverserB = new Reverser(new char[] { ' ', ',', '?', ';', '.', '!' });

            var sentence = "?abc def, huj!ed ,f.sa?rg op.q.ty, aei;iou;rt kl ";

            //Act
            var resultA = reverserA.ReverseSentence(sentence);
            var resultB = reverserB.ReverseSentence(sentence);

            //Assert
            Assert.AreEqual(resultA, resultB, "Reverse sentence yields different result depending on parsing order.");
        }
    }
}
