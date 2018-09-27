using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{

    void Enter(); //Initial 
    void Execute(); //Continually done
    void Exit(); //When it ends
	
}
