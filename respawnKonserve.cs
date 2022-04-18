using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class respawnKonserve : MonoBehaviour
{
    public TextMeshPro puanText;
    public TextMeshPro kalanSureText;

    public AudioSource tenekeSesi;
    public GameObject[] tenekeObjesi;

    public int puanDegeri;
    public float kalanSure = 11;
    public bool sureBitti = false;
    public bool antrenmanBasladý;


    private void Update()
    {
        puanText.text = "Puanýnýz =" + puanDegeri;
        kalanSureText.text = "Kalan Süreniz =" + (int)kalanSure;

        if (antrenmanBasladý && kalanSure >= 1)
        {
            kalanSure -= Time.deltaTime;

        }
        else if(kalanSure < 1)
        {
            sureBitti = true;
            kalanSureText.text = "SÜRE BÝTTÝ" ;
            if (puanDegeri < 177)
            {
                puanText.text = "PUANINIZ = " +
                    "" + puanDegeri + "Geliþtirici Rekoru 177 :) Kendini biraz daha geliþtirmen lazým.";
            }
            else if (puanDegeri == 177)
            {
                puanText.text = "PUANINIZ = " +
                    "" + puanDegeri + "Vay be! Geliþtirici Rekoruna eriþtin. Biraz daha çalýþýrsan Rekor'u egale bile edebilirsin :)";
            }
            else if (puanDegeri >= 177)
            {
                puanText.text = "OHAAAAAA! Geliþtirici Rekorunu(177) " + (puanDegeri - 177) + "fark ile geçip " + puanDegeri + " puanýna ulaþtýn. Sen gerçek bir John Wick'sin :)" ;
            }
            
            antrenmanBasladý = false;
        }
    }
}
