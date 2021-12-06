using UnityEngine;
namespace MinerFSM
{
    public class VisitBankAndDepositGold : MinerBaseState
    {
        readonly static VisitBankAndDepositGold instance = new VisitBankAndDepositGold();
        VisitBankAndDepositGold() { }
        public static VisitBankAndDepositGold Instance
        {
            get
            {
                return instance;
            }
        }
        public override void EnterState(MinerStateManager miner)
        {
            if (miner.location != LocationType.Bank)
            {
                Debug.Log("Walking to the bank");
                miner.ChangeLocation(LocationType.Bank);
            }
        }
        public override void UpdateState(MinerStateManager miner)
        {
            Debug.Log("Depositing gold");
            miner.DepositGold();
            if (miner.WealthyEnough())
                miner.ChangeState(GoHomeAndSleepTilRested.Instance);
            else
                miner.ChangeState(EnterMineAndDigForNugget.Instance);

        }
        public override void ExitState(MinerStateManager miner)
        {
            if (miner.WealthyEnough())
                Debug.Log("I finished for today, let's go back home");
            else
                Debug.Log("Let's go back to the old dirty mine");
        }


    }
}