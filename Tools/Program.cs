using System;
using System.Reflection;

namespace Tools
{
    public class Voiture
    {
        public string Matriculation { get; set; }
    };
    public class Car
    {
        public string Matriculation { get; set; }
    };
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public Voiture Voiture { get; set; }

    };

    public class Homme
    {
        public Homme()
        {
        }
        public Homme(Personne p)
        {
            //Nom = p.Nom;
            //Prenom = p.Prenom;
            //Age = p.Age;
            Type type = this.GetType();
            Type type2 = p.GetType();

            foreach (PropertyInfo prp in type.GetProperties())
            {
                foreach (PropertyInfo prp2 in type2.GetProperties())
                {
                    if (prp.Name == prp2.Name)
                    {
                        if ((prp.PropertyType.Name == "String") || prp.PropertyType.Name.ToLower().Contains("int"))
                        {
                            prp.SetValue(this, prp2.GetValue(p));
                            break;
                        }else
                        {
                            //Type type1 = prp.PropertyType;
                            //Type type3 = prp2.PropertyType;
                            //prp.SetValue(this, mapper<type1, type3>(prp.GetValue(this), prp2.GetValue(p)));
                            break;
                        }
                    }
                }
            }
        }

        private object mapper<T,T1>(object v1, object v2)
        {
            throw new NotImplementedException();
        }

        //private object mapper(PropertyInfo Pprp, PropertyInfo Pprp2)
        //{
        //    Type type = Pprp.GetType();
        //    Type type2 = Pprp2.GetType();

        //    foreach (PropertyInfo prp in type.GetProperties())
        //    {
        //        foreach (PropertyInfo prp2 in type2.GetProperties())
        //        {
        //            if (prp.Name == prp2.Name)
        //            {
        //                if ((prp.PropertyType.Name == "String") || prp.PropertyType.Name.ToLower().Contains("int"))
        //                {
        //                    prp.SetValue(this, prp2.GetValue(Pprp2));
        //                }
        //                else
        //                {
        //                    prp.SetValue(this, mapper(prp, prp2));
        //                }
        //            }
        //        }
        //    }
        //    return Pprp;
        //}

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public Car Voiture { get; set; }


    }
    class Program
    {

        static void Main(string[] args)
        {
            var p = new Personne()
            {
                Nom = "test",
                Age = 10,
                Prenom = "Essai",
                Voiture = new Voiture { Matriculation = "567GT01"}
            };

            //var h = new Homme();

            var h = new Homme(p);

            Console.WriteLine("Hello World!");
        }
    }
}
