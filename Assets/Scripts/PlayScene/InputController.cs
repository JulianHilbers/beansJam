using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerControls playerControls;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerControls.IncreaseLane();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerControls.DecreaseLane();
        }
    }
}
