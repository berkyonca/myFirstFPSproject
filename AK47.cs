using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AK47 : MonoBehaviour
{
    Animator animatorum;

    [Header("SESLER")]
    public AudioSource AtesSesi;
    public AudioSource SarjorDegis;
    public AudioSource BosSarjor;
    public AudioSource MermiKutusuSesi;
    public AudioSource MermiKutusuSpawnSesi;

    [Header("AYARLAR")]
    public bool atesEdebilirmi;
    public float DisaridanAtesEtmeSikligi;
    float IceridenAtesEtmeSikligi;
    public float menzil;

    [Header("EFEKTLER")]
    public ParticleSystem AtesEfekt;
    public ParticleSystem MermiIzi;
    public ParticleSystem KanIzi;

    [Header("SÝLAH AYARLARI")]
    public int ToplamMermiKapasitesi;
    public int KalanMermi;
    public int SarjorKapasitesi;
    public TextMeshProUGUI KalanMermi_Text;
    public TextMeshProUGUI ToplamMermi_Text;

    public bool Kovan_CiksinMi = true;
    public GameObject kovanNesnesi;
    public GameObject kovan_cikis_noktasi;

    [Header("DÝÐERLERÝ")]
    public Camera benimCam;
    public GameObject mermiKutusuObjesi;

    private void Start()
    {
        animatorum = GetComponent<Animator>();
        KalanMermi_Text.text = KalanMermi.ToString();
        ToplamMermi_Text.text = ToplamMermiKapasitesi.ToString(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && KalanMermi == 0)
        {
                BosSarjor.Play();
        }
        KalanMermi_Text.text = KalanMermi.ToString();
        ToplamMermi_Text.text = ToplamMermiKapasitesi.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0) && atesEdebilirmi && Time.time > IceridenAtesEtmeSikligi && KalanMermi >= 1)
        {
            AtesEt();
            IceridenAtesEtmeSikligi = Time.time + DisaridanAtesEtmeSikligi;
        }
            if (Input.GetKeyDown(KeyCode.R) && ToplamMermiKapasitesi >=1 && KalanMermi != 30)
        {
            animatorum.Play("sarjorDegis");
        }

            if (Input.GetKeyDown(KeyCode.E))
        {
            MermiAl();

        }

        void SarjorSesi()
        {
            SarjorDegis.Play();
        }


            void MermiDegis()
        {
            if (ToplamMermiKapasitesi >= 30)
            {
                ToplamMermiKapasitesi = ToplamMermiKapasitesi - Mathf.Abs(KalanMermi - 30);
                KalanMermi = 30;
            }
            else if (ToplamMermiKapasitesi < 30 && (ToplamMermiKapasitesi + KalanMermi <= 30))
            {
                KalanMermi = ToplamMermiKapasitesi + KalanMermi;
                ToplamMermiKapasitesi = 0;
            }
            else if (ToplamMermiKapasitesi < 30 && (ToplamMermiKapasitesi + KalanMermi > 30))
            {
                ToplamMermiKapasitesi = Mathf.Abs( (30 - KalanMermi) - ToplamMermiKapasitesi);
                KalanMermi = 30;
            }




        }
        void AtesEt()
        {
            if(Kovan_CiksinMi)
            {
                GameObject obje = Instantiate(kovanNesnesi, kovan_cikis_noktasi.transform.position, kovan_cikis_noktasi.transform.rotation);
                Rigidbody rb = obje.GetComponent<Rigidbody>();
                rb.AddRelativeForce(new Vector3(-10f, 1, 0) * 60);

            }


            RaycastHit hit;
            AtesEfekt.Play();
            AtesSesi.Play();

            KalanMermi--;
            animatorum.Play("atesETT");
            if (Physics.Raycast(benimCam.transform.position, benimCam.transform.forward, out hit, menzil))
            {
                Debug.Log(hit.transform.name);
            }
            Instantiate(MermiIzi, hit.point, Quaternion.LookRotation(hit.normal));

            if(hit.transform.gameObject.CompareTag("Dusman"))
            {

                Instantiate(KanIzi, hit.point, Quaternion.LookRotation(hit.normal));

            }
            else if (hit.transform.gameObject.CompareTag("Devrilebilir"))
            {
                Rigidbody devrilebilirRb = hit.transform.gameObject.GetComponent<Rigidbody>();
                devrilebilirRb.AddForce(-hit.normal * 50f);
                         
                tenekeSesi tenekeyePuan = GameObject.FindGameObjectWithTag("Devrilebilir").GetComponent<tenekeSesi>();
                

            }
        }
    }

    
    void MermiAl()
    {

        RaycastHit hit;

        if (Physics.Raycast(benimCam.transform.position, benimCam.transform.forward, out hit, menzil))
        {
            if (hit.transform.gameObject.CompareTag("mermiKutusu"))
            {
                MermiKutusuSesi.Play();
                ToplamMermiKapasitesi += 30;
                StartCoroutine(mermiKutusuSpawner());
                Destroy(hit.transform.gameObject);
            }
        }


    }
 
     IEnumerator mermiKutusuSpawner()
     {
         yield return new WaitForSeconds(6);
         MermiKutusuSpawnSesi.Play();
         Instantiate(mermiKutusuObjesi, mermiKutusuObjesi.transform.position, mermiKutusuObjesi.transform.rotation);
     } 
}
