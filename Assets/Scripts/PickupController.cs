using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public List<GameObject> pickups;

    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

    public void PickedUp(GameObject gOBJ)
    {
        GameObject pickup = pickups.Find(x => x.Equals(gOBJ));
        if (pickup != null)
        {
            Vector3 newPos = new Vector3(
                Random.Range(-9, 9),
                (float)-2.7,
                Random.Range(-9, 9));
            pickup.transform.localPosition = newPos;
        }
        foreach (GameObject pick in pickups)
        {
            Color32 randomColor;
            int chooseColor = Random.Range(0, 3);

            if (chooseColor == 0)
            {
                randomColor = Color.red;
            }
            else if (chooseColor == 1)
            {
                randomColor = Color.green;
            }
            else
            {
                randomColor = Color.blue;
            }

            pick.transform.GetComponent<MeshRenderer>().material.color = randomColor;
        }
    }

    // Update is called once per frame
    void Randomize()
    {
        pickups = GameObject.FindGameObjectsWithTag("Pick Up").ToList();
        foreach (GameObject pickup in pickups)
        {
            Color32 randomColor;
            int chooseColor = Random.Range(0, 3);

            if (chooseColor == 0)
            {
                randomColor = Color.red;
            }
            else if (chooseColor == 1)
            {
                randomColor = Color.green;
            }
            else
            {
                randomColor = Color.blue;
            }

            pickup.transform.GetComponent<MeshRenderer>().material.color = randomColor;
            Vector3 newPos = new Vector3(
                Random.Range(-9, 9),
                (float)-2.7,
                Random.Range(-9, 9));
            pickup.transform.localPosition = newPos;
        }
    }

}
