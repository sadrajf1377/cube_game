using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class movement : MonoBehaviour
{
    // Start is called before the first frame update
   public float speed;
    [SerializeField] Vector3 mouseposition;
    float speedx;
    [SerializeField] GameObject brokenglass;
    [SerializeField] TextMeshProUGUI scoretxt;
    float score;
    public int multiplier;
    public int vcount;
    float accy;
    [SerializeField] Animator canavas;
    // Update is called once per frame
    private void Start()
    {
        accy = Input.acceleration.y;
    }
    void Update()
    {
       speed +=speed<=30?Time.deltaTime*0.5f:0;
        score += 0.995f * Time.deltaTime;
        scoretxt.text = score.ToString().Remove(new List<char>(score.ToString()).FindIndex(x=>x=='/')+1)+"   X"+(multiplier).ToString();
        jump();
 
        GetComponent<Rigidbody>().velocity= new Vector3(Input.acceleration.x*4, 0, speed)+new Vector3(0, GetComponent<Rigidbody>().velocity.y,0);
        QualitySettings.vSyncCount = vcount;
     
    }
    IEnumerator rotate(int l)
    {
        switch (l)
        {
            case -1:
                {
                    for (int j = 0; j < 10; j++)
                    {
                        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -3.5f);
                        yield return new WaitForSeconds(0.005f);
                    }
                }
                break;

            case 1:
                {
                    for (int j = 0; j < 10; j++)
                    {
                        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 3.5f);
                        yield return new WaitForSeconds(0.005f);
                    }
                }
                break;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer!=8)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
            Camera.main.GetComponent<camfollow>().enabled = false;
            Camera.main.GetComponent<Rigidbody>().velocity =Vector3.zero;
            Instantiate(brokenglass, transform.position, transform.rotation);
            if(score>PlayerPrefs.GetFloat("score"))
            {
                PlayerPrefs.SetFloat("score", score);
            }
            canavas.SetTrigger("open_replay_panel");
            Destroy(gameObject);
           
           
        }
    }
    void jump()
    {
        if(accy- Input.acceleration.y>=0.1f&&GetComponent<Rigidbody>().velocity.y==0)
        {
            GetComponent<Rigidbody>().AddForce(0,300, 0);
        }
        accy = Input.acceleration.y;
    }
}
