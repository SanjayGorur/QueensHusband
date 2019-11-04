using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using Fungus;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    // Start is called before the first frame update


    //호감도 최대값
    public float player_MaxHart = 100;

    /**********************************************************
      현재 호감도 초기값을 설정해버리면 스크립트를 불러올때마다
      0이 되어버리기에 우선 변수만 설정
    ************************************************************/

    // 타겟의 호감도

    public float player_NowHart;
    public Slider sliderHart;
    public SetSliderValue what;

    //public Flowchart flowchart;


    /*************************************************
    문제 저 SetHartPoint value 매개값을 
    flochart에서의 Variables float_point 변수를 참조해야된다!.
    *************************************************/



    void Start()
    {


        

        sliderHart.maxValue = player_MaxHart;
        //이런식의 사용이 필요.
        //SetHartPoint(flowchart->point) 
        SetHartPoint(player_NowHart);


    }
   

    public void SetHartPoint(float value)
    {
       
        player_NowHart = value;
        sliderHart.value = player_NowHart;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
