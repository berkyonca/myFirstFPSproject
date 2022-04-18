using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tenekeSesi : MonoBehaviour
{
    respawnKonserve respawnScriptObje;
    public int objeNum;
    public int objePuan;
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("zemin"))
        {
            respawnScriptObje = GameObject.Find("script").GetComponent<respawnKonserve>();
            if (!respawnScriptObje.sureBitti && respawnScriptObje.antrenmanBasladý)
            {
                respawnScriptObje.puanDegeri += objePuan;
            }
            Instantiate(respawnScriptObje.tenekeObjesi[objeNum], respawnScriptObje.tenekeObjesi[objeNum].transform.position, respawnScriptObje.tenekeObjesi[Random.Range(0, respawnScriptObje.tenekeObjesi.Length)].transform.rotation);
            Destroy(gameObject);
        }


    }

}
