using UnityEngine;
using System.IO;

public class LineHandler
{
    float _distance,
           _angle;

    public float Distance
    {
        get
        {
            return _distance;
        }
    }
    public float Angle
    {
        get
        {
            return _angle;
        }
    }
    public LineHandler()
    {

    }
    public bool InsertLine(string line)
    {
        _distance = float.Parse(line.Split(':')[1]);
        _angle = float.Parse(line.Split(':')[0]);
        Debug.LogFormat("Distance: {0}\nAngle: {1}\n== {2}",_distance,_angle, (_distance == 1 || _distance == 0) && (_angle == 1 || _angle == 0));
        return (_distance == 1 || _distance == 0) && (_angle == 1 || _angle == 0);
    }
    private static  char isSignSame(float num)
    {
        return (num > 0) ? '+' : (num == 0) ? '0' : '-';
    }
    public static bool Check(LineHandler one, LineHandler two, float distanceRange, float angleRange)
    {
        float rangeD, rangeA;
        if(isSignSame(one._angle) != isSignSame(two._angle))
        {
            return false;
        }
        if (one._angle > two._angle)
            rangeA = one._angle - two._angle;
        else
            rangeA = two._angle - one._angle;

        if (one._distance > two._distance)
            rangeD = one._distance - two._distance;
        else
            rangeD = two._distance - one._distance;

        return (distanceRange > rangeD) && (angleRange > rangeA);

    }

}
public class FileHandler
{
    string _value;
    static int _length =0;
    short _index;
    [SerializeField]
    public static float _distanceRange=10,
          _angleRange=10;

    public FileHandler(string value)
    {
        _index = (short)++_length;
        _value = value;
    }
    //public void WriteTo(string text,bool eol)
    //{
    //    StreamWriter writer = new StreamWriter(_file);
    //    writer.Write(text + ((eol)?'\n':' '));
    //    writer.Close();
    //}
    public short CompareTo(string format)
    {
        string[] anotherLines = format.Split('\n');
        string[] lines =_value.Split('\n');

        for(int i =0,j=0; j< anotherLines.Length && i < lines.Length;)
        {
            LineHandler one = new LineHandler();
            LineHandler two = new LineHandler();

            while (i < lines.Length && one.InsertLine(lines[i++])) ;
            while (j < anotherLines.Length && two.InsertLine(anotherLines[j++])) ;
            Debug.LogFormat("One:\nDistance: {0}\nAngle: {1}\nTwo:\nDistance: {2}\nAngle: {3}\n", one.Distance, one.Angle, two.Distance, two.Angle);
            if (!LineHandler.Check(one, two, _distanceRange, _angleRange))
                return 0;



        }

        return _index;
    }

}