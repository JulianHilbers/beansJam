using UnityEngine;

public class RandomizeSeed : MonoBehaviour
{
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }
}
