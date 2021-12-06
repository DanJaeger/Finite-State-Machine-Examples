using UnityEngine;
namespace AppleFSM
{
    public class AppleChewedState : AppleBaseState
    {
        int timeToRestart = 3;
        int timeSinceBite = 0;
        public override void EnterState(AppleStateManager apple)
        {
            Debug.Log("You ate the apple");
            apple.currentAppleImage.sprite = apple.appleChewedStateImage.sprite;
            timeSinceBite = 0;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            ++timeSinceBite;
            if (timeSinceBite >= timeToRestart)
                apple.SwitchState(apple.appleGrowingState);
        }
        public override void OnClickEnter(AppleStateManager apple)
        {
            Debug.Log("You already bit the apple");
        }
    }
}
