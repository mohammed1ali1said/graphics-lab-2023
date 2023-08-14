using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class gunbehaviour : MonoBehaviour
{
    public ParticleSystem ps;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public static float shots = 0;
    private TextMeshProUGUI shotstext;
    public TextMeshProUGUI shootingAccuracy;
    public TextMeshProUGUI Reloading;
    public TextMeshProUGUI bullets;
    public int magsize=0;
    public  int shotsfired = 0;
    public float reloadingtime=0;
    public static bool reloadflag;
    private bool stopshootingflag;
    public static int shotsfiredforresults;
    public static int hits=0;


    


    void Start() 
    {
        shotstext = GameObject.Find("shots").GetComponent<TextMeshProUGUI>();
        shootingAccuracy = GameObject.Find("Accuracy").GetComponent<TextMeshProUGUI>();
        shotstext.text = "shots: " + shots;
        
    }
    // Update is called once per frame
    void Update()
    {
        bullets.text = (magsize - shotsfired).ToString();
        if (Input.GetKeyUp(KeyCode.R) &&shotsfired>0) {
           
            reloadflag = true;
            reloadAsync();
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (shotsfired >= magsize)
            {
                reloadflag = true;
                shotsfired = 0;

            }
            if (!stopshootingflag)
            {
                Shoot();
            }
            else
            {
                Reloading.gameObject.SetActive(true);
            }
          
          
        }

    }
     async void Shoot()
    {
       
        int timer = (int)(reloadingtime * 1000);

        if (reloadflag)
        {
            stopshootingflag = true;
            await Task.Delay(timer);
            reloadflag = false;
            Reloading.gameObject.SetActive(false);
            
        }
        stopshootingflag = false;
        shots++;
        shotsfired++;
       

        ps.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward,out hit,range))
        {
            
           Target tar= hit.transform.GetComponent<Target>();
            if(tar!=null)
            {
               tar.TakeDamage(damage);
                hits++;
            }
        }
        shotstext.text = "shots: " + shots;
        string formattedNum = (hits/ (shots) * 100).ToString("F2");
        shootingAccuracy.text = "Accuracy:%  " + formattedNum;

        shotsfiredforresults = shotsfired;

    }
    async Task reloadAsync()
    {
        int timer = (int)(reloadingtime * 1000);
        stopshootingflag = true;
        await Task.Delay(timer);
        reloadflag = false;
        Reloading.gameObject.SetActive(false);
        stopshootingflag = false;
        shotsfired = 0;
    }


}
