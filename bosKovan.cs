using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosKovan : MonoBehaviour
{
    AudioSource yereDusenKovan;

    private void Start()
    {

        yereDusenKovan = GetComponent<AudioSource>();
       StartCoroutine(mermiGecikmesi());

    }

    private void Update()
    {
        
    }
    IEnumerator mermiGecikmesi()
    {
        yield return new WaitForSeconds(1);
        yereDusenKovan.Play();
        Destroy(gameObject, 4f);
    }
}
