using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] public float aggroRadius = 20f;
    [SerializeField] public float stoppingDistance = 10f;

    public static float AggroRadius => Instance.aggroRadius;
    public static float StoppingDistance => Instance.stoppingDistance;

    public static GameSettings Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
