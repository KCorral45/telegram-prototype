public interface IEvent { }

public struct TestEvent : IEvent { }

public struct PlayerEvent : IEvent
{
    public int health;
    public int mana;
}

public struct MoneyEvent : IEvent
{
    public int amount;
}