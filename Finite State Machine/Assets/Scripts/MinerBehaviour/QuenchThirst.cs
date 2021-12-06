using UnityEngine;
namespace MinerFSM
{
    public class QuenchThirst : MinerBaseState
    {
        readonly static QuenchThirst instance = new QuenchThirst();
        QuenchThirst() { }
        public static QuenchThirst Instance
        {
            get
            {
                return instance;
            }
        }
        public override void EnterState(MinerStateManager miner)
        {
            if (miner.location != LocationType.Quench)
            {
                Debug.Log("Walking to the bar");
                miner.ChangeLocation(LocationType.Quench);
            }
        }
        public override void UpdateState(MinerStateManager miner)
        {
            if (!miner.ThirstQuenched())
                miner.Drink();
            else
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
        }
        public override void ExitState(MinerStateManager miner)
        {
            Debug.Log("Ok, Let's go back to the old dirty mine");
        }


    }
}