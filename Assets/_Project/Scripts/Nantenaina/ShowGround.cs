using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGround : MonoBehaviour
{
    //public GameObject cubePrefab;
    //public Piece[] all_piece;//SIZE = 8
    //public Line[] all_line;
    //public int gridSize = 3; 
    
    //void Start()
    //{
    //    all_piece = new Piece[9];
    //    all_line = new Line[8];

    //    GridFiller data = new GridFiller(all_piece, all_line);

    //    //float cubeSize = 1.0f; 
    //    float spacing = 3.1f; // Espacement entre les cube

    //    // Instancier les cubes et attacher les gestionnaires de clic
    //    for (int x = 0; x < gridSize; x++)
    //    {
    //        for (int y = 0; y < gridSize; y++)
    //        {
    //            Vector3 position = new Vector3(x * spacing, 0, y * spacing);
    //            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
    //            all_piece[x * gridSize + y] = new Piece { Cube = cube, Index = x * gridSize + y };

    //            // Ajouter un gestionnaire de clic pour chaque cube
    //            int pieceIndex = x * gridSize + y; // Capturer l'index de la pièce pour l'utiliser dans le gestionnaire de clic
    //            cube.AddComponent<BoxCollider>(); // Ajouter un collider pour permettre le clic
    //           //    cube.AddComponent<CubeClickHandler>().SetPieceIndex(pieceIndex);
    //        }
    //    }
    //}

    /*public void clicked()
    {
        GameManager gg = new GameManager();
        int indexRadom = gg.GenerateRandomIndex(all_piece);
        int valiny = gg.check_Game(all_line);

        print("Clicked valiny = "+valiny);
    }*/

}
