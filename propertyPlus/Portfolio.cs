using System;
using System.Collections.Generic;
using System.Linq;
using PropertyPlus.Interface;

namespace PropertyPlus.Domain
{
    public class Portfolio 
    {
        private readonly IList<IProperty> properties = new List<IProperty>();

        public Portfolio(string name)
        {
            if(String.IsNullOrEmpty(name))
                throw new ArgumentException("Portfolio Name cant be null or empty");
            Name = name;
        }

        public IEnumerable<IProperty> Properties
        {
            get { return properties; }
        }

        public string Name { get; private set; }

        public void AddProperty(IProperty property)
        {
            properties.Add(property);
        }

        public void DeleteProperty(string propertyName)
        {
            if(properties.Count == 0)
                throw new IndexOutOfRangeException("Not a valid property for deletion");

           properties.Remove(properties.First(x => x.Name == propertyName));
        }
    }
}