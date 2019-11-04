using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Heart_Manager : MonoBehaviour
{
    private FloatVariable Data1;

    private FloatData Data2;

    //  float Data3 = 0f;

    public Flowchart Data4;

    public string nametest = null;
    private Slider slider;

    public float MaxHealth = 100;
    public float Nowhp = 0;
    public Image Handle;
    //public Texture[] Test1;
    public Image Fill;  // assign in the editor the "Fill"

    public Image Background;

    public Color MaxHealthColor = Color.red;
    public Color MinHealthColor = Color.black;
    public Color oldColor = Color.white;
    public Color bkColor = Color.blue;
    private float valueBuffer;
    private bool DrawFlage_plus = false;

    private bool DrawFlage_minuns = false;
    private bool BattleFlag = false;

    /**********************************************
     * 
     * 여기는 호감도를 관리하는 플레그 시작입니다
     *
     * *********************************************/

    private bool _main_F;

    private bool _square_F;

    private bool _forest_F;

    private bool Room_F;


    /**********************************************
 * 
 * 여기는 호감도를 관리하는 플레그 끝입니다
 *
 * *********************************************/



    private float subBuffer = 0f;

    private FloatData Fd;
    public Flowchart flowTest1;
    private float x = 1;

    public GameObject mainStreet;

    public GameObject square;

    public GameObject forest;

    public GameObject Room;

    private float valBuffer;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();

    }

    private void Start()
    {


        slider.wholeNumbers = true;        // I dont want 3.543 Health but 3 or 4

        slider.minValue = 0f;


        slider.maxValue = MaxHealth;


        //Nowhp =  mainStreet.GetComponent<Flowchart>().GetFloatVariable("HartPoint_main");


        Nowhp = 0;
        valueBuffer = Nowhp;

        slider.value = Nowhp;



    }


    private void Update()
    {
        /**********************************************
        * 
        * 여기는 호감도를 관리하는 플레그 시작입니다
        *
        * *********************************************/

        _main_F = mainStreet.GetComponent<Flowchart>().GetBooleanVariable("mainstreet_f");

        _square_F = square.GetComponent<Flowchart>().GetBooleanVariable("square_f");

        _forest_F = forest.GetComponent<Flowchart>().GetBooleanVariable("forest_f");



        BattleFlag = Room.GetComponent<Flowchart>().GetBooleanVariable("Battle_F");




        /**********************************************
        * 
        * 여기는 호감도를 관리하는 플레그 끝입니다
        *
        * *********************************************/

        #region 왕자 호감도 처리
        if (_square_F)
        {

         
            Debug.Log("스콰이어 처리");


            slider.value = square.GetComponent<Flowchart>().GetFloatVariable("prince_h");

            Debug.Log("Nowhp" + Nowhp);

            Debug.Log("초기 조건 Nowhp : slider.val" + slider.value);

            if ((Nowhp < slider.value) && (!DrawFlage_plus))
            {
                Debug.Log("증가식 조건");


                valueBuffer = Nowhp;

                subBuffer = slider.value;

                DrawFlage_plus = true;
            }

            if ((Nowhp > slider.value) && (!DrawFlage_minuns) && (!DrawFlage_plus))
            {
                Debug.Log("광장의 감소식이 실행되고있습니다");

                valueBuffer = Nowhp;

                Debug.Log(valueBuffer);

                subBuffer = slider.value;

                DrawFlage_minuns = true;
            }
        }
        #endregion

        #region 상인 호감도 처리
        if (_main_F)
        {

         

            Debug.Log("메인스트릿 처리");


            slider.value = mainStreet.GetComponent<Flowchart>().GetFloatVariable("dealer_h");

            Debug.Log("Nowhp" + Nowhp);

            Debug.Log("초기 조건 Nowhp : slider.val" + slider.value);

            if ((Nowhp < slider.value) && (!DrawFlage_plus))
            {
                valueBuffer = Nowhp;

                subBuffer = slider.value;

                DrawFlage_plus = true;
            }

            if ((Nowhp > slider.value) && (!DrawFlage_minuns) && (!DrawFlage_plus))
            {
                Debug.Log("번화가의 감소식이 실행되고있습니다");

                valueBuffer = Nowhp;

                Debug.Log(valueBuffer);

                subBuffer = slider.value;

                DrawFlage_minuns = true;
            }
        }
        #endregion

        #region 뱀파이어 호감도 처리
        if (_forest_F)
        {

        
            Debug.Log("숲 처리");


            slider.value = forest.GetComponent<Flowchart>().GetFloatVariable("vamfire_h");

            Debug.Log("Nowhp" + Nowhp);

            Debug.Log("초기 조건 Nowhp : slider.val" + slider.value);

            if ((Nowhp < slider.value) && (!DrawFlage_plus))
            {
                valueBuffer = Nowhp;

                subBuffer = slider.value;

                DrawFlage_plus = true;
            }

            if ((Nowhp > slider.value) && (!DrawFlage_minuns) && (!DrawFlage_plus))
            {
                Debug.Log("번화가의 감소식이 실행되고있습니다");

                valueBuffer = Nowhp;

                Debug.Log(valueBuffer);

                subBuffer = slider.value;

                DrawFlage_minuns = true;
            }
        }
        #endregion

        if (DrawFlage_plus)
        {
            UpdateHealthBar(valueBuffer);

            valueBuffer++;

            Debug.Log("증가하고있다");

            if (valueBuffer >= subBuffer)
            {
                valueBuffer = subBuffer;
                Debug.Log("증가점까지 도달했다");
                DrawFlage_plus = false;
                Nowhp = slider.value;
            }


        }

        if (DrawFlage_minuns)
        {
            UpdateHealthBar(valueBuffer);

            valueBuffer--;

            Debug.Log("증가하고있다");

            if (valueBuffer <= subBuffer)
            {
                valueBuffer = subBuffer;
                Debug.Log("감소점까지 도달했다");
                DrawFlage_minuns = false;
                Nowhp = slider.value;
            }



        }
        Debug.Log("배틀 플레그" + BattleFlag);
        if (BattleFlag)
        {
            Debug.Log("배틀 활성화");


            UpdateSucheBattle(x);
            x += 5;
            if (x >= 100)
            {
             //   Debug.Log("조건성립");
                BattleFlag = false;
                Room.GetComponent<Flowchart>().SetBooleanVariable("Battle_F", false);
            }
        }
        else
        {

            UpdateSucheBattle2(x);
            x += 5;
            if (x >= 100)
            {
             //   Debug.Log("조건성립");
                BattleFlag = false;
                Room.GetComponent<Flowchart>().SetBooleanVariable("Battle_F", false);
            }
        }



        //Room_F = Room.GetComponent<Flowchart>().GetBooleanVariable("Now");
        //Debug.Log($"조건성립{Room_F}  {Room.GetComponent<Flowchart>().GetBooleanVariable("Now")}");

        //if (Room_F)
        //{
        //    Debug.Log("호감도 초기화");
        //    Nowhp = 0;
        //    Room.GetComponent<Flowchart>().SetBooleanVariable("Now", false);
        //    Room_F = false;

        //    /*square.GetComponent<Flowchart>().SetBooleanVariable("square_f", false);

        //    mainStreet.GetComponent<Flowchart>().SetBooleanVariable("mainstreet_f", false);

        //    forest.GetComponent<Flowchart>().SetBooleanVariable("forest_f", false);
        //    */
        //    slider.value = 0;
        //}

    }

    void UpdateHealthBar(float cnt)
    {
        //호감도의 값은 빨간색이다.
        slider.value = cnt;


    }

    void UpdateSucheBattle(float cnt)
    {
        Debug.Log("플레그는 활성화었는가2");

        Background.color = Color.Lerp(MinHealthColor, bkColor, cnt / MaxHealth);

    }
    void UpdateSucheBattle2(float cnt)
    {
        Debug.Log("플레그는 활성화었는가2");

        Background.color = Color.Lerp(MinHealthColor, oldColor, cnt / MaxHealth);

    }
}
