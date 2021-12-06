using UnityEngine;
namespace AppleFSM
{
    public class AppleGrowingState : AppleBaseState
    {
        public override void EnterState(AppleStateManager apple)
        {
            Debug.Log("The apple start to grow");
            apple.AppleInit();
        }
        public override void UpdateState(AppleStateManager apple)
        {
            if (AppleStateManager.apple.transform.localScale.x < 1)
                apple.AppleGrowing();
            else
                apple.SwitchState(apple.appleWholeState);
        }
        public override void OnClickEnter(AppleStateManager apple)
        {
            Debug.Log("The apple is still growing, wait for the apple to be mature enough");
        }
    }
}
