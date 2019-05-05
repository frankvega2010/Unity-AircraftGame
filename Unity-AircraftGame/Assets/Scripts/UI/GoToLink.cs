using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLink : MonoBehaviour
{
    public string URL;

    public void GoToThisLink()
    {
        Application.OpenURL(URL);
    }
}
