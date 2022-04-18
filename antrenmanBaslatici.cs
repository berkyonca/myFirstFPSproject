using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antrenmanBaslatici : MonoBehaviour
{
   // respawnKonserve respawnScriptErisim;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Camera cameram = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();

            RaycastHit hit2;

            if (Physics.Raycast(cameram.transform.position, cameram.transform.forward, out hit2, 1.3f))
            {
                GameObject.Find("script").GetComponent<respawnKonserve>().antrenmanBasladý = true;
                GameObject.Find("script").GetComponent<respawnKonserve>().kalanSure = 11;
                GameObject.Find("script").GetComponent<respawnKonserve>().puanDegeri = 0;
                GameObject.Find("script").GetComponent<respawnKonserve>().sureBitti = false;
                GameObject.Find("script").GetComponent<AudioSource>().Play();
            }
        }

    }
  
}
