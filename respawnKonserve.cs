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
    public bool antrenmanBaslad�;


    private void Update()
    {
        puanText.text = "Puan�n�z =" + puanDegeri;
        kalanSureText.text = "Kalan S�reniz =" + (int)kalanSure;

        if (antrenmanBaslad� && kalanSure >= 1)
        {
            kalanSure -= Time.deltaTime;

        }
        else if(kalanSure < 1)
        {
            sureBitti = true;
            kalanSureText.text = "S�RE B�TT�" ;
            if (puanDegeri < 177)
            {
                puanText.text = "PUANINIZ = " +
                    "" + puanDegeri + "Geli�tirici Rekoru 177 :) Kendini biraz daha geli�tirmen laz�m.";
            }
            else if (puanDegeri == 177)
            {
                puanText.text = "PUANINIZ = " +
                    "" + puanDegeri + "Vay be! Geli�tirici Rekoruna eri�tin. Biraz daha �al���rsan Rekor'u egale bile edebilirsin :)";
            }
            else if (puanDegeri >= 177)
            {
                puanText.text = "OHAAAAAA! Geli�tirici Rekorunu(177) " + (puanDegeri - 177) + "fark ile ge�ip " + puanDegeri + " puan�na ula�t�n. Sen ger�ek bir John Wick'sin :)" ;
            }
            
            antrenmanBaslad� = false;
        }
    }
}
