using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace AppleFSM{ 
    public class AppleStateManager : MonoBehaviour
    {
        AppleBaseState currentState;
        [SerializeField]TextMeshProUGUI currentStateText;

        public AppleGrowingState appleGrowingState = new AppleGrowingState();
        public AppleWholeState appleWholeState = new AppleWholeState();
        public AppleChewedState appleChewedState = new AppleChewedState();
        public AppleRottenState appleRottenState = new AppleRottenState();

        public static GameObject apple;
        public Image currentAppleImage;
        public Image appleWholeStateImage;
        public Image appleChewedStateImage;
        public Image appleRottenStateImage;


        void Start()
        {
            if (apple == null)
                apple = GameObject.Find("Apple");

            currentAppleImage = apple.GetComponent<Image>();

            currentState = appleGrowingState;
            currentStateText.text = currentState.ToString();

            currentState.EnterState(this);

            InvokeRepeating("UpdatePerSeconds", 1.0f, 1.0f);
        }

        void UpdatePerSeconds()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(AppleBaseState state)
        {
            currentState = state;
            state.EnterState(this);
            currentStateText.text = currentState.ToString();
        }

        public void OnClickEnter()
        {
            currentState.OnClickEnter(this);
        }

        public void AppleInit()
        {
            currentAppleImage.sprite = appleWholeStateImage.sprite;
            apple.transform.localScale = Vector3.zero;
        }

        public void AppleGrowing()
        {
            Vector3 growthRate = new Vector3(0.1f, 0.1f, 0.1f);
            apple.transform.localScale += growthRate;
        }
    }
}
