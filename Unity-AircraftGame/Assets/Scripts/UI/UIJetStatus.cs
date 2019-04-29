using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJetStatus : MonoBehaviour
{
    public Text altitudeText;
    public Text speedText;

    private JetStatus jet;
    // Start is called before the first frame update
    void Start()
    {
        jet = JetStatus.Get();
    }

    // Update is called once per frame
    void Update()
    {
        altitudeText.text = "Altitude: " + jet.altitude.ToString("f1");
        speedText.text = "Speed: " + jet.speed.ToString("f1");
    }
}
