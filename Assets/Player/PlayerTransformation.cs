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
        humanForm = transform.Find("HumanCapsule").gameObject;
        creatureForm = transform.Find("CreatureCapsule").gameObject;
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
