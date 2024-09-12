using TetrisModel.Model;

namespace TetrisModel.Persistence
{
    public interface ISaveTo
    {
        public void WriteState(State s);

        public State ReadState();
    }
}