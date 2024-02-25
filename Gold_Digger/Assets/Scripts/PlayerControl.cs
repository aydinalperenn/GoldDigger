using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public AudioClip gold;      // altýn alma ses efekti
    public AudioClip fallDown;  // düþme ses efekti

    float x;
    float y;
    float speed = 10f;

    public GameControl gameControlScript;

    void Start()
    {
        
    }


    void Update()
    {
        if (gameControlScript.isGameContinue)       // oyun devam ediyorsa
        {
            x = Input.GetAxis("Horizontal");        // yatay eksen
            y = Input.GetAxis("Vertical");          // diken eksen

            // hareketlerin daha yumuþak gerçekleþmesi için
            x *= Time.deltaTime * speed;
            y *= Time.deltaTime * speed;

            transform.Translate(x, 0f, y);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Gold"))        // altýna çarparsa
        {
            GetComponent<AudioSource>().PlayOneShot(gold, 0.75f);   // ses gelsin
            gameControlScript.AddGold();                    // altýn artar
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))  // düþmana çarparsa
        {
            GetComponent<AudioSource>().PlayOneShot(fallDown, 0.75f);
            gameControlScript.isGameContinue = false;       // oyun biter
            StartCoroutine(Restart());

        }
    }

    private IEnumerator Restart()
    {
        Cursor.visible = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
