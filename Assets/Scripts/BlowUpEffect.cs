using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
