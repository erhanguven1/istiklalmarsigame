using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Word")
        {
            photonView.RPC("DestroyRPC", RpcTarget.All, WordsGenerator.instance.wordsList.IndexOf(other.gameObject));
            other.gameObject.SetActive(false);
            score++;
        }
    }

    private void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }

    [PunRPC]
    void DestroyRPC(int index)
    {
        WordsGenerator.instance.wordsList[index].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine || PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            return;
        }

        transform.position += Vector3.forward * Time.deltaTime * 5;

        transform.position += Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * 5;
    }

    private void OnGUI()
    {
        if (photonView.IsMine)
        {
            GUI.skin.label.fontSize = 30;
            GUI.color = Color.red;
            GUILayout.Label("Millilik seviyesi: " + score.ToString());
        }
    }
}
