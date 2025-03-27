using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPlayer : MonoBehaviour
{
    private Rigidbody2D _personagem;
    public float _velocidade; 
    public float _Pulo;
    bool _estaNoChao;
    bool _virandoRosto = true; 
    
    void Start()
    {
        _personagem = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       FixedUpdate();
       Jump(); 
    }

    void FixedUpdate() 
    {
       float _moveInput = Input.GetAxis("Horizontal");
       _personagem.velocity = new Vector2(_moveInput * _velocidade, _personagem.velocity.y);

       if(_virandoRosto == false && _moveInput > 0)
       {
          OlhandoParaOsLados();
       }
       else if(_virandoRosto == true && _moveInput < 0)
       {
          OlhandoParaOsLados();
       }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(_estaNoChao)
            {
              _estaNoChao = false;
              _personagem.AddForce(new Vector2(0f, _Pulo), ForceMode2D.Impulse);
            }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("chao"))
        {
            _estaNoChao = true;
        }
    }

    void OlhandoParaOsLados()
    {
        _virandoRosto = !_virandoRosto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
