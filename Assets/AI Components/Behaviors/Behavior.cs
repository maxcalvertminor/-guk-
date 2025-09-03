

public class Behavior
{
    public EnemyBehavior script;
    public float priority;
    public Behavior(EnemyBehavior s) {
        script = s;
    }

    public virtual void Accumulate() {

    }
    public virtual void Queue() {

    }
}