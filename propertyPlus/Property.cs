using System;
using System.Collections.Generic;
using PropertyPlus.Interface;

namespace PropertyPlus.Domain
{
    public class Property : IProperty
    {
        private readonly IAddress address;
        private readonly IList<IMortgage> associatedMortgages = new List<IMortgage>();

        public Property(IAddress address)
        {
            if (address == null)
                throw new ArgumentException("Require associated address details");

            this.address = address;
        }

        public string Name
        {
            get { return address.Street; }         
        }

        public IAddress Address
        {
            get { return address; }       
        }

        public IEnumerable<IMortgage> AssociatedMortgages {
            get { return associatedMortgages; }
        }

        public void AddMortgage(IMortgage mortgage)
        {
            associatedMortgages.Add(mortgage);
        }
    }
}