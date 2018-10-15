using UnityEngine;

public class PowerUp : Spawnable
{
    private float coolDown = 0f;

    public void OnHit()
    {
        GetComponent<Animator>().SetTrigger("BottleBreak");
    }

    public override void ReSpawn(int lane)
    {
        GetComponent<Animator>().SetTrigger("BottleReset");
        coolDown = Time.time + Random.Range(5, 15);
        base.ReSpawn(lane);
    }

    public bool CooledDown()
    {
        return coolDown > Time.time;
    }

}
