using UnityEngine;

public class SoundChapter1 : MonoBehaviour
{
    public AudioSource door;
    public float doorTime;

    private void OnEnable()
    {
        door.PlayDelayed(doorTime);
    }
}
