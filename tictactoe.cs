using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictactoe : MonoBehaviour
{
    GUIStyle myStyle;
    private int turn = 1; //用于记录棋子,1为O，2为X。 
    private int tic_num = 0; //井字棋盘中棋子数量 

    private int[,] matrix = new int[3,3]; //用于存储九宫格棋子信息 
    int middle = Screen.width / 2;  //确认屏幕中央位置
    
	//重新开始功能 
    void reset(){
        turn = 1;
        tic_num = 0; 
        for(int i = 0 ;  i < 3  ; i ++){
            for(int j = 0 ; j < 3 ; j ++)
                matrix[i,j] = 0;
        }  
        print("game reseted");
    }
    
    //交互：点击下棋 
    void click(int i, int j){
        matrix[i,j] = turn; //matrix[i,j]等于turn,通过turn值记录该位置的棋子是O还是X 
        tic_num ++; //每点击一下增加一颗总棋子数量 
        if(turn == 1) 
            turn = 2;
        else 
            turn = 1; //一方落下一颗棋子后，轮到另一方 
    }  
    
    //检测获胜条件 
    int check(){
        //检测列 
        for(int i =  0 ; i < 3 ; i ++){
            if(matrix[i,0] != 0 && (matrix[i,0] == matrix[i,1] && matrix[i,0] == matrix[i,2]) ){
                return matrix[i,0];
            }
		}    
		//检测行 
		for(int i =  0 ; i < 3 ; i ++){
            if(matrix[0,i] != 0 && (matrix[0,i] == matrix[1,i] && matrix[0,i] == matrix[2,i]) ){
                return matrix[0,i];
            } 
        }
        // 检测斜向 
        if(matrix[0,0] != 0 && (matrix[0,0] == matrix[1,1] && matrix[0,0] == matrix[2,2]) ){
            return matrix[0,0];
        }
        if(matrix[0,2] != 0 && (matrix[0,2] == matrix[1,1] && matrix[0,2] == matrix[2,0]) ){
            return matrix[0,2];
        }
        // 检测对局是否结束 
        if (tic_num < 9) return 0;
        // 检测平局 
        return 3;
    }
     
    //显示当前对局情况 
    void result(int res){
        if (res == 0) {
            if (turn == 1)
                GUI.Box(new Rect(middle - 50, 65, 100, 40), "O step");
            else 
                GUI.Box(new Rect(middle - 50, 65, 100, 40), "X step");
        } //对局未结束，显示是哪一方的行动回合 
        else if (res == 1) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "O WIN");
        } //对局结束且显示O胜利 
        else if (res == 2) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "X WIN");
        } //对局结束且显示X胜利 
        else if (res == 3) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "Draw");
        } //平局且显示结果 
    }
 
    void OnGUI(){
        // 游戏背景
        GUI.Box(new Rect(middle - 155, 30, 310, 480), "tictactoe");
        // 重新开始按钮
        if (GUI.Button(new Rect(middle - 50, 115, 100, 40), "Restart")){
            reset();
        }
       
        int res = check();
        for(int i = 0 ; i < 3 ; i ++){
            for(int j = 0 ; j < 3 ; j ++){
				if(matrix[i,j] == 1){
                    GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "O");
                } //matrix[i,j]值为1，则表示该位置下O棋子，在button中显示"O" 
                if(matrix[i,j] ==2){
                    GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "X");
                } //matrix[i,j]值为2，则表示该位置下X棋子，在button中显示"X" 
                if(GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "")){
                    click(i,j);
                } //点击按钮，则执行click()
            }
        }
        result(res);
    }
}

