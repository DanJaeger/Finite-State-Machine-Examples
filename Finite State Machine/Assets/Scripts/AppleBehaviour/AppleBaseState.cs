using UnityEngine;
namespace AppleFSM
{
    public abstract class AppleBaseState
    {
        public abstract void EnterState(AppleStateManager apple);
        public abstract void UpdateState(AppleStateManager apple);
        public abstract void OnClickEnter(AppleStateManager apple);
    }
}