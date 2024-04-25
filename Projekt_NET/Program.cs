using System.Reflection;

class Test
{
    static void Main(string[] args)
    {
        // ZADANIE 1.

        //Samochod s1 = new Samochod();
        //s1.WypiszInfo();
        //s1.Marka = "Fiat";
        //s1.Model = "126p";
        //s1.IloscDrzwi = 2;
        //s1.PojemnoscSilnika = 650;
        //s1.SrednieSpalanie = 6.0;
        //s1.WypiszInfo();
        //Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
        //s2.WypiszInfo();
        //double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
        //Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);
        //Samochod.WypiszIloscSamochodow(); 
        //Console.ReadKey();

        // ZADANIE 2.

        Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
        Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
        Garaz g1 = new Garaz();
        g1.Adres = "ul. Garażowa 1";
        g1.Pojemnosc = 1;
        Garaz g2 = new Garaz("ul. Garażowa 2", 2);
        g1.WprowadzSamochod(s1);
        g1.WypiszInfo();
        g1.WprowadzSamochod(s2);
        g2.WprowadzSamochod(s2);
        g2.WprowadzSamochod(s1);
        g2.WypiszInfo();
        g2.WyprowadzSamochod();
        g2.WypiszInfo();
        g2.WyprowadzSamochod();
        g2.WyprowadzSamochod();
        Console.ReadKey();
    }
}


class Samochod
{
    private string marka;
    private string model;
    private int iloscDrzwi;
    private double srednieSpalanie;
    private int pojemnoscSilnika;
    
    private static int liczbaSamochodow = 0; 

    public Samochod()
    {
        marka = "Nieznany"; 
        model = "Nieznany";
        iloscDrzwi = 0;
        srednieSpalanie = 0.0;
        pojemnoscSilnika = 0;
        liczbaSamochodow++;
    }

    public Samochod(string marka, string model, int iloscDrzwi, int pojemnoscSilnika, double srednieSpalanie)
    {
        this.marka = marka; 
        this.model = model;
        this.iloscDrzwi = iloscDrzwi;
        this.srednieSpalanie = srednieSpalanie;
        this.pojemnoscSilnika = pojemnoscSilnika;
        liczbaSamochodow++;
    }

    public string Marka { get { return marka; } set { marka = value; } }
    public string Model { get { return model; } set { model = value; } }
    public int IloscDrzwi { get { return iloscDrzwi; } set { iloscDrzwi = value; } }
    public double SrednieSpalanie { get { return srednieSpalanie; } set { srednieSpalanie = value; } }
    public int PojemnoscSilnika { get { return pojemnoscSilnika; } set { pojemnoscSilnika = value; } }

    public void WypiszInfo()
    {
        Console.WriteLine("Marka: " + marka);
        Console.WriteLine("Model: " + model);
        Console.WriteLine("Ilosc drzwi: " + iloscDrzwi);
        Console.WriteLine("Srednie spalanie: " + srednieSpalanie + "/100km");
        Console.WriteLine("Pojemność silnika: " + pojemnoscSilnika + "cc");
    }

    private double ObliczSpalanie(double dlugoscTrasy)
    {
        if (dlugoscTrasy > 0)
        {
            return (srednieSpalanie * dlugoscTrasy) / 100; // Wynik w l/100km
        }
        else
        {
            throw new ArgumentException("Nieprawidłowe wartości długości trasy!");
        }
    }

    public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
    {
        if (cenaPaliwa > 0)
        {
            return ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
        }
        else
        {
            throw new ArgumentException("Nieprawidłowe wartości ceny paliwa!");
        }
    }
    public static void WypiszIloscSamochodow()
    {
        Console.WriteLine("Liczba samochodów: " + liczbaSamochodow);
    }
}

class Garaz
{
    private string adres;
    private int pojemnosc;
    private int liczbaSamochodow = 0;
    private Samochod[] samochody;

    public Garaz()
    {
        adres = "nieznany";
        pojemnosc = 0;
        samochody = null;

    }
    public Garaz(string adres, int pojemnosc)
    {
        this.adres = adres;
        this.pojemnosc = pojemnosc;
        samochody = new Samochod[pojemnosc];
    }

    public string Adres { get { return adres; } set { adres = value; } }
    public int Pojemnosc { get { return pojemnosc; } set { 
            pojemnosc = value;
            samochody = new Samochod[pojemnosc];
        } 
    }
            
    public void WprowadzSamochod(Samochod s)
    {
        if(liczbaSamochodow < pojemnosc)
        {
            samochody[liczbaSamochodow] = s;
            liczbaSamochodow++;
            Console.WriteLine("Samochod zostal wprowadzony do garazu: " + adres);
        }
        else {
            Console.WriteLine("Garaz: " + adres + " jest juz pelny!");
        }
    }

    public void WyprowadzSamochod()
    {
        if (liczbaSamochodow > 0)
        {
            samochody[liczbaSamochodow-1] = null;
            liczbaSamochodow--;
            Console.WriteLine("Samochod zostal wyprowadzony z garazu: " + adres);
        }
        else
        {
            Console.WriteLine("Garaz: " + adres + " jest juz pusty!");
        }
    }

    public void WypiszInfo()
    {
        Console.WriteLine("Liczba garazowanych samochodow pod: " + adres + ": " + liczbaSamochodow);
        foreach(Samochod s in samochody)
        {
            if (s != null)
            {
                s.WypiszInfo();
            }
        }
    }
}