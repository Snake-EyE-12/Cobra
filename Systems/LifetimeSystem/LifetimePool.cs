using Cobra.DesignPattern;

public class LifetimePool : Lifetime, Poolable<LifetimePool>
{
    protected override void OnLifetimeEnd()
    {
        Pool.Release(this);
    }

    public ObjectPool<LifetimePool> Pool { get; set; }
    public void OnSummon()
    {
        this.gameObject.SetActive(true);
        StartLifetimeTimer();
    }

    public void OnRelease()
    {
        this.gameObject.SetActive(false);
    }
}