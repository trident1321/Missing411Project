using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform playerCamArm;
    [SerializeField]
    private float throwForce;
    //[SerializeField]
    //private AudioClip[] soundToPlay;
    //[SerializeField]
    //private int dmg;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    //private AudioSource audio;
    private bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if(dist <= 4f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if(hasPlayer && Input.GetButtonDown("Use")) // optimization: check "use" button first and return if not pressed
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCamArm;
            transform.position = transform.parent.position;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCamArm.forward * throwForce);
                //RandomAudio();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    //private void RandomAudio()
    //{
    //    if (audio.isPlaying)
    //    {
    //        return;
    //    }
    //    audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
    //    audio.Play();
    //}

    private void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
