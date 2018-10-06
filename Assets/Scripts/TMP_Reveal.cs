using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMP_Reveal : MonoBehaviour {

    public TextMeshProUGUI textMesh;
    int counter = 0;
    int totalVisibleCharacters;

    private void Start()
    {
        textMesh.maxVisibleCharacters = 0;
    }

    private void Reveal()
    {
        int visibleCount = counter % (totalVisibleCharacters + 1);
        textMesh.maxVisibleCharacters = visibleCount;

        if(visibleCount < totalVisibleCharacters)
        {
            counter += 1;
            Invoke("Reveal", 0.05f);
        }
    }

    public void RevealText()
    {
        counter = 0;
        totalVisibleCharacters = textMesh.textInfo.characterCount;
        Reveal();
    }
}
