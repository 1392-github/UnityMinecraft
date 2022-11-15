using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenRNG : MonoBehaviour
{
    public int? seed = null;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetSeed(int seed)
    {
        Random.InitState(seed);
        Debug.Log($"Seed - {seed}");
        this.seed = seed;
    }
    public int IntRandom(int min, int max)
    {
        return Random.Range(min, max);
    }
}