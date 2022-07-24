using System.Collections;
using System.Collections.Generic;
using Articy.Unity;

//若游戏物体带有继承该接口的类，则该游戏物体可对话
public interface ITalkable
{
    public void RaiseConversation();
}
