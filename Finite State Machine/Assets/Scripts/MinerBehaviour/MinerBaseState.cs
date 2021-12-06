using UnityEngine;
namespace MinerFSM
{
    public abstract class MinerBaseState
    {
        public abstract void EnterState(MinerStateManager miner);
        public abstract void UpdateState(MinerStateManager miner);
        public abstract void ExitState(MinerStateManager miner);
    }
}