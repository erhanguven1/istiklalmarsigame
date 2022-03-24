using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordObject : MonoBehaviour
{
    public string word;
    public TextMeshPro wordMesh;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetWord(string _word)
    {
        word = _word;
        wordMesh.text = word;
    }
}
