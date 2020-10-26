using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var surchedName = data.FirstOrDefault(n => n.Name == name);
            if (surchedName != null)
            {
                data.Remove(surchedName);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Pet GetPet(string name, string owner)
        {
            var surchedpet = data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            if (surchedpet != null)
            {
                return surchedpet;
            }
            else
            {
                return null;
            }
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestPet;
        }

        public int GetCount()
        {
            return data.Count;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString();
        }
    }
}
