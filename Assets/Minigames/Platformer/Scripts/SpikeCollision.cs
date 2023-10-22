using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    public PlatformerLogic logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Spikes").GetComponent<PlatformerLogic>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
}
