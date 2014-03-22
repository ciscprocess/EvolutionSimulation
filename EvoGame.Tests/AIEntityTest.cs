using EvoGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicIO;
using System.Drawing;

namespace EvoGame.Tests
{
    
    
    /// <summary>
    ///This is a test class for AIEntityTest and is intended
    ///to contain all AIEntityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AIEntityTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AIEntity Constructor
        ///</summary>
        [TestMethod()]
        public void AIEntityConstructorTest1()
        {
            AIEntity target = new AIEntity();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AIEntity Constructor
        ///</summary>
        [TestMethod()]
        public void AIEntityConstructorTest2()
        {
            Bitmap cParent = null; // TODO: Initialize to an appropriate value
            AIEntity target = new AIEntity(cParent);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.Clone();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Draw
        ///</summary>
        [TestMethod()]
        public void DrawTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            target.Draw();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitImage
        ///</summary>
        [TestMethod()]
        public void InitImageTest()
        {
            AIEntity.InitImage();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Mutate
        ///</summary>
        [TestMethod()]
        public void MutateTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            AIEntity expected = null; // TODO: Initialize to an appropriate value
            AIEntity actual;
            actual = target.Mutate();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for See
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EvoGame.exe")]
        public void SeeTest()
        {
            AIEntity_Accessor target = new AIEntity_Accessor(); // TODO: Initialize to an appropriate value
            double[] expected = null; // TODO: Initialize to an appropriate value
            double[] actual;
            actual = target.See();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StepTime
        ///</summary>
        [TestMethod()]
        public void StepTimeTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            bool fooded = false; // TODO: Initialize to an appropriate value
            bool poisoned = false; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.StepTime(fooded, poisoned);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Age
        ///</summary>
        [TestMethod()]
        public void AgeTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            long actual;
            actual = target.Age;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Brain
        ///</summary>
        [TestMethod()]
        public void BrainTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            Brain actual;
            actual = target.ParentBrain;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Inputs
        ///</summary>
        [TestMethod()]
        public void InputsTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            Port[] expected = null; // TODO: Initialize to an appropriate value
            Port[] actual;
            actual = target.Inputs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Outputs
        ///</summary>
        [TestMethod()]
        public void OutputsTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            Port[] expected = null; // TODO: Initialize to an appropriate value
            Port[] actual;
            actual = target.Outputs;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            AIEntity target = new AIEntity(); // TODO: Initialize to an appropriate value
            PointF expected = new PointF(); // TODO: Initialize to an appropriate value
            PointF actual;
            target.Position = expected;
            actual = target.Position;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
