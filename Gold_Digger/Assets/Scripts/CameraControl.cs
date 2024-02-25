using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameControl gameControlScript;

    float sensibility = 3f;     // hassasiyet
    float softness = 2f;        // yumu�akl�k

    Vector2 switchPosition;     // ge�i� pozisyonu
    Vector2 camPosition;        // kamera pozisyonu

    GameObject playerObj;

    void Start()
    {
        playerObj = transform.parent.gameObject;
        camPosition.y = 6f;
    }


    void Update()
    {
        if (gameControlScript.isGameContinue)       // oyun devam ediyorsa
        {
            Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // daha ger�e�e yak�n hareket i�in
            mousePos = Vector2.Scale(mousePos, new Vector2(softness * sensibility, softness * sensibility));
            switchPosition.x = Mathf.Lerp(switchPosition.x, mousePos.x, 1f / softness);
            switchPosition.y = Mathf.Lerp(switchPosition.y, mousePos.y, 1f / softness);

            camPosition += switchPosition;
            if(camPosition.y > 85)
            {
                camPosition.y = 85;
            }
            else if(camPosition.y < -75)
            {
                camPosition.y = -75;
            }

            transform.localRotation = Quaternion.AngleAxis(-camPosition.y, Vector3.right);   // sa�daki vector 3 k�sm� �u �ekilde: kameraya yatay do�rultuda bir �i� saplay�p ekseninde d�nd�r�yor
            playerObj.transform.localRotation = Quaternion.AngleAxis(camPosition.x, playerObj.transform.up);    // oyuncuya dikey do�rultuda bir �i� saplay�p yatay do�rultuda d�nd�r�yor
        }
    }
}
