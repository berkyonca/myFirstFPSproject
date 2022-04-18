using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jukeBox : MonoBehaviour
{

    public AudioSource audiom;
    public Camera benimCameram;
    public bool musicAcik = true;
    public GameObject musicAciktext;
    public GameObject musicKapalitext;

    private void Start()
    {
        audiom.Play();
    }
    private void Update()
    {
        if (musicAcik)
        {
            musicAciktext.SetActive(true);
            musicKapalitext.SetActive(false);
        }
        else if (!musicAcik)
        {
            audiom.Play();
            musicAciktext.SetActive(false);
            musicKapalitext.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            musicCal();
        }
    }
    

    void musicCal()
    {
        RaycastHit hit1;
        if (Physics.Raycast(benimCameram.transform.position, benimCameram.transform.forward, out hit1, 2))
        {
            musicAcik = !musicAcik;
        }
    }
}
