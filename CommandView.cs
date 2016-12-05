using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CommandView : MonoBehaviour
{
    private void Start()
    {
        Barbecuer boy = new Barbecuer();
        Guest guest_01 = new Guest(new BakeMuttonCommand(boy));
        Guest guest_02 = new Guest(new BakeMuttonCommand(boy));
        Guest guest_03 = new Guest(new BakeChickenWingCommand(boy));
        Waiter girlWaiter = new Waiter();
        girlWaiter.SetOrder(guest_01._command);
        girlWaiter.SetOrder(guest_02._command);
        girlWaiter.SetOrder(guest_03._command);
        girlWaiter.Notify();

        girlWaiter.CancelOrder(guest_01._command);
        girlWaiter.Notify();
    }
}

public class Guest
{
    public Command _command;
    public Guest(Command command)
    {
        _command = command;
    }
}

public class Waiter
{
    //    private Command _command;


    private readonly List<Command> _ordersList = new List<Command>();

    public void SetOrder(Command command)
    {
        if (command.ToString() == "BakeChickenWingCommand")
        {
            Debug.Log("服务员：鸡翅没有了，请点别的烧烤");
        }
        _ordersList.Add(command);
        //记录客户所点的烧烤日志，以备算账收钱


        Debug.Log(string.Format("增加订单：" + command + " 时间：" + DateTime.Now.ToString(CultureInfo.InvariantCulture)));
    }

    public void CancelOrder(Command command)
    {
        _ordersList.Remove(command);
        Debug.Log(string.Format("取消订单：" + command + " 时间：" + DateTime.Now.ToString(CultureInfo.InvariantCulture)));
    }

    public void Notify()
    {
        foreach (Command command in _ordersList)
        {
            command.ExcuteCommand();
        }
    }
}

/// <summary>


/// 命令抽象类


/// </summary>


public abstract class Command
{
    protected Barbecuer receiver;

    protected Command(Barbecuer barbecuer)
    {
        receiver = barbecuer;
    }

    /// <summary>


    /// 执行命令


    /// </summary>


    public abstract void ExcuteCommand();

    //    public override string ToString()


    //    {


    //        return string.Format("Receiver: {0}", receiver);


    //    }


}

/// <summary>


/// 烤羊肉命令


/// </summary>


public class BakeMuttonCommand : Command
{
    public BakeMuttonCommand(Barbecuer barbecuer)
        : base(barbecuer)
    {
    }

    /// <summary>


    /// 具体命令类，执行命令时，执行具体的行为


    /// </summary>


    public override void ExcuteCommand()
    {
        receiver.BakeMutton();
    }
}


/// <summary>


/// 烤鸡翅命令


/// </summary>


public class BakeChickenWingCommand : Command
{
    public BakeChickenWingCommand(Barbecuer barbecuer)
        : base(barbecuer)
    {
    }

    public override void ExcuteCommand()
    {
        receiver.BakeChickenWing();
    }
}

/// <summary>


/// 烤肉者类


/// </summary>


public class Barbecuer
{
    public void BakeMutton()
    {
        Debug.Log("烤羊肉串");
    }

    public void BakeChickenWing()
    {
        Debug.Log("烤鸡翅！");
    }
}