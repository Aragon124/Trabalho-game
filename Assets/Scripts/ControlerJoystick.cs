using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerJoystick : MonoBehaviour
{
    private Rigidbody2D _personagem;
    public float _velocidade = 15;
    public float _velocidadeDePulo = 5;
    private float horizontalMove;
    bool _estaNoChao;
    bool _podePuloDuplo;
    bool _virandoRosto = true; 
    public float delaySegundoPulo;
    bool moverEsquerda;
    bool moverDireita;
   
    void Start()
    {
       _personagem = GetComponent<Rigidbody2D>();  
       moverEsquerda = false;
       moverDireita = false;
    }

    //Método chamado quando o botão esquerdo é pressionado 
   
    public void PointerDownleft()
    {
        moverEsquerda = true;
        
    }
    //Método chamado quando o botão esquerdo é liberado  

    public void PointerUpleft()
    {
        moverEsquerda = false;
    }

        //Método chamado quando o botão direito é pressionado 
   
    public void PointerDownRight()
    {
        moverDireita = true;
        
    }
    //Método chamado quando o botão direito é liberado  

    public void PointerUpRight()
    {
        moverDireita = false;
    }

     void FixedUpdate()
    {
        horizontalMove = 0;

        if(moverEsquerda)
        {
            horizontalMove = -_velocidade;
        }

        if(moverDireita)
        {
            horizontalMove = _velocidade;
        }

        _personagem.velocity = new Vector2(horizontalMove, _personagem.velocity.y);

        if(_virandoRosto == false && horizontalMove > 0)
       {
          OlhandoParaOsLados();
       }
        else if(_virandoRosto == true && horizontalMove < 0)
       {
          OlhandoParaOsLados();
       }
    }

    void OlhandoParaOsLados()
    {
        _virandoRosto = !_virandoRosto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;   
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("chao"))
        {
            _estaNoChao = true;
            _podePuloDuplo = false;
        }
    }
    

    public void JumpButton()
    {
        if(_estaNoChao)
        {
        _estaNoChao = false;    
        _personagem.velocity = Vector2.up * _velocidadeDePulo; // aplica uma força para pulo
        Invoke("EnableDoubleJump", delaySegundoPulo);
        }
        else if(_podePuloDuplo)// verifica se o pulo é possível  
        {
            _personagem.velocity = Vector2.up * _velocidadeDePulo;
            _podePuloDuplo = false;      
        } 
    }

    void EnableDoubleJump()
    {
        _podePuloDuplo = false;
    }


}
