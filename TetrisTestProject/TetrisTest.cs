using Moq;
using TetrisModel.Model;
using TetrisModel.Persistence;

namespace TetrisTestProject
{
    [TestClass]
    public class TetrisTest
    {

        Mock<ISaveTo> _mock = null;
        ISaveTo _save = null;

        [TestMethod]
        public void StateMaker()
        {
            State s = new State(4,16);
            Assert.AreEqual(s.points, 0);
            Assert.AreEqual(s.time, 0);
            Assert.IsFalse(s.table.isFullRow(2));
        }

        [TestMethod]
        public void ColumnTest()
        {
            var s = new State(2,2);
            Assert.IsTrue(s.table.isRealColumn(1));
            Assert.IsFalse(s.table.isRealColumn(3));
        }

        [TestMethod]
        public void RowTest()
        {
            var s = new State(2, 2);
            Assert.IsTrue(s.table.isRealRow(1));
            Assert.IsTrue(s.table.isRealRow(3));
            Assert.IsFalse(s.table.isRealRow(6));
        }

        [TestMethod]
        public void SaveAndLoadTest()
        {
            _save = new SaveToFile("test.txt");
            var s = new State(2,2);
            s.table[1, 0] = 1;
            _save.WriteState(s);
            
            var s2 = new State(2, 2);
            s2 = _save.ReadState();
            Assert.AreEqual(s.getPoints(), s2.getPoints());
            Assert.AreEqual(s.getTime(), s2.getTime());
            Assert.AreEqual(s.table[0,1], s2.table[0,1]);
            Assert.AreEqual(s.table[1, 0], s2.table[1, 0]);

        }
        [TestMethod]
        public void GeneratorTest()
        {
            NextBlock next = new NextBlock();
            next.getNextAndGenerate();
            Assert.IsTrue(next != null);
            Assert.IsTrue(next.next != null);

        }
        [TestMethod]
        public void RotationTest()
        {
            Block b = new Block();
            Assert.IsTrue(b.rot == Rotation.ZERO);
            Assert.IsTrue(RotationFunctions.rotationValue(b.rot) == 0);
            b.RotateRight();
            Assert.IsTrue(b.rot == Rotation.NINETY);
        }
        [TestMethod]
        public void TimeTest()
        {
            State s = new State();
            s.AddTime();
            Assert.IsTrue(s.time == 1);
        }



    }
}