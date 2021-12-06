using UnityEngine;
namespace AppleFSM
{
    public class AppleRottenState : AppleBaseState
    {
        int timeToRestart = 3;
        int currentTime = 0;
        public override void EnterState(AppleStateManager apple)
        {
            Debug.Log("The apple is rotten");
            apple.currentAppleImage.sprite = apple.appleRottenStateImage.sprite;
            currentTime = 0;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            ++currentTime;
            if (currentTime >= timeToRestart)
                apple.SwitchState(apple.appleGrowingState);
        }
        public override void OnClickEnter(AppleStateManager apple)
        {
            Debug.Log("You can't bite a rotten apple");
        }
    }
}