using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 0.2f;
    public float moveRotation = 20;
    public PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (!photonView.IsMine)
                return;
            transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
            transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
        }
    }
}
