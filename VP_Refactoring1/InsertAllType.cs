using System;

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
            bool flag = s > _vehicleSystem.Layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.Layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DataStructure.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DataStructure.LicensePlateDictionary.ContainsKey(carro.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", carro.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DataStructure.CarDictionaryInPark[carro] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DataStructure.ParkDictionary[string.Format("({0},{1})", s, p)] = carro;
                            _vehicleSystem.DataStructure.LicensePlateDictionary[carro.LicensePlate] = carro;
                            _vehicleSystem.DataStructure.DateDictionary[carro] = t;
                            _vehicleSystem.DataStructure.OwnerMultiDictionary[carro.Owner].Add(carro);
                            _vehicleSystem.DataStructure.CountNumberOfSectors[s - 1]--;
                            result = string.Format("{0} parked successfully at place ({1},{2})", carro.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }

        public string InsertMotorbike(Moto moto, int s, int p, DateTime t)
        {
            bool flag = s > _vehicleSystem.Layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.Layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DataStructure.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DataStructure.LicensePlateDictionary.ContainsKey(moto.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", moto.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DataStructure.CarDictionaryInPark[moto] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DataStructure.ParkDictionary[string.Format("({0},{1})", s, p)] = moto;
                            _vehicleSystem.DataStructure.LicensePlateDictionary[moto.LicensePlate] = moto;
                            _vehicleSystem.DataStructure.DateDictionary[moto] = t;
                            _vehicleSystem.DataStructure.OwnerMultiDictionary[moto.Owner].Add(moto);
                            _vehicleSystem.DataStructure.CountNumberOfSectors[s - 1]++;
                            result = string.Format("{0} parked successfully at place ({1},{2})", moto.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }

        public string InsertTruck(Truck caminhão, int s, int p, DateTime t)
        {
            bool flag = s > _vehicleSystem.Layout.Sectors;
            string result;
            if (flag)
            {
                result = string.Format("There is no sector {0} in the park", s);
            }
            else
            {
                bool flag2 = p > _vehicleSystem.Layout.PlacesSec;
                if (flag2)
                {
                    result = string.Format("There is no place {0} in sector {1}", p, s);
                }
                else
                {
                    bool flag3 = _vehicleSystem.DataStructure.ParkDictionary.ContainsKey(string.Format("({0},{1})", s, p));
                    if (flag3)
                    {
                        result = string.Format("The place ({0},{1}) is occupied", s, p);
                    }
                    else
                    {
                        bool flag4 = _vehicleSystem.DataStructure.LicensePlateDictionary.ContainsKey(caminhão.LicensePlate);
                        if (flag4)
                        {
                            result = string.Format("There is already a vehicle with license plate {0} in the park", caminhão.LicensePlate);
                        }
                        else
                        {
                            _vehicleSystem.DataStructure.CarDictionaryInPark[caminhão] = string.Format("({0},{1})", s, p);
                            _vehicleSystem.DataStructure.ParkDictionary[string.Format("({0},{1})", s, p)] = caminhão;
                            _vehicleSystem.DataStructure.LicensePlateDictionary[caminhão.LicensePlate] = caminhão;
                            _vehicleSystem.DataStructure.DateDictionary[caminhão] = t;
                            _vehicleSystem.DataStructure.OwnerMultiDictionary[caminhão.Owner].Add(caminhão);
                            result = string.Format("{0} parked successfully at place ({1},{2})", caminhão.GetType().Name, s, p);
                        }
                    }
                }
            }
            return result;
        }
    }
}