using UnityEngine;
namespace AppleFSM
{
    public class AppleWholeState : AppleBaseState
    {
        int timeToRestart = 3;
        int currentTime = 0;
        public override void EnterState(AppleStateManager apple)
        {
            Debug.Log("The apple has the proper size");
            currentTime = 0;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            ++currentTime;
            if (currentTime >= timeToRestart)
                apple.SwitchState(apple.appleRottenState);
        }
        public override void OnClickEnter(AppleStateManager apple)
        {
            Debug.Log("You eat the apple!");
            apple.SwitchState(apple.appleChewedState);
        }

    }
}
