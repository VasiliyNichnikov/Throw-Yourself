using System.Collections;
using UnityEngine;

public class Timer
{
    public bool IsLaunched => _isLaunched;
    
    private bool _isLaunched;
    
    public IEnumerator ToRun(float delay)
    {
        _isLaunched = true;
        while (delay > 0)
        {
            delay -= Time.deltaTime;
            yield return null;
        }
        _isLaunched = false;
    }
}