using UnityEngine;
using Core.Singleton;

public class GameManager : PersistentSingleton<GameManager>
{
    public int Money { get { return money; } }
    EventBinding<PlayerEvent> playerEventBinding;
    EventBinding<MoneyEvent> moneyEventBinding;
    private int money = 0;

    //private void OnEnable()
    //{
    //    playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
    //    EventBus<PlayerEvent>.Register(playerEventBinding);

    //    moneyEventBinding = new EventBinding<MoneyEvent>(HandleMoneyEvent);
    //    EventBus<MoneyEvent>.Register(moneyEventBinding);
    //}
    //private void OnDisable()
    //{
    //    EventBus<PlayerEvent>.Deregister(playerEventBinding);
    //    EventBus<MoneyEvent>.Deregister(moneyEventBinding);
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            EventBus<PlayerEvent>.Raise(new PlayerEvent { 
                health = 100,
                mana = 50
            });
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            EventBus<MoneyEvent>.Raise(new MoneyEvent
            { 
                amount = 100
            });
        }
    }

    public void IncreaseMoney(int amount = 1)
    {
        money++;
    }

    public void DecreaseMoney(int amount = 1)
    {
        money -= amount;
    }

    void HandlePlayerEvent(PlayerEvent playerEvent)
    {
        Debug.Log("Received Player Event");
    }

    void HandleMoneyEvent(MoneyEvent playerEvent)
    {
        Debug.Log("Handling Money Event");
    }
}
