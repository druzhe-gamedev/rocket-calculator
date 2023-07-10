using System;
using RocketCalculator.Models;
using RocketCalculator.ViewModels;

namespace RocketCalculator.Services;

public class CalculationService : BindedObject, IService
{
    #region Properties
    
    double _rocketVolume;
    public double RocketVolume { 
        get => _rocketVolume;
        private set
        {
            _rocketVolume = value;
            OnPropertyChanged();
        } 
    }

    double _burningTime;
    public double BurningTime { 
        get => _burningTime;
        private set
        {
            _burningTime = value;
            OnPropertyChanged();
        } 
    }
    
    double _rocketMaxSpeed;
    public double RocketMaxSpeed { 
        get => _rocketMaxSpeed;
        private set
        {
            _rocketMaxSpeed = value;
            OnPropertyChanged();
        } 
    }
    
    double _rocketShellMass;
    public double RocketShellMass { 
        get => _rocketShellMass;
        private set
        {
            _rocketShellMass = value;
            OnPropertyChanged();
        } 
    }
    
    double _fuelMass;
    public double FuelMass { 
        get => _fuelMass;
        private set
        {
            _fuelMass = value;
            OnPropertyChanged();
        } 
    }
    
    #endregion
    
    public CalculationService(RocketExteriorData exteriorData, RocketEngineData engineData)
    {
        _exteriorData = exteriorData;
        _engineData = engineData;
    }
    
    public void GetResult()
    {
        RocketVolume = GetRocketVolume();
        BurningTime = GetBurningSpeed();
        RocketMaxSpeed = GetRocketMaxSpeed();
        FuelMass = GetFuelMass();
        RocketShellMass = GetRocketShellMass();
    }
    
    readonly RocketEngineData _engineData;
    readonly RocketExteriorData _exteriorData;
    
    Func<float, double> Double = (float x) => Math.Pow(x, 2);

    private double GetRocketVolume()
    {
        var volume = Double(_exteriorData.RocketOuterDiameter / 2) * Math.PI * _exteriorData.RocketHeight;
        var result = IsCorrectValue(volume) ? volume : 0;
        
        return result;
    }

    private double GetBurningSpeed()
    {
        var speed = (_exteriorData.RocketDiameter - _engineData.EngineChannelDiameter) / _engineData.BurningSpeed;
        var result = IsCorrectValue(speed) ? speed : 0;
        
        return result;
    }
    
    private double GetRocketMaxSpeed()
    {
        var speed = 1300 * Math.Log((FuelMass + RocketShellMass) / RocketShellMass);
        var result = IsCorrectValue(speed) ? speed : 0;
        
        return result;
    }

    private double GetFuelMass() =>
        GetMass(_engineData.FuelDensity,
            Double((_exteriorData.RocketDiameter - _engineData.EngineChannelDiameter) / 2) * Math.PI * _engineData.EngineHeight);

    private double GetRocketShellMass() =>
        GetMass(_exteriorData.RocketShellDensity, 
            RocketVolume);

    private double GetMass(double density, double volume) => density * volume;

    private bool IsCorrectValue(double value) => !double.IsInfinity(value) && !double.IsNaN(value);
}