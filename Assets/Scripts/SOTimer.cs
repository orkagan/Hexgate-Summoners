using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variable;

public class SOTimer : MonoBehaviour
{
    public Float time;
    public bool isCountDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountDown)
        {
            if (time.Value > 0)
            {
                time.Value = Mathf.Clamp(time.Value - Time.deltaTime, 0, Mathf.Infinity);
            }
        }
        else
        {
            time.Value += Time.deltaTime;
        }
    }
}
