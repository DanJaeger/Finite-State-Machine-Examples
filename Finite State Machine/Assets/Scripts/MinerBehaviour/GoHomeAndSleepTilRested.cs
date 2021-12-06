using UnityEngine;
namespace MinerFSM
{
    public class GoHomeAndSleepTilRested : MinerBaseState
    {
        readonly static GoHomeAndSleepTilRested instance = new GoHomeAndSleepTilRested();
        GoHomeAndSleepTilRested() { }
        public static GoHomeAndSleepTilRested Instance
        {
            get
            {
                return instance;
            }
        }
        public override void EnterState(MinerStateManager miner)
        {
            if (miner.location != LocationType.Home)
            {
                Debug.Log("Walking to home");
                miner.ChangeLocation(LocationType.Home);
            }
        }
        public override void UpdateState(MinerStateManager miner)
        {
            Debug.Log("*Snoring like a train in movement");
            if (!miner.IsFatigued())
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            else
                miner.Rest();
        }
        public override void ExitState(MinerStateManager miner)
        {
            Debug.Log("Time to get more sweet gold");
        }


    }
}