using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private bool canMove;

    private Animator anim;

    public GameObject prebab,mao;

    void Start()
    {
        canMove = true;
        speed = 3f;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Shoot();
        Jump();
    }

    void Move()
    {
        //Criar as variaveis do teclado
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Setar os valores no Animator
        anim.SetFloat("x",x);
        anim.SetFloat("y",y);
        anim.SetInteger("x(int)",(int)x);

        //Verificar a direcao do player
        if(x<0)
        {    
            transform.eulerAngles = new Vector2(0,180);
            if(canMove){
                // mover 
                transform.Translate(new Vector2(Time.deltaTime*speed,0)); 
            }    
        }
        else if(x>0)
        {
            transform.eulerAngles = new Vector2(0,0);
            if(canMove){
                // mover
                transform.Translate(new Vector2(Time.deltaTime*speed,0)); 
            }
        }
        else
        {
           
        }
        
        
    }
    void Shoot()
    {
        
        if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("duckIdle",true);
            canMove = false;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("duckIdle",false);
            canMove = true;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            canMove = false;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            canMove = true;
        }
        if(Input.GetKey(KeyCode.O))
        {
            anim.SetBool("shoot",true);
        }
        if(Input.GetKeyUp(KeyCode.O))
        {
            anim.SetBool("shoot",false);
        }
    }

    public void InstBullet(float z)
    {
         
    
        prebab.transform.eulerAngles = new Vector3(0,this.transform.rotation.y,z);
        Instantiate(prebab,mao.transform.position,this.transform.rotation);
       
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,300f));
        }
    }

}
