using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAssignment.Models;

namespace TechAssignment.Data
{
    public class InsuranceInitializer
    {
        public static void Initialize(InsuranceContext context)
        {
            context.Database.EnsureCreated();

            if (context.Carrier.Any())
            {
                return;
            }

            List<Carrier> carriers = new List<Carrier>();
            carriers = CreateCarriers();
            
            List<MGA> mgas = new List<MGA>();
            mgas = CreateMGAs();
            
            List<Advisor> advisors = new List<Advisor>();
            advisors = CreateAdvisors();

            carriers[1].MGAs.Add(mgas[3]);
            carriers[1].MGAs.Add(mgas[2]);

            mgas[1].Carriers.Add(carriers[2]);
            mgas[1].Carriers.Add(carriers[3]);
            mgas[1].Advisors.Add(advisors[2]);
            mgas[1].Advisors.Add(advisors[3]);

            advisors[1].MGAs.Add(mgas[3]);
            advisors[1].MGAs.Add(mgas[2]);

            carriers.ForEach(c => context.Carrier.Add(c));
            mgas.ForEach(m => context.MGA.Add(m));
            advisors.ForEach(a => context.Advisor.Add(a));

            context.SaveChanges();
        }

        private static List<Carrier> CreateCarriers()
        {
            List<Carrier> carriers = new List<Carrier>
            {
                new Carrier{BussinessName="Carrier1", BussinessAddress="Toronto", BussinessPhoneNumber="0123456789"},
                new Carrier{BussinessName="Carrier2", BussinessAddress="Cambridge", BussinessPhoneNumber="1234567890"},
                new Carrier{BussinessName="Carrier3", BussinessAddress="Etobicoke", BussinessPhoneNumber="2345678901"},
                new Carrier{BussinessName="Carrier4", BussinessAddress="Brampton", BussinessPhoneNumber="3456789012"},
                new Carrier{BussinessName="Carrier5", BussinessAddress="Markham", BussinessPhoneNumber="4567890123" }
            };
            return carriers;
        }

        private static List<MGA> CreateMGAs()
        {
            List<MGA> mgas = new List<MGA>
            {
                new MGA{BussinessName="MGA1", BussinessAddress="Barrie", BussinessPhoneNumber="0123456789"},
                new MGA{BussinessName="MGA2", BussinessAddress="Collingwood", BussinessPhoneNumber="0123456789"},
                new MGA{BussinessName="MGA3", BussinessAddress="London", BussinessPhoneNumber="0123456789"},
                new MGA{BussinessName="MGA4", BussinessAddress="Milton", BussinessPhoneNumber="0123456789"},
                new MGA{BussinessName="MGA5", BussinessAddress="Georgetown", BussinessPhoneNumber="0123456789"}
            };
            return mgas;
        }

        private static List<Advisor> CreateAdvisors()
        {
            List<Advisor> advisors = new List<Advisor>
            {
                new Advisor{FirstName="John",LastName="Doe",Address="Guelph",PhoneNumber="0123456789"},
                new Advisor{FirstName="Jane",LastName="Doe",Address="Waterloo",PhoneNumber="1234567890"},
                new Advisor{FirstName="Adam",LastName="Smith",Address="Hamilton",PhoneNumber="2345678901"},
                new Advisor{FirstName="Mike",LastName="Denton",Address="Witby",PhoneNumber="3456789012"},
                new Advisor{FirstName="Cory",LastName="Reimer",Address="Sudbury",PhoneNumber="4567890123"}
            };
            return advisors;
        }
    }
}
