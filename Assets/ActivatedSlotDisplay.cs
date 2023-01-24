using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedSlotDisplay : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Capsule").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(-317.6f + playerController.SelectedSlot * 79.875f, 44, 0);
    }
}
