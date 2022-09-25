using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictactoe : MonoBehaviour
{
    GUIStyle myStyle;
    private int turn = 1; //���ڼ�¼����,1ΪO��2ΪX�� 
    private int tic_num = 0; //������������������ 

    private int[,] matrix = new int[3,3]; //���ڴ洢�Ź���������Ϣ 
    int middle = Screen.width / 2;  //ȷ����Ļ����λ��
    
	//���¿�ʼ���� 
    void reset(){
        turn = 1;
        tic_num = 0; 
        for(int i = 0 ;  i < 3  ; i ++){
            for(int j = 0 ; j < 3 ; j ++)
                matrix[i,j] = 0;
        }  
        print("game reseted");
    }
    
    //������������� 
    void click(int i, int j){
        matrix[i,j] = turn; //matrix[i,j]����turn,ͨ��turnֵ��¼��λ�õ�������O����X 
        tic_num ++; //ÿ���һ������һ������������ 
        if(turn == 1) 
            turn = 2;
        else 
            turn = 1; //һ������һ�����Ӻ��ֵ���һ�� 
    }  
    
    //����ʤ���� 
    int check(){
        //����� 
        for(int i =  0 ; i < 3 ; i ++){
            if(matrix[i,0] != 0 && (matrix[i,0] == matrix[i,1] && matrix[i,0] == matrix[i,2]) ){
                return matrix[i,0];
            }
		}    
		//����� 
		for(int i =  0 ; i < 3 ; i ++){
            if(matrix[0,i] != 0 && (matrix[0,i] == matrix[1,i] && matrix[0,i] == matrix[2,i]) ){
                return matrix[0,i];
            } 
        }
        // ���б�� 
        if(matrix[0,0] != 0 && (matrix[0,0] == matrix[1,1] && matrix[0,0] == matrix[2,2]) ){
            return matrix[0,0];
        }
        if(matrix[0,2] != 0 && (matrix[0,2] == matrix[1,1] && matrix[0,2] == matrix[2,0]) ){
            return matrix[0,2];
        }
        // ���Ծ��Ƿ���� 
        if (tic_num < 9) return 0;
        // ���ƽ�� 
        return 3;
    }
     
    //��ʾ��ǰ�Ծ���� 
    void result(int res){
        if (res == 0) {
            if (turn == 1)
                GUI.Box(new Rect(middle - 50, 65, 100, 40), "O step");
            else 
                GUI.Box(new Rect(middle - 50, 65, 100, 40), "X step");
        } //�Ծ�δ��������ʾ����һ�����ж��غ� 
        else if (res == 1) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "O WIN");
        } //�Ծֽ�������ʾOʤ�� 
        else if (res == 2) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "X WIN");
        } //�Ծֽ�������ʾXʤ�� 
        else if (res == 3) {
            GUI.Box(new Rect(middle - 50, 65, 100, 40), "Draw");
        } //ƽ������ʾ��� 
    }
 
    void OnGUI(){
        // ��Ϸ����
        GUI.Box(new Rect(middle - 155, 30, 310, 480), "tictactoe");
        // ���¿�ʼ��ť
        if (GUI.Button(new Rect(middle - 50, 115, 100, 40), "Restart")){
            reset();
        }
       
        int res = check();
        for(int i = 0 ; i < 3 ; i ++){
            for(int j = 0 ; j < 3 ; j ++){
				if(matrix[i,j] == 1){
                    GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "O");
                } //matrix[i,j]ֵΪ1�����ʾ��λ����O���ӣ���button����ʾ"O" 
                if(matrix[i,j] ==2){
                    GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "X");
                } //matrix[i,j]ֵΪ2�����ʾ��λ����X���ӣ���button����ʾ"X" 
                if(GUI.Button(new Rect(middle - 150 + i*100, 165 + j*100 , 100, 100), "")){
                    click(i,j);
                } //�����ť����ִ��click()
            }
        }
        result(res);
    }
}

