using NUnit.Framework;
using Version1.domainLayer.DiscountPolicies;

namespace TestProject.UnitTests.DiscountsTests
{
    public class ConditionTests : ATProject
    {

        public Condition condition;
        [Test]
        public void orTest()
        {
            condition = Condition.Parse("(or,(T[]),(F[]))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
       
        [Test]
        public void andTest()
        {
            condition = Condition.Parse("(and,(T[]),(T[]))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void orTestComposite()
        {
            condition = Condition.Parse("(or,(T[]),(and,(F[]),(F[])))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void andTestComposite()
        {
            condition = Condition.Parse("(and,(T[]),(and,(T[]),(T[])))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void orTestFalseCase()
        {
            condition = Condition.Parse("(or,(F[]),(or,(F[]),(F[])))");
            Assert.False(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void andTestFalseCase()
        {
            condition = Condition.Parse("(and,(F[]),(or,(T[]),(F[])))");
            Assert.False(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void xorTest1()
        {
            condition = Condition.Parse("(xor,(T[]),(F[]))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void xorTest2()
        {
            condition = Condition.Parse("(xor,(F[]),(T[]))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void xorTestFalseCase()
        {
            condition = Condition.Parse("(xor,(F[]),(F[]))");
            Assert.False(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void xorTestFalseCase2()
        {
            condition = Condition.Parse("(xor,(T[]),(T[]))");
            Assert.False(condition.evaluate(null, null, null, 0));
        }
        [Test]
        public void xorCompositeTestCase()
        {
            condition = Condition.Parse("(xor,(or,(F[]),(or,(F[]),(F[]))),(T[]))");
            Assert.True(condition.evaluate(null, null, null, 0));
        }

    }
}