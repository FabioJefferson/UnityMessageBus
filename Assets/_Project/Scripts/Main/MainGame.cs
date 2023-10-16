using System;
using System.Threading.Tasks;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    private int _currentPosition = 0; // la position courante;
    private bool _shouldShowMatrix = false;
    private string[,] _mainMatrix = new string[,]
    {
         {"-", "-", "-"},
         {"-", "-", "-"},
         {"-", "-", "-"},
    };
    private bool _isWinning = false;


    // Start is called before the first frame update
    void Start()
    {
        SetPosition(2, 0); // On inverse les positions X et Y ici pour correspondre à la matrice.
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldShowMatrix)
        {
            Showmatrix();
        }
    }

    public void SetPosition( int posX, int posY )
    {
        _mainMatrix[posY, posX] = "X"; // On inverse les positions X et Y ici pour correspondre à la matrice.
        _currentPosition = posY;
        _shouldShowMatrix = true;
    }

    public void Showmatrix()
    {
        for (int i = 0 ; i < 3 ; i++)
        {
            for (int j = 0 ; j < 3 ; j++)
            {
                Debug.Log(_mainMatrix[i, j]);
            }
            Debug.Log("\n");
        }
        _shouldShowMatrix = false;
    }
    public  bool Check()
    {
        for(int i = 0 ; i<3 ; i++)
        {
             
        }
        return _isWinning;
    }

    public void SwitchPlayer()
    {

    }
    
}
