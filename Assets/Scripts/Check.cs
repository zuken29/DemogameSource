using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    private int point = 0;
    public PlayerController player;

    //public TextMeshProUGUI pointText;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void AddPoint(PlayerController Player, int addedpoint)
    {
        point += 1;
    }
    
    void SetCountText()
    {

    }
}
