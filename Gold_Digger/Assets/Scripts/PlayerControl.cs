using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public AudioClip gold;      // alt�n alma ses efekti
    public AudioClip fallDown;  // d��me ses efekti

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

            // hareketlerin daha yumu�ak ger�ekle�mesi i�in
            x *= Time.deltaTime * speed;
            y *= Time.deltaTime * speed;

            transform.Translate(x, 0f, y);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Gold"))        // alt�na �arparsa
        {
            GetComponent<AudioSource>().PlayOneShot(gold, 0.75f);   // ses gelsin
            gameControlScript.AddGold();                    // alt�n artar
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))  // d��mana �arparsa
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
