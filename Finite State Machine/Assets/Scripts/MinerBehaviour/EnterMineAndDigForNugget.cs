using UnityEngine;
namespace MinerFSM
{
    public class EnterMineAndDigForNugget : MinerBaseState
    {
        readonly static EnterMineAndDigForNugget instance = new EnterMineAndDigForNugget();
        EnterMineAndDigForNugget() { }
        public static EnterMineAndDigForNugget Instance
        {
            get
            {
                return instance;
            }
        }
        public override void EnterState(MinerStateManager miner)
        {
            if (miner.location != LocationType.Mine)
            {
                Debug.Log("Walking to the mine");
                miner.ChangeLocation(LocationType.Mine);
            }
        }
        public override void UpdateState(MinerStateManager miner)
        {
            miner.AddToGoldCarried();
            miner.IncreaseThirst();
            miner.IncreaseFatigue();
            Debug.Log("Picking up nugget");

            if (miner.PocketsFull())
                miner.ChangeState(VisitBankAndDepositGold.Instance);

            if (miner.Thirsty())
                miner.ChangeState(QuenchThirst.Instance);

            if (miner.IsFatigued())
                miner.ChangeState(GoHomeAndSleepTilRested.Instance);
        }

        public override void ExitState(MinerStateManager miner)
        {
            if (miner.PocketsFull())
                Debug.Log("Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
            else
                Debug.Log("Ah'm thirsty as hell, what do a minah have to do to get a cold bea?");
        }
    }
}