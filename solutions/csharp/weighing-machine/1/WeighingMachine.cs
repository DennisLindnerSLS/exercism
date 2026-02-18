using System;

class WeighingMachine
{
    // TODO: define the 'Precision' property
    private int _precision;
    public int Precision {
        get{ return _precision; }
    }
    // TODO: define the 'Weight' property
    private double _weight;
    public double Weight {
        get { return _weight; }
        set {
            if(value < 0) 
                throw new ArgumentOutOfRangeException();
            
            _weight = value; 
        }
    }
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight {
        get {
            double val = _weight - _tareAdjustment;
            return $"{Math.Round(val, _precision).ToString($"F{_precision}")} kg";
        }
    }
    // TODO: define the 'TareAdjustment' property
    private double _tareAdjustment = 5.0;
    public double TareAdjustment {
        set { _tareAdjustment = value; }
    }
    public WeighingMachine(int precision){
        _precision = precision;
    }
}
