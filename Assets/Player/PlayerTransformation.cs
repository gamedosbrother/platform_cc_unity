using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTransformation : MonoBehaviour
{

    private GameObject humanForm;
    private GameObject creatureForm;

    void Awake()
    {
        humanForm = GameObject.Find("HumanCapsule");
        creatureForm = GameObject.Find("CreatureCapsule");
        humanForm.SetActive(true);
        creatureForm.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            humanForm.SetActive(false);
            creatureForm.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            humanForm.SetActive(true);
            creatureForm.SetActive(false);
        }
    }



}
