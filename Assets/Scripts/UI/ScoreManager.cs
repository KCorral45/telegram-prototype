using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    EventBinding<MoneyEvent> moneyEventBinding;
    private int score = 0;

    private void OnEnable()
    {
        moneyEventBinding = new EventBinding<MoneyEvent>(HandleMoneyEvent);
        EventBus<MoneyEvent>.Register(moneyEventBinding);
    }

    private void OnDisable()
    {
        EventBus<MoneyEvent>.Deregister(moneyEventBinding);
    }
    
    private void HandleMoneyEvent(MoneyEvent moneyEvent)
    {
        score += moneyEvent.amount;
        scoreText.text = score.ToString();
    }
}
