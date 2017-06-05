using System;
using VehiclePark3;

namespace VP_Refactoring1
{
    public class InsertAllType
    {
        private VehicleSystem _vehicleSystem;

        public InsertAllType(VehicleSystem vehicleSystem)
        {
            _vehicleSystem = vehicleSystem;
        }

        public string InsertCar(Car carro, int s, int p, DateTime t)
        {
            bool flag = s > _vehicleSystem.layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DATA.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DATA.LicensePlateDictionary.ContainsKey(carro.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", carro.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DATA.CarDictionaryInPark[carro] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DATA.ParkDictionary[string.Format("({0},{1})", s, p)] = carro;
                            _vehicleSystem.DATA.LicensePlateDictionary[carro.LicensePlate] = carro;
                            _vehicleSystem.DATA.DateDictionary[carro] = t;
                            _vehicleSystem.DATA.OwnerMultiDictionary[carro.Owner].Add(carro);
                            _vehicleSystem.DATA.CountNumberOfSectors[s - 1]--;
                            result = string.Format("{0} parked successfully at place ({1},{2})", carro.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }

        public string InsertMotorbike(Moto moto, int s, int p, DateTime t)
        {
            bool flag = s > _vehicleSystem.layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DATA.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DATA.LicensePlateDictionary.ContainsKey(moto.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", moto.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DATA.CarDictionaryInPark[moto] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DATA.ParkDictionary[string.Format("({0},{1})", s, p)] = moto;
                            _vehicleSystem.DATA.LicensePlateDictionary[moto.LicensePlate] = moto;
                            _vehicleSystem.DATA.DateDictionary[moto] = t;
                            _vehicleSystem.DATA.OwnerMultiDictionary[moto.Owner].Add(moto);
                            _vehicleSystem.DATA.CountNumberOfSectors[s - 1]++;
                            result = string.Format("{0} parked successfully at place ({1},{2})", moto.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }

        public string InsertTruck(Truck caminhão, int s, int p, DateTime t)
        {
            bool flag = s > _vehicleSystem.layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DATA.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DATA.LicensePlateDictionary.ContainsKey(caminhão.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", caminhão.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DATA.CarDictionaryInPark[caminhão] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DATA.ParkDictionary[string.Format("({0},{1})", s, p)] = caminhão;
                            _vehicleSystem.DATA.LicensePlateDictionary[caminhão.LicensePlate] = caminhão;
                            _vehicleSystem.DATA.DateDictionary[caminhão] = t;
                            _vehicleSystem.DATA.OwnerMultiDictionary[caminhão.Owner].Add(caminhão);
                            result = string.Format("{0} parked successfully at place ({1},{2})", caminhão.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }
    }
}