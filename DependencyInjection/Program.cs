namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SurucuBase surucu1 = new Surucu(" Efe");
            Araba araba = new Araba(surucu1);
            araba.Sur();

            Surucu surucu2 = new Surucu(" Eyup");
            araba = new Araba(surucu2);
            araba.Sur();

            surucu1.Dispose();
            
        }
    }

    class Araba        
    {
        private readonly SurucuBase _surucu; // has a relationship, katılımm: is a relationship

        public Araba(SurucuBase surucu)  // constructor injection
        {
            _surucu = surucu;
        } 

        public void Sur()
        {
            Console.WriteLine("Araba" + _surucu.Adi + " tarafından" + HizHesapla() + " ile suruluyor...");
        }

        string HizHesapla()
        {
            return " 70 km/h";
        }
    }

    abstract class SurucuBase : IDisposable
    {
        public string Adi { get; set; }
        protected SurucuBase(string adi)
        {
            Adi = adi;
        }
        protected SurucuBase()  // default constructor
        {
            Adi = "Çagıl";
        }
        public void Dispose()
        {
            Adi = "";
            GC.SuppressFinalize(this);
        }
    }

    class Surucu : SurucuBase
    {
        public Surucu(string adi) : base(adi)
        {
            Adi = adi;
        }
        public Surucu() : base()
        {

        }

    }
}