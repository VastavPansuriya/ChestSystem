

using UnityEngine;

public class ProgressState<T> : IState where T : ChestController
{
    public ChestController Owner { get; set; }


    private ChestDataSO currData;
    private float currRemainingTime = 0;
    public void OnStateEnter()
    {
        currData = Owner.GetChestDataSO();
        currRemainingTime = currData.time;
    }

    public void OnStateExit()
    {
        currData = null;
        currRemainingTime = 0;
    }

    public void Update()
    {
        currRemainingTime -= Time.deltaTime;
        Owner.SetReaminingTime(currRemainingTime);
        Owner.SetInfo(FormatTime(currRemainingTime));

        if (currRemainingTime <= 0)
        {
            Owner.OnProgressComplete();
        }
    }

    public string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        if (minutes > 0)
        {
            return string.Format("{0}:{1:D2}s", minutes, seconds);
        }
        else
        {
            return string.Format("{0}.{1:D2}s", minutes, seconds);
        }
    }
}
