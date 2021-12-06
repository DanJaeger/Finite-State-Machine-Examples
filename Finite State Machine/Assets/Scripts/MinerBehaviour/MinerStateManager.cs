using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MinerFSM { 
public class MinerStateManager : MonoBehaviour
{
    MinerBaseState currentState;
    public LocationType location;

    int goldInHand = 0;
    int moneyInBank = 0;
    int moneyLimit = 20;
    int thirst = 0;
    int fatigue = 0;

    [SerializeField] TextMeshProUGUI currentStateText;
    [SerializeField] TextMeshProUGUI locationText;
    [SerializeField] TextMeshProUGUI moneyInBankText;
    [SerializeField] TextMeshProUGUI goldInHandText;
    [SerializeField] TextMeshProUGUI thirstText;
    [SerializeField] TextMeshProUGUI fatigueText;
    [SerializeField] TextMeshProUGUI timeText;

    private void Start()
    {
        if(currentState == null)
            currentState = EnterMineAndDigForNugget.Instance;

        location = LocationType.Mine;

        InitText();

        InvokeRepeating("UpdatePerSecond", 1f, 1f);
    }
    void InitText()
    {
        currentStateText.text = "Current State: " + currentState.ToString();
        locationText.text = "Location: " + location.ToString();
        moneyInBankText.text = "Money in bank: " + moneyInBank.ToString();
        goldInHandText.text = "Gold in hand: " + goldInHand.ToString();
        thirstText.text = "Thirst:" + thirst.ToString();
        fatigueText.text = "Fatigue: " + fatigue.ToString();
        timeText.text = "Time: " + Time.time;
    }   
    void UpdatePerSecond()
    {
        currentState.UpdateState(this);
        UpdateTimer();
    }
    void UpdateTimer()
    {
        float time = Time.time;
        string minutes = ((int)time / 60).ToString();
        string seconds = ((int)time % 60).ToString();
        timeText.text = "Time: " + minutes + "." + seconds;
    }
    public void ChangeState(MinerBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);

        currentStateText.text = "Current State: " + currentState.ToString();
    }
    public void ChangeLocation(LocationType newLocation)
    {
        this.location = newLocation;
        locationText.text = "Location: " + location.ToString();
    }
    public void AddToGoldCarried()
    {
        ++goldInHand;
        goldInHandText.text = "Gold in hand: " + goldInHand.ToString();
    }
    public bool PocketsFull()
    {
        if (goldInHand >= 10)
            return true;
        else
            return false;
    }
    public void DepositGold()
    {
        moneyInBank += goldInHand;
        goldInHand = 0;

        moneyInBankText.text = "Money in bank: " + moneyInBank.ToString();
        goldInHandText.text = "Gold in hand: " + goldInHand.ToString();
    }
    public void IncreaseFatigue()
    {
        ++fatigue;
        fatigueText.text = "Fatigue: " + fatigue.ToString();
    }
    public void Rest()
    {
        fatigue = 0;
        fatigueText.text = "Fatigue: " + fatigue.ToString();
    }
    public void IncreaseThirst()
    {
        ++thirst;
        thirstText.text = "Thirst:" + thirst.ToString();
    }
    public void Drink()
    {
        thirst -= 4;
        thirstText.text = "Thirst:" + thirst.ToString();
    }
    public bool Thirsty()
    {
        if (thirst >= 12)
            return true;
        else
            return false;
    }
    public bool WealthyEnough()
    {
        if (moneyInBank >= moneyLimit)
        {
            moneyLimit += 15;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsFatigued()
    {
        if (fatigue >= 15)
            return true;
        else
            return false;
    }
    public bool ThirstQuenched()
    {
        if (thirst < 2)
            return true;
        else
            return false;
    }
}
}
