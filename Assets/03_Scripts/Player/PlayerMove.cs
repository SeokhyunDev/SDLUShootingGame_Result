using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref = null;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float vSpeed = -0.25f;
    [SerializeField] private float maxPos = 5f;
    [SerializeField] private float minPos = -5f;
    [SerializeField] private float killPos = 0f;
    [SerializeField] private float coolTime = 3f;

    private SpriteRenderer spRenderer = null;
    private Rigidbody2D rb2d = null;
    private Animator animator = null;
    private Collider2D col = null;

    private void Start()
    {
        transform.position = new Vector3(-6.4f, 0, 0);

        col = GetComponent<Collider2D>();
        spRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StartCoroutine(Fire());
    }

    private void Update()
    {
        Move();
        rb2d.velocity = new Vector2(0, vSpeed);
        if(transform.position.y <= killPos)
        {
            // rb2d.velocity = new Vector2(0, 0);
            StartCoroutine(SceneChange());
        }
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Instantiate(bulletPref, transform.position, Quaternion.identity);
        // }
    }
    private void Move()
    {
        float verti = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(0, verti * speed * Time.deltaTime, 0));
        transform.position = new Vector3(-6.75f, Mathf.Clamp(transform.position.y, minPos, maxPos));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            StartCoroutine(BlankAndKill());
        }
    }
    private IEnumerator BlankAndKill()
    {
        col.enabled = false;
        speed = 0;
        animator.speed = 0f;
        rb2d.velocity = new Vector2(0, 0);
        minPos = killPos - 1f;
        for(int i = 0; i < 2; i++)
        {
            spRenderer.enabled = false;
            yield return new WaitForSeconds(0.25f);
            spRenderer.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(0.25f);

        while(transform.position.y >= killPos)
        {
            rb2d.velocity = Vector2.down * 10f;
            // if(transform.position.y <= killPos)
            // {
            //     rb2d.velocity = new Vector2(0, 0);
            //     Destroy(gameObject);
            // }
            yield return null;
        }
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < 4; i++)
                {
                    Instantiate(bulletPref, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(coolTime);
            }
            yield return null;
        }
    }
}

























































































































// 자살하고싶다