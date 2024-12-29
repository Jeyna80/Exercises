public class Carowner
    {
   
        public class CarOwner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CarModel { get; set; }
            public int Year { get; set; }
        }

        private List<CarOwner> _carOwners = new List<CarOwner>();

        public CarOwner AddCarOwner(CarOwner owner)
        {
            owner.Id = _carOwners.Count + 1;
            _carOwners.Add(owner);
            return owner;
        }

        public CarOwner GetCarOwnerById(int id)
        {
            return _carOwners.FirstOrDefault(o => o.Id == id);
        }

        public List<CarOwner> GetAllCarOwners()
        {
            return _carOwners;
        }

        public CarOwner UpdateCarOwner(CarOwner owner)
        {
            var existingOwner = _carOwners.FirstOrDefault(o => o.Id == owner.Id);
            if (existingOwner != null)
            {
                existingOwner.Name = owner.Name;
                existingOwner.CarModel = owner.CarModel;
                existingOwner.Year = owner.Year;
            }
            return existingOwner;
        }

        public bool DeleteCarOwner(int id)
        {
            var owner = _carOwners.FirstOrDefault(o => o.Id == id);
            if (owner != null)
            {
                _carOwners.Remove(owner);
                return true;
            }
            return false;
        }
    }





