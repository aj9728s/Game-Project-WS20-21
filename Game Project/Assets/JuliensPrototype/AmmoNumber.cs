using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoNumber : MonoBehaviour
{
    [SerializeField]
    private SOAmmoManager ammoManager;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = ammoManager.ammoAmount.ToString();
    }
}
