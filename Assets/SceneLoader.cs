using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public TextMeshProUGUI results;

    private void Start()
    {
      
    }

    private void Update()
    {

        int shots = gunbehaviour.shotsfiredforresults;
        float hits = Target.respawnCounter;
        float accuracy = shots / hits;
        float Time = Target.avgTimeForResults;
        if (accuracy >= 0.75)
        {
            if (Time > 1.5)
            {
                results.text = "Your aim is superb but unfourtunatly you need to improve time to hit ";
            }
            else if (Time < 1.5 && Time > 1)
            {
                results.text = "you have almost perfect aim and you time is nice but you still can improve your time";
            }
            else
            {
                results.text = "good aim and time is something worth admiring but if you are not playing on superhard mode there is still room for improvment";
            }

        }
        else if (accuracy < 0.75 && accuracy > 0.5)
        {
            if (Time > 1.5)
            {
                results.text = "good aim but working on time is more important ";
            }
            else if (Time < 1.5 && Time > 1)
            {
                results.text = "nice aim and time but both can be improved ";
            }
            else
            {
                results.text = "you have extraordinary reaction time but your aim isn't as good work on it!";
            }

        }
        else if (accuracy > 0.25 && accuracy < 0.5)
        {
            if (Time > 1.5)
            {
                results.text = "neither aim nor time is good but at least you hit some targets";
            }
            else if (Time < 1.5 && Time > 1)
            {
                results.text = "time is slightly above average yet aim needs much improvment ";
            }
            else
            {
                results.text = "time is actually great bravo but aimwise still a long way to go ";
            }

        }
        else if (accuracy < 0.25)
        {
            if (Time > 1.5)
            {
                results.text = "my grandma have one eye and she shoots better what is taking you so long if you are missing ";
            }
            else if (Time < 1.5 && Time > 1)
            {
                results.text = "ok you have good time but aim is way worse you will need to work on that a lot ";
            }
            else
            {
                results.text = "your fast reaction is good but still means nothing if you are missing that many shots";
            }

        }

    }
}
