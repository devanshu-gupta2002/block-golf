using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    bool ready;
    public Vector2 minPower;
    public Vector2 maxpower;
    public float maxSpeedForGoal = 0.1f;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    GameObject targetGoal;
    public GameObject GoalTest;
    public Transform[] holes;
    int holeNum ;
   
    void Start()
    {
        cam = Camera.main;
       ;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.13f)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }
       
        if (ready)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15f;


            }
            if (Input.GetMouseButton(0))
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15f;
               
            }
            if (Input.GetMouseButtonUp(0))
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15f;
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxpower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxpower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Hole" && this.GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeedForGoal)
        {
            
           
            this.GetComponent<Rigidbody2D>().transform.position = obj.transform.position;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
             StartCoroutine(Goal(obj.gameObject));
        }
    }
IEnumerator Goal(GameObject target)
	{
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ready = false;
        targetGoal = target;
        yield return new WaitForSeconds(2.0f);
		if ( holeNum != holes.Length -1)
		{
            holeNum++;
            ready = true;
           
            this.transform.position = holes[holeNum].transform.position;
		}
        else
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
	}
}
