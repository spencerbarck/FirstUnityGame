using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarderObject : MonoBehaviour
{
    bool _hasPearl;

    float _destroyTimer;
    public void DestroyBoarder()
    {
        _hasPearl=true;

    }

    public void Update()
    {
        if(_hasPearl)
        {
            if(transform.position.y>2)
            {
                transform.position += new Vector3(0,Time.deltaTime*1f);
            }
            else if(transform.position.x<-20)
            {
                transform.position += new Vector3(Time.deltaTime*-1f,0);
            }
            else if(transform.position.x>20)
            {
                transform.position += new Vector3(Time.deltaTime*1f,0);
            }else
            {
                transform.position += new Vector3(0,Time.deltaTime*-1f);
            }

            _destroyTimer+=Time.deltaTime;
            if(_destroyTimer>3f) Destroy(this.gameObject);
        }
    }

}
