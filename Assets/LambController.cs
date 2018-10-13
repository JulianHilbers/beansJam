﻿using UnityEngine;

public class LambController : MonoBehaviour
{
    public float moveSteps = 1f;
    public float failPosition = -3.5f;

    [Header("Scene")]
    public GameStats stats;
    public string sceneName;
    public SceneLoader SceneLoader;

    private Rigidbody2D rBody;
    private float initialY;

    private void Start()
    {
        initialY = transform.position.y;
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForFail();
    }

    public void MoveUp()
    {
        rBody.AddForce(Vector2.up * moveSteps);
    }

    public void MoveDown()
    {
        if (transform.position.y >= initialY)
            rBody.AddForce(Vector2.down * moveSteps);
    }

    private void CheckForFail()
    {
        if (transform.position.y > failPosition)
        {
            SceneLoader.LoadScene(sceneName);
            stats.SetNewHighScore(stats.GetCurrentScore());
        }
    }
}
